using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class JumpOrb : MonoBehaviour
{
    private bool jumpOrbActive;
    private float enableTimer;
    private SpriteRenderer spriteRenderer;
    public GameObject orbEffect;
    public AudioClip jumpedOnOrb;
    public AudioClip flameEffect;

    private void Awake()
    {
        jumpOrbActive = true;
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

        if (!jumpOrbActive)
        {
            enableTimer -= Time.deltaTime;
            if (enableTimer < 0)
            {
                jumpOrbActive = true;
                spriteRenderer.color = new Color(129, 0, 255, 1f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerController player = collider.gameObject.GetComponent<PlayerController>();
        Instantiate(orbEffect, transform.position, transform.rotation);
        if (jumpOrbActive && player != null)
        {
            //spawn a cool effect
            AudioSource.PlayClipAtPoint(jumpedOnOrb, transform.position);
            AudioSource.PlayClipAtPoint(flameEffect, transform.position);
            jumpOrbActive = false;
            enableTimer = 5f;
            spriteRenderer.color = new Color(129, 0, 255, .5f);
            player.TouchedJumpOrb();
        }
    }
}
