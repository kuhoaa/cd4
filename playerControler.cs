using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControler : MonoBehaviour
{
    public float maxSpeed;
    public float jumHieght;
    Rigidbody2D myBody;
    Animator myAnim;
    bool facingRight;
    bool grounded;
    // khai baso cac bien de ban
    public Transform gunTip;
    public GameObject bullet;
    float fireRate = 0.5f;
    float nextFire = 0;
    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        facingRight = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");

        myAnim.SetFloat("speed", Mathf.Abs(move));

        myBody.velocity = new Vector2(move * maxSpeed, myBody.velocity.y);
        if (move > 0 && !facingRight)
        {
            flip();
        }
        else if (move < 0 && facingRight)
        {
            flip();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                myBody.velocity = new Vector2(myBody.velocity.x, jumHieght);
            }
        }
        //Chuc nang ban tu ban phim
        if (Input.GetAxisRaw("Fire1") > 0)
            fireBulet();
    }
    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="Ground")
        {
            grounded = true;
        }
        if (other.collider.CompareTag("Chan"))
        {
            
            Application.LoadLevel("1");
        }
        if (other.collider.CompareTag("Chan2"))
        {

            Application.LoadLevel("2");
        }
        if (other.collider.CompareTag("Chan3"))
        {

            Application.LoadLevel("3");
        }
    }

    void fireBulet()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));

            }
            else if (!facingRight){
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180)));

            }

        }
    }
}
