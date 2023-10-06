using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="PlayerController2", menuName ="InputController/PlayerController2")]
public class PlayerController2 : InputController
{
    public override bool RetriveJumpInput()
    {
        return Input.GetButtonDown("Jump");
    }

    public override float RetriveMoveInput()
    {
        return Input.GetAxisRaw("Horizontal");
    }

    
}
