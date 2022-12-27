using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullletHitt : MonoBehaviour
{
    public float weaponDamage;
    projectileCotroler myPC;
    public GameObject bulletExplosion;
     void Awake()
    {   
        myPC = GetComponentInParent<projectileCotroler>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Shootable")
        {
            myPC.remveForce();
            Instantiate(bulletExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            if (other.gameObject.layer == LayerMask.NameToLayer("enemy"))
            {
                enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth>();
                hurtEnemy.addDame(weaponDamage);


            }
        }
    }
     void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Shootable")
        {
            myPC.remveForce();
            Instantiate(bulletExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            if (other.gameObject.layer == LayerMask.NameToLayer("enemy"))
            {
                enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth>();
                hurtEnemy.addDame(weaponDamage);


            }
        }
    }
}
