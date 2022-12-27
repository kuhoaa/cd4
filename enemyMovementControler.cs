using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovementControler : MonoBehaviour
{
    public float enemySpeed;
    Rigidbody2D enemyRB;
    Animator enemyAnim;
    // khai bao cac bien enemy
    public GameObject enemyGraphic;
    bool facingRight = true;
    float facingTime = 5f;
    float nextFlip = 0f;
    bool canFlip = true;
     void Awake()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponentInChildren<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time>nextFlip)
        {
            nextFlip = Time.time + facingTime;
            Flip();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (facingRight && other.transform.position.x < transform.position.x)
            {
                Flip();
            }
            else if (!facingRight && other.transform.position.x > transform.position.x)
            {
                Flip();
            }
            canFlip = false;
        }
    }
     void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag== "Player")
        {
            if (!facingRight)
            {
                enemyRB.AddForce(new Vector2(-1, 0) * enemySpeed);
            }
            else enemyRB.AddForce(new Vector2(1, 0) * enemySpeed);
            enemyAnim.SetBool("Run",true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            canFlip = true;
            enemyRB.velocity = new Vector2(0, 0);
            enemyAnim.SetBool("Run", false);
        }
    }
    void Flip()
    {
        if (!canFlip)
        
            return;
        
        facingRight = !facingRight;
        Vector3 theScale = enemyGraphic.transform.localScale;
        theScale.x *= -1;
        enemyGraphic.transform.localScale = theScale;
    }
}
