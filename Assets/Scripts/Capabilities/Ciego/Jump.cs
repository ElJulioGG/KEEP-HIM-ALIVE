using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public ParticleSystem Dust;
    public GameObject FloatingTextPrefab;
    public GameObject Dog;
    [SerializeField] private InputController input = null;
    [SerializeField, Range(0f, 10f)] private float jumpHeight = 3f;
    [SerializeField, Range(0, 5)] private int maxAirJumps = 0;
    [SerializeField, Range(0f, 5f)] private float downwardMovementMultiplier = 3f;
    [SerializeField, Range(0f, 5f)] private float upwardMovementMultiplier = 1.7f;

    public Animator animator;
    private Rigidbody2D body;
    private Ground ground;
    private Vector2 velocity;
    private int jumpPhase;
    private float defaultGravityScale;

    private bool desiredJump;
    [SerializeField] private bool onGround;

    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        ground = GetComponent<Ground>();

        defaultGravityScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        desiredJump |= input.RetriveJumpInput();
    }
    private void FixedUpdate()
    {
        onGround = ground.GetOnGround();
        velocity = body.velocity;
        if (onGround)
        {
            jumpPhase = 0;
            
        }
       
        if (desiredJump)
        {
            desiredJump = false;
            JumpAction();
        }
        if (body.velocity.y > 0)
        {
            body.gravityScale = upwardMovementMultiplier;
        }
        else if (body.velocity.y < 0)
        {
            body.gravityScale = downwardMovementMultiplier;
        }
        else if(body.velocity.y == 0)
        {
            body.gravityScale = defaultGravityScale;
        }
        body.velocity = velocity;
    }
    private void JumpAction()
    {
        if ((onGround || jumpPhase < maxAirJumps) && Dog.activeInHierarchy)
        {
            CreateDust();
            int randomIndex = Random.Range(0, 5);
            jumpPhase += 1;
            float jumpSpeed = Mathf.Sqrt(-2f * Physics2D.gravity.y * jumpHeight);
            if(velocity.y > 0f)
            {
                jumpSpeed = Mathf.Max(jumpSpeed - velocity.y, 0f);
            }
            velocity.y += jumpSpeed;
            
            switch (randomIndex)
            {
                case 0:
                    AudioManager.instance.PlayBark("BarkA01");
                    break;
                case 1:
                    AudioManager.instance.PlayBark("BarkA02");
                    break;
                case 2:
                    AudioManager.instance.PlayBark("BarkA03");
                    break;
                case 3:
                    AudioManager.instance.PlayBark("BarkA04");
                    break;
                case 4:
                    AudioManager.instance.PlayBark("BarkA05");
                    break;
                case 5:
                    AudioManager.instance.PlayBark("BarkA06");
                    break;
            }
            if (FloatingTextPrefab)
            {
                showFloatingText();
            }
        }
        //Debug.Log("Jump");
    }

    
    void showFloatingText()
    {
        Instantiate(FloatingTextPrefab, Dog.transform.position, Quaternion.identity); //ampliar con el dog.transform si es necesario
    }

    void CreateDust()
    {
        Dust.Play();
    }

}
