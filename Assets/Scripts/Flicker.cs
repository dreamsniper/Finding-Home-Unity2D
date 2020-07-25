using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Color flickerColor = Color.red;

    private Color startingColor = Color.white;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startingColor = spriteRenderer.color;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            StartCoroutine("FlickerAnimation");
        }
    }
    IEnumerator FlickerAnimation()
    {
        spriteRenderer.color = flickerColor;

        yield return new WaitForSeconds(0.05f);

        spriteRenderer.color = startingColor;
    }
}
