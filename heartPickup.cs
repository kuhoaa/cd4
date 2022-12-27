using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartPickup : MonoBehaviour
{
    public float healthAmount;
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
        if(other.tag=="Player")
        {
            PlayerHeath thePlayerHealth = other.gameObject.GetComponent<PlayerHeath>();
            thePlayerHealth.addHealth(healthAmount);
          
            Destroy(gameObject);
        }
    }
}
