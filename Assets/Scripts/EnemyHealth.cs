using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float enemyMaxHealth;
    public GameObject enemyDeathFX;
    public Slider enemySlider;

    public bool drops;
    public GameObject theDrop;


    float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = enemyMaxHealth;
        enemySlider.maxValue = currentHealth;
        enemySlider.value = currentHealth;

    }

    //allows objects to change health of enemy
    public void AddDamage(float damage)
    {
        enemySlider.gameObject.SetActive(true);
        currentHealth -= damage;
        enemySlider.value = currentHealth;


        if (currentHealth <= 0)
        {
            MakeDead();
        }
    }

    void MakeDead()
    {
        Destroy(gameObject);
        Instantiate(enemyDeathFX, transform.position, transform.rotation);
        if (drops)
        {
            Instantiate(theDrop, transform.position, transform.rotation);
        }
    }
}
