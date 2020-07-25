using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FlameSoul : MonoBehaviour
{
    public GameObject pickupEffect;
    public AudioClip pickedUpPowerUp;
    private int doubleJumpValue;
    public bool hasFlameSoul = false;

    AudioSource powerUpAS;

    void Start()
    {
        powerUpAS = GetComponent<AudioSource>();
        doubleJumpValue = 1;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //checks to see if object entering collider is Player
        if (other.gameObject.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider2D player)
    {
        hasFlameSoul = true;
        AudioSource.PlayClipAtPoint(pickedUpPowerUp, transform.position);

        //spawn a cool effect
        Instantiate(pickupEffect, transform.position, transform.rotation);

        //apply effect to player
        PlayerController doubleJump = player.GetComponent<PlayerController>();
        doubleJump.extraJumpsValue += doubleJumpValue;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        //destroy object
        Destroy(gameObject);
    }
}
