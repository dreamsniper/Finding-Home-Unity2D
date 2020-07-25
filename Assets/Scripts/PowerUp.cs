using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject pickupEffect;
    public float multiplier = 2f;
    public float duration = 10f;
    public AudioClip pickedUpPowerUp;

    AudioSource powerUpAS;

    void Start()
    {
        powerUpAS = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //checks to see if object entering collider is Player
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider2D player)
    {
        powerUpAS.clip = pickedUpPowerUp;
        powerUpAS.Play();

        //spawn a cool effect
        Instantiate(pickupEffect, transform.position, transform.rotation);

        //apply effect to player
        PlayerController power = player.GetComponent<PlayerController>();
        power.jumpHeight *= multiplier;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        //wait for time to end before effects run out
        yield return new WaitForSeconds(duration);

        //return stas back
        power.jumpHeight /= multiplier;

        //destroy object
        Destroy(gameObject);
    }
}
