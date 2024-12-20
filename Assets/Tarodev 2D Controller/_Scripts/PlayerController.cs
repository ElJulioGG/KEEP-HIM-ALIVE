using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using TarodevController;

using UnityEngine.Events;
using System.Runtime.CompilerServices;

namespace TarodevController
{
   
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        public ParticleSystem Dust;
        public UnityEvent evento;
        public Animator animator;
        // Public for external hooks
        public Vector3 Velocity { get; private set; }
        public FrameInput Input { get; protected set; }
        public bool JumpingThisFrame { get; set; }
        public bool LandingThisFrame { get; private set; }
        public Vector3 RawMovement { get; private set; }
        public bool Grounded => _colDown;

        private Vector3 _lastPosition;
        [SerializeField] public float _currentHorizontalSpeed, _currentVerticalSpeed;

        // This is horrible, but for some reason colliders are not fully established when update starts...
        private bool _active;
        void Awake() => Invoke(nameof(Activate), 0.5f);
        void Activate() => _active = true;

        public bool CantInput;
       [SerializeField] public bool isOnEnd;
        bool derecha = true;
        public bool isRunning;
        [SerializeField] public bool ColTecho = false;

        public bool isEnabled = false;
        public void SetCantInput(bool cntInput)
        {
            CantInput = cntInput;
        }

        private void Start()
        {
            Invoke("MakeEnabled", 2f);
            GameManager.instance.GameOver = false;
        }

        private void Update()
        {
            if (isEnabled)
            {
                if (!Grounded|| Mathf.Abs(_currentHorizontalSpeed) == 0)
                {
                    AudioManager.instance.FootStepsSource.Stop();
                }
                //OnJumpPad =false;
                if (!_active) return;
                // Calculate velocity
                Velocity = (transform.position - _lastPosition) / Time.deltaTime;
                _lastPosition = transform.position;

                animator.SetFloat("Speed", Mathf.Abs(_currentHorizontalSpeed));
                animator.SetFloat("verticalSpeed", _currentVerticalSpeed);
                if (Grounded)
                {
                    animator.SetBool("isJumping", false);
                }
                else
                {
                    animator.SetBool("isJumping", true);
                    //animator.SetBool("jumpingThisFrame", true);
                }
                
                if (_currentHorizontalSpeed > 0 && !derecha)
                {
                    flip();
                    
                }
                if (_currentHorizontalSpeed < 0 && derecha)
                {
                    flip();
                    
                }
                GatherInput();

                RunCollisionChecks();

                CalculateWalk(); // Horizontal movement
                CalculateJumpApex(); // Affects fall speed, so calculate before gravity
                CalculateGravity(); // Vertical movement
                CalculateJump(); // Possibly overrides vertical

                MoveCharacter(); // Actually perform the axis movement
                if (!Grounded || _currentHorizontalSpeed == 0)
                {
                    //AudioManager.instance.FootStepsSource.Stop();
                }
            }
        }

        void CreateDust()
        {
            Dust.Play();
        }
        void MakeEnabled()
        {
            evento.Invoke();
            isEnabled = true;
        }
        void flip()
        {
            Vector3 characterScale = transform.localScale;
            characterScale.x *= -1;

            transform.localScale = characterScale;

            derecha = !derecha;
            if (Grounded) {
                CreateDust();
            }
          
            Debug.Log("flip");
        }

        void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Salida"))
            {
                isOnEnd = true;
            }
           
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Salida"))
            {
                isOnEnd = false;
            }
        }

        #region Gather Input

        private void GatherInput()
        {
            if (CantInput == false)
            {
                Input = new FrameInput
                {
                    JumpDown = UnityEngine.Input.GetButtonDown("Jump"),
                    JumpUp = UnityEngine.Input.GetButtonUp("Jump"),
                    X = UnityEngine.Input.GetAxisRaw("Horizontal"),
                    RunDown = UnityEngine.Input.GetButton("Run")
                };
                if (Input.JumpDown)
                {
                    _lastJumpPressed = Time.time;
                }
            }
        }

        #endregion

        #region Collisions

        [Header("COLLISION")][SerializeField] private Bounds _characterBounds;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private int _detectorCount = 3;
        [SerializeField] private float _detectionRayLength = 0.1f;
        [SerializeField][Range(0.1f, 0.3f)] private float _rayBuffer = 0.1f; // Prevents side detectors hitting the ground

        private RayRange _raysUp, _raysRight, _raysDown, _raysLeft;
        private bool _colUp, _colRight, _colDown, _colLeft;

        private float _timeLeftGrounded;

        // We use these raycast checks for pre-collision information
        private void RunCollisionChecks()
        {
            // Generate ray ranges. 
            CalculateRayRanged();

            // Ground
            LandingThisFrame = false;
            var groundedCheck = RunDetection(_raysDown);
            if (_colDown && !groundedCheck) _timeLeftGrounded = Time.time; // Only trigger when first leaving
            else if (!_colDown && groundedCheck)
            {
                _coyoteUsable = true; // Only trigger when first touching
                LandingThisFrame = true;
            }

            _colDown = groundedCheck;

            // The rest
            _colUp = RunDetection(_raysUp);
            _colLeft = RunDetection(_raysLeft);
            _colRight = RunDetection(_raysRight);

            bool RunDetection(RayRange range)
            {
                return EvaluateRayPositions(range).Any(point => Physics2D.Raycast(point, range.Dir, _detectionRayLength, _groundLayer));
            }
        }

        private void CalculateRayRanged()
        {
            // This is crying out for some kind of refactor. 
            var b = new Bounds(transform.position, _characterBounds.size);

            _raysDown = new RayRange(b.min.x + _rayBuffer, b.min.y, b.max.x - _rayBuffer, b.min.y, Vector2.down);
            _raysUp = new RayRange(b.min.x + _rayBuffer, b.max.y, b.max.x - _rayBuffer, b.max.y, Vector2.up);
            _raysLeft = new RayRange(b.min.x, b.min.y + _rayBuffer, b.min.x, b.max.y - _rayBuffer, Vector2.left);
            _raysRight = new RayRange(b.max.x, b.min.y + _rayBuffer, b.max.x, b.max.y - _rayBuffer, Vector2.right);
        }


        private IEnumerable<Vector2> EvaluateRayPositions(RayRange range)
        {
            for (var i = 0; i < _detectorCount; i++)
            {
                var t = (float)i / (_detectorCount - 1);
                yield return Vector2.Lerp(range.Start, range.End, t);
            }
        }

        private void OnDrawGizmos()
        {
            // Bounds
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(transform.position + _characterBounds.center, _characterBounds.size);

            // Rays
            if (!Application.isPlaying)
            {
                CalculateRayRanged();
                Gizmos.color = Color.blue;
                foreach (var range in new List<RayRange> { _raysUp, _raysRight, _raysDown, _raysLeft })
                {
                    foreach (var point in EvaluateRayPositions(range))
                    {
                        Gizmos.DrawRay(point, range.Dir * _detectionRayLength);
                    }
                }
            }

            if (!Application.isPlaying) return;

            // Draw the future position. Handy for visualizing gravity
            Gizmos.color = Color.red;
            var move = new Vector3(_currentHorizontalSpeed, _currentVerticalSpeed) * Time.deltaTime;
            Gizmos.DrawWireCube(transform.position + move, _characterBounds.size);
        }

        #endregion


        #region Walk

        [Header("WALKING")][SerializeField] private float _acceleration = 90;
        private float _moveClamp;
        [SerializeField] private float _deAcceleration = 60f;
        [SerializeField] private float _apexBonus = 2;
        [SerializeField] private float _runSpeed = 2;
        [SerializeField] private float _moveClampSpeed = 13;
        //public float RunSpeed;

        private void CalculateWalk()
        {

            if (Input.RunDown)
            {
                
                _moveClamp = _moveClampSpeed * _runSpeed;
                isRunning = true;
                animator.SetBool("isRunning", true);
            }
            else
            {
                
                _moveClamp = _moveClampSpeed;
                isRunning = false;
                animator.SetBool("isRunning", false);
            }
            if (Input.X != 0)
            {
                if (!AudioManager.instance.FootStepsSource.isPlaying && isRunning && Grounded && Mathf.Abs(_currentHorizontalSpeed) >0)
                {
                    AudioManager.instance.PlayFootSteps("DogRun");
                }
                if (!AudioManager.instance.FootStepsSource.isPlaying && !isRunning && Grounded && Mathf.Abs(_currentHorizontalSpeed) > 0)
                {
                    AudioManager.instance.PlayFootSteps("DogWalk");
                }
                
                // Set horizontal move speed
                _currentHorizontalSpeed += Input.X * _acceleration * Time.deltaTime;

                // clamped by max frame movement
                _currentHorizontalSpeed = Mathf.Clamp(_currentHorizontalSpeed, -_moveClamp, _moveClamp);
                // Apply bonus at the apex of a jump
                var apexBonus = Mathf.Sign(Input.X) * _apexBonus * _apexPoint;

                //if (Input.Run == true)
                //{
                //    _currentHorizontalSpeed = _currentHorizontalSpeed * _runSpeed;
                //}
                _currentHorizontalSpeed += apexBonus * Time.deltaTime;
                animator.SetBool("isNotInput", false);
            }
            else
            {
                // No input. Let's slow the character down
                _currentHorizontalSpeed = Mathf.MoveTowards(_currentHorizontalSpeed, 0, _deAcceleration * Time.deltaTime);
                animator.SetBool("isNotInput", true);
                AudioManager.instance.FootStepsSource.Stop();
            }

            if (_currentHorizontalSpeed > 0 && _colRight || _currentHorizontalSpeed < 0 && _colLeft)
            {
                // Don't walk through walls
                _currentHorizontalSpeed = 0;
            }


        }

        #endregion

        #region Gravity

        [Header("GRAVITY")][SerializeField] private float _fallClamp = -40f;
        [SerializeField] private float _minFallSpeed = 80f;
        [SerializeField] private float _maxFallSpeed = 120f;
        [SerializeField] private float _fallSpeed;

        private void CalculateGravity()
        {
            if (_colDown)
            {
                // Move out of the ground
                if (_currentVerticalSpeed < 0) _currentVerticalSpeed = 0;
            }
            else
            {
                // Add downward force while ascending if we ended the jump early
                var fallSpeed = _endedJumpEarly && _currentVerticalSpeed > 0 ? _fallSpeed * _jumpEndEarlyGravityModifier : _fallSpeed;

                // Fall
                _currentVerticalSpeed -= fallSpeed * Time.deltaTime;

                // Clamp
                if (_currentVerticalSpeed < _fallClamp) _currentVerticalSpeed = _fallClamp;
            }
        }

        #endregion

        #region Jump

        [Header("JUMPING")][SerializeField] public float _jumpHeight = 30;
        [SerializeField] private float _jumpApexThreshold = 10f;
        [SerializeField] private float _coyoteTimeThreshold = 0.1f;
        [SerializeField] private float _jumpBuffer = 0.1f;
        [SerializeField] private float _jumpEndEarlyGravityModifier = 3;
        [SerializeField] private bool _coyoteUsable;
        [SerializeField] public bool _endedJumpEarly = true;
        [SerializeField] public float _apexPoint; // Becomes 1 at the apex of a jump
        [SerializeField] private float _lastJumpPressed;
        [SerializeField] private bool CanUseCoyote => _coyoteUsable && !_colDown && _timeLeftGrounded + _coyoteTimeThreshold > Time.time;
        [SerializeField] private bool HasBufferedJump => _colDown && _lastJumpPressed + _jumpBuffer > Time.time;

        private void CalculateJumpApex()
        {
            if (!_colDown)
            {
                // Gets stronger the closer to the top of the jump
                _apexPoint = Mathf.InverseLerp(_jumpApexThreshold, 0, Mathf.Abs(Velocity.y));
                _fallSpeed = Mathf.Lerp(_minFallSpeed, _maxFallSpeed, _apexPoint);
            }
            else
            {
                _apexPoint = 0;
            }
        }

        private void CalculateJump()
        {
            // Jump if: grounded or within coyote threshold || sufficient jump buffer
            if ((Input.JumpDown && CanUseCoyote || HasBufferedJump)&& !ColTecho )
            {
                AudioManager.instance.PlaySfx("DogJump");
                CreateDust();
                _currentVerticalSpeed = _jumpHeight;
                _endedJumpEarly = false;
                _coyoteUsable = false;
                _timeLeftGrounded = float.MinValue;
                JumpingThisFrame = true;
                animator.SetTrigger("jumpingThisFrame");
                AudioManager.instance.FootStepsSource.Stop();

            }
            else
            {
                JumpingThisFrame = false;

            }

            // End the jump early if button released
            if (!_colDown && Input.JumpUp && !_endedJumpEarly && Velocity.y > 0)
            {
                // _currentVerticalSpeed = 0;
                _endedJumpEarly = true;
            }

            if (_colUp)
            {
                if (_currentVerticalSpeed > 0) _currentVerticalSpeed = 0;
            }
        }

        #endregion

        #region Move

        [Header("MOVE")]
        [SerializeField, Tooltip("Raising this value increases collision accuracy at the cost of performance.")]
        private int _freeColliderIterations = 10;

        // We cast our bounds before moving to avoid future collisions
        private void MoveCharacter()
        {
            var pos = transform.position;
            RawMovement = new Vector3(_currentHorizontalSpeed, _currentVerticalSpeed); // Used externally
            var move = RawMovement * Time.deltaTime;
            var furthestPoint = pos + move;

            // check furthest movement. If nothing hit, move and don't do extra checks
            var hit = Physics2D.OverlapBox(furthestPoint, _characterBounds.size, 0, _groundLayer);
            if (!hit)
            {
                transform.position += move;
                return;
            }

            // otherwise increment away from current pos; see what closest position we can move to
            var positionToMoveTo = transform.position;
            for (int i = 1; i < _freeColliderIterations; i++)
            {
                // increment to check all but furthestPoint - we did that already
                var t = (float)i / _freeColliderIterations;
                var posToTry = Vector2.Lerp(pos, furthestPoint, t);

                if (Physics2D.OverlapBox(posToTry, _characterBounds.size, 0, _groundLayer))
                {
                    transform.position = positionToMoveTo;

                    // We've landed on a corner or hit our head on a ledge. Nudge the player gently
                    if (i == 1)
                    {
                        if (_currentVerticalSpeed < 0) _currentVerticalSpeed = 0;
                        var dir = transform.position - hit.transform.position;
                        transform.position += dir.normalized * move.magnitude;
                    }

                    return;
                }

                positionToMoveTo = posToTry;
            }
        }

        #endregion



    }
}