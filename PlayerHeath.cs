using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeath : MonoBehaviour
{
    public float maxHealth;
    float curentHeath;

    public GameObject bloodEffect;

    // khai bao bien UI
    public Slider playerHealthSlide;
    // Start is called before the first frame update
    void Start()
    {
        curentHeath = maxHealth;
        playerHealthSlide.maxValue = maxHealth;
        playerHealthSlide.value = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void addDamage(float damage)
    {
        if (damage <= 0)
            return;
        curentHeath -= damage;
        playerHealthSlide.value = curentHeath;
        if (curentHeath <= 0)
            makeDead();
    }

    // Tao chuc nang hoi mau khi an hp
    public void addHealth(float healthAmount)
    {
        curentHeath += healthAmount;
        if (curentHeath > maxHealth)

            curentHeath = maxHealth;
        playerHealthSlide.value = curentHeath;

    }
    void makeDead()
    {
        Instantiate(bloodEffect, transform.position, transform.rotation);
        
        Destroy(gameObject);
        Application.LoadLevel("1");


    } 
}
