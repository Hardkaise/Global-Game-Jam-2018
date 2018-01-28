using UnityEngine;

public class player : MonoBehaviour
{

    public Rigidbody2D Body;
    private const int WallDamage = 1;
    private bool _hited = false;
    private Animator _anim;

    protected  void Start()
    {
        Body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {

        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");
        var movement = new Vector2(moveHorizontal, moveVertical);
        if (moveVertical > 0 && _anim.GetCurrentAnimatorStateInfo(0).IsName("wait"))
        {
            // Debug.Log("enter");
            _anim.SetTrigger("up");
        }
        else if (moveVertical < 0 && _anim.GetCurrentAnimatorStateInfo(0).IsName("wait"))
            _anim.SetTrigger("down");
        else if (moveHorizontal > 0 && _anim.GetCurrentAnimatorStateInfo(0).IsName("wait"))
            _anim.SetTrigger("right");
        else if (moveHorizontal < 0 && _anim.GetCurrentAnimatorStateInfo(0).IsName("wait"))
            _anim.SetTrigger("left");
        movement.x *= (float) 0.1;
        movement.y *= (float) 0.1;
        var moveX = Body.transform.position.x;
        var moveY = Body.transform.position.y;
        Body.transform.position = new Vector3(moveX + movement.x, moveY + movement.y, 0);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall") && !_hited)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                var hitWAll = other.gameObject.GetComponent<Wall>();
                hitWAll.DamageWall(WallDamage);
                _hited = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.E))
            _hited = false;
    }
}