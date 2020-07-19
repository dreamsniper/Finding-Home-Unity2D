using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //character at full health
    public float fullHealth;
    public GameObject deathFX;
    public AudioClip playerHurt;

    float currentHealth;

    public AudioClip playerDeathSound;
    AudioSource playerAS;

    public RestartGame theGamemanager;
    //HUD variables
    public Slider healthSlider;
    public Image damageScreen;
    public Text gameOverScreen;
    public Text winGameScreen;

    bool damaged = false;
    Color damagedColor = new Color(0f, 0f, 0f, .5f);
    readonly float smoothColor = 5f;

    //time variables
    public float speed = 8f;
    public float countdown = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = fullHealth;

        //HUD initialization
        healthSlider.maxValue = fullHealth;
        healthSlider.value = fullHealth;


        playerAS = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (damaged)
        {
            damageScreen.color = damagedColor;
        }
        else
        {
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, smoothColor * Time.deltaTime);
        }
        damaged = false;
    }

    public void AddDamage(float damage)
    {
        if (damage <= 0) return;
        currentHealth -= damage;

        playerAS.clip = playerHurt;
        playerAS.Play();

        healthSlider.value = currentHealth;
        damaged = true;

        if (currentHealth <= 0)
        {
            MakeDead();
        }
    }

    public void AddHealth(float healthAmount)
    {
        currentHealth += healthAmount;

        //make sure currenthealth is not more maxHealth
        if (currentHealth > fullHealth)
        {
            currentHealth = fullHealth;
        }
        healthSlider.value = currentHealth;
    }


    public void MakeDead()
    {
        NewMethod();

        StartCoroutine("WaitPeriod");

        theGamemanager.RestartTheGame();

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    private void NewMethod()
    {
        Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(playerDeathSound, transform.position);
        damageScreen.color = damagedColor;

        Animator gameOverAnimator = gameOverScreen.GetComponent<Animator>();
        gameOverAnimator.SetTrigger("gameOver");
    }

    public void WinGame()
    {
        //add particle burst later
        Destroy(gameObject);

        Animator winGameAnimator = winGameScreen.GetComponent<Animator>();
        winGameAnimator.SetTrigger("gameOver");

        //theGamemanager.restartTheGame();
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }

    IEnumerator WaitPeriod()
    {
        yield return new WaitForSeconds(4f);
    }
}
