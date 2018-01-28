using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour {

    public Rigidbody2D Body;
    private Animator _anim;
    private float timeLeft = 0f;
    bool next;
    // Use this for initialization
    void Start () {
        Body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        if (Random.Range(0, 2) % 2 == 0)
        {
            next = false;
        }
        else
            next = true;
        

    }
	
	// Update is called once per frame
	void Update () {
        timeLeft += Time.deltaTime;
        if (next == true)
        Body.AddForce(new Vector2(Random.Range(-2, 5), Random.Range(-2, 5)));
        else
            Body.AddForce(new Vector2(Random.Range(-5, 2), Random.Range(-5, 2)));
        if (timeLeft > 2f)
        {
            Body.velocity = Vector2.zero;
            Body.angularVelocity = 0;
            timeLeft = 0f;
            if (next)
                next = false;
            else
                next = true;
        }
    }
}
