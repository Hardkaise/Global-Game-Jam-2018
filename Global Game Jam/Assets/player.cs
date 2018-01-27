using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    public Rigidbody2D body;
    private Animator anim;

	void Start () {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

	void FixedUpdate () {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        if (moveVertical > 0 && anim.GetCurrentAnimatorStateInfo(0).IsName("wait"))
        {
           // Debug.Log("enter");
            anim.SetTrigger("up");
        }
        else if (moveVertical < 0 && anim.GetCurrentAnimatorStateInfo(0).IsName("wait"))
            anim.SetTrigger("down");
        else if (moveHorizontal > 0 && anim.GetCurrentAnimatorStateInfo(0).IsName("wait"))
            anim.SetTrigger("right");
        else if (moveHorizontal < 0 && anim.GetCurrentAnimatorStateInfo(0).IsName("wait"))
            anim.SetTrigger("left");
        movement.x *= (float)0.1;
        movement.y *= (float)0.1;
        var moveX = body.transform.position.x;
        var moveY = body.transform.position.y;
        body.transform.position = new Vector3(moveX + movement.x, moveY + movement.y, 0);
    }
}
