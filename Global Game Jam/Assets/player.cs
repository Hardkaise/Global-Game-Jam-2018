using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    public Rigidbody2D body;
    private Animator anim;

	void Start () {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("check", true);
    }

	void FixedUpdate () {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        if (Input.GetKey(KeyCode.LeftArrow) && anim.GetBool("check") == true)
        {
            anim.SetBool("check", false);
            anim.SetTrigger("left");
        }
        if (Input.GetKey(KeyCode.DownArrow) && anim.GetBool("check") == true)
        {
            anim.SetBool("check", false);
            anim.SetTrigger("down");
        }
        if (Input.GetKey(KeyCode.UpArrow) && anim.GetBool("check") == true)
        {
            anim.SetBool("check", false);
            anim.SetTrigger("up");
        }
        if (Input.GetKey(KeyCode.RightArrow) && anim.GetBool("check") == true)
        {
            anim.SetBool("check", false);
            anim.SetTrigger("right");
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("left") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.25f && !Input.GetKey(KeyCode.LeftArrow))
            anim.SetBool("check", true);
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("down") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.25f && !Input.GetKey(KeyCode.DownArrow))
            anim.SetBool("check", true);
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("right") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.25f && !Input.GetKey(KeyCode.RightArrow))
            anim.SetBool("check", true);
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("up") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.25f && !Input.GetKey(KeyCode.UpArrow))
            anim.SetBool("check", true);
        movement.x *= (float)0.1;
        movement.y *= (float)0.1;
        var moveX = body.transform.position.x;
        var moveY = body.transform.position.y;
        body.transform.position = new Vector3(moveX + movement.x, moveY + movement.y, 0);
    }
}
