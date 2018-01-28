using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D Body;
    private const int WallDamage = 1;
    private bool _hited = false;
    private Animator _anim;
    private int life = 10;
    Vector2 fixPos;
    bool die = false;

    protected  void Start()
    {
        Body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _anim.SetBool("check", true);
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        if (_anim.GetInteger("life") <= 0 && !die)
        {
            _anim.SetTrigger("die");
            fixPos = Body.position;
            die = true;

        }
        else if (Input.GetKey(KeyCode.LeftArrow) && _anim.GetBool("check") == true)
        {
            _anim.SetBool("check", false);
            _anim.SetTrigger("left");
        }
        else if (Input.GetKey(KeyCode.DownArrow) && _anim.GetBool("check") == true)
        {
            _anim.SetBool("check", false);
            _anim.SetTrigger("down");
        }
        else if (Input.GetKey(KeyCode.UpArrow) && _anim.GetBool("check") == true)
        {
            _anim.SetBool("check", false);
            _anim.SetTrigger("up");
        }
        else if (Input.GetKey(KeyCode.RightArrow) && _anim.GetBool("check") == true)
        {
            _anim.SetBool("check", false);
            _anim.SetTrigger("right");
        }
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("left") && _anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.25f && !Input.GetKey(KeyCode.LeftArrow))
            _anim.SetBool("check", true);
        else if (_anim.GetCurrentAnimatorStateInfo(0).IsName("down") && _anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.25f && !Input.GetKey(KeyCode.DownArrow))
            _anim.SetBool("check", true);
        else if (_anim.GetCurrentAnimatorStateInfo(0).IsName("right") && _anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.25f && !Input.GetKey(KeyCode.RightArrow))
            _anim.SetBool("check", true);
        else if (_anim.GetCurrentAnimatorStateInfo(0).IsName("up") && _anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.25f && !Input.GetKey(KeyCode.UpArrow))
            _anim.SetBool("check", true);
        movement.x *= (float)0.1;
        movement.y *= (float)0.1;
        var moveX = Body.transform.position.x;
        var moveY = Body.transform.position.y;
        Body.transform.position = new Vector3(moveX + movement.x, moveY + movement.y, 0);
    }

    public void Update()
    {
        _anim.SetInteger("life", life);
        if (life <= 0)
            Body.position = fixPos;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Mine") && life > 0)
        {
            life -= 2;
            var mine = other.gameObject.GetComponent<Mine>();
            mine.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Wall") && !_hited)
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