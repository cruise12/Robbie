using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;
    PlayerMovement movement;
    Rigidbody2D rb;
    int groundId;
    int crouchId;
    int hangId;
    int fallID;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        movement = GetComponentInParent<PlayerMovement>();
        rb = GetComponentInParent<Rigidbody2D>();
        groundId = Animator.StringToHash("isOnGround");
        crouchId = Animator.StringToHash("isCrouching");
        hangId = Animator.StringToHash("isHanging");
        fallID = Animator.StringToHash("vVelocity");
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("speed", Mathf.Abs(movement.xVelocity));
        anim.SetBool(groundId, movement.isOnGround);
        anim.SetBool(crouchId, movement.isCrouch);
        //anim.SetBool(hangId, movement.isHeadBlock);
        anim.SetFloat(fallID,rb.velocity.y);
    }
 
    public void StepAduio()
    {
        Audiomanager.PlayerFootstepAudio();
    }
    public void CrouchStepAudio()
    {
        Audiomanager.PlayerFootstepAudio();
    }
}
