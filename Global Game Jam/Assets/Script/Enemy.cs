using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour {

    public Rigidbody2D Body;
    private Animator _anim;
    private float timeLeft = 0f;
    bool next;
    public bool isWolf { get; set; }
    int life = 12;
    // Use this for initialization
    void Start () {
        isWolf = false;
        Body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _anim.SetInteger("life", life);
        _anim.SetBool("check", true);
        if (Random.Range(0, 2) % 2 == 0)
        {
            next = false;
        }
        else
            next = true;
        

    }
	
	// Update is called once per frame
	void Update () {
        float x;
        float y;
        _anim.SetInteger("life", life);
        timeLeft += Time.deltaTime;
        if (next == true)
        Body.AddForce(new Vector2(x = Random.Range(-2, 5), y = Random.Range(-2, 5)));
        else
            Body.AddForce(new Vector2(x = Random.Range(-5, 2), y = Random.Range(-5, 2)));
        if (timeLeft > 2f)
        {
            _anim.SetBool("check", true);
            Body.velocity = Vector2.zero;
            Body.angularVelocity = 0;
            timeLeft = 0f;
            if (next)
                next = false;
            else
                next = true;

            if (isWolf)
            {
                if (x < 0 && _anim.GetBool("check") == true)
                {
                    _anim.SetBool("check", false);
                    _anim.SetTrigger("left");
                }
                else if (y < 0 && _anim.GetBool("check") == true)
                {
                    _anim.SetBool("check", false);
                    _anim.SetTrigger("down");
                }
                else if (y > 0 && _anim.GetBool("check") == true)
                {
                    _anim.SetBool("check", false);
                    _anim.SetTrigger("up");
                }
                else if (x > 0 && _anim.GetBool("check") == true)
                {
                    _anim.SetBool("check", false);
                    _anim.SetTrigger("right");
                }
//                if (_anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.25f)
//                    _anim.SetBool("check", true);
            }
        }
        if (isWolf == false && life <= 0)
        {
            _anim.SetTrigger("wait");
            isWolf = true;
            life = 12;
        }
        if (isWolf == true && life <= 0)
        {
            gameObject.SetActive(false);
        }

    }

    public void attack()
    {
        if (isWolf == false)
            life -= 3;
    }
}
