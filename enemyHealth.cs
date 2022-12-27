using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{
    public float MaxHealth;
    float currentHealth;
   
    // bien de tao hieu ung khi enemy die
    // Start is called before the first frame update
    public GameObject enemyHealthEF;
    // khai bao cac bien de tao thanh mau cho enemy
    public Slider enemyHealthSlider;

    // khai bao cac bien de enemy chet se roi ra vien mau .
    public bool drop;
    public GameObject theDrop;
    void Start()
    {
        currentHealth = MaxHealth;
        enemyHealthSlider.maxValue = MaxHealth;
        enemyHealthSlider.value = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addDame(float damage)
    {
        enemyHealthSlider.gameObject.SetActive(true);
        currentHealth -= damage;
        enemyHealthSlider.value = currentHealth;
        
        if (currentHealth <= 0)
            makeDeal();

    }


    void makeDeal()
    {
        Destroy(gameObject);
       gameObject.SetActive(false);
        Instantiate(enemyHealthEF, transform.position, transform.rotation);
        //Chuc nang roi ra vien mau
        if(drop )
        {
            Instantiate(theDrop, transform.position, transform.rotation);
        }

    }
}
