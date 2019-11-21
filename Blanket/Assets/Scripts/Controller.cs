using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{ 

    public float speed;
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    int dir=0;

    void Start()
    {
        this.rigidbody2D = this.GetComponent<Rigidbody2D>();
        animator=gameObject.GetComponent<Animator>();
    }

   
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 input = new Vector2(horizontal, vertical);
        if(horizontal < 0)
        {
            dir=1;
            animator.Play("LeftWalking");
        }
        else if (horizontal > 0)
        {
            dir=2;
            animator.Play("RightWalking");
        }
        else if (vertical > 0)
        {
            dir=3;
            animator.Play("BackWalking");
        }
        else if(vertical < 0)
        {
            dir=0;
            animator.Play("Walking");
        }
        else
        {
            if(dir==0)
            {
                animator.Play("Stand");
            }
            else if(dir==1)
            {
                animator.Play("LeftStanding");
            }
            else if(dir==2)
            {
                animator.Play("RightStanding");
            }
            else if(dir==3)
            {
                animator.Play("BackStanding");
            }
        
            
        }

        /*
        (Mathf.Abs(horizontal) < Mathf.Abs(vertical))

        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.Play("Standing");
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.Play("BackStanding");
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.Play("LeftStanding");
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.Play("RightStanding");
        }*/

        input = Vector2.ClampMagnitude(input, 1);

        Vector2 move = rigidbody2D.position + input * speed*Time.deltaTime;

        this.rigidbody2D.MovePosition(move);

        
        
    }

}