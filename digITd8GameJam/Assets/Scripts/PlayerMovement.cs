using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));
        if (Input.GetKeyDown(KeyCode.Space)) {
            jump = true;
            animator.SetBool("jump", true);
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            crouch = true;
        } else if (Input.GetKeyUp(KeyCode.S)) {
            crouch = false;
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    public void OnLand() 
    {
        animator.SetBool("jump", false);
    }
}
