using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class dieSlider : MonoBehaviour
{
    public Slider playerHealthSlide;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void addDamage(float damage)
    {
       

        if (playerHealthSlide.value <= 0)
            makeDead();
    }
    void makeDead()
    {
        Destroy(gameObject);
        Instantiate(playerHealthSlide, transform.position, transform.rotation);
        
    }
}
    

