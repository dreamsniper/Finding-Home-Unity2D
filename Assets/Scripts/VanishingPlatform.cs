using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishingPlatform : MonoBehaviour
{
    private PlatformEffector2D effector;
    float waitTime;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            waitTime = 1f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (waitTime <= 0)
            {
                spriteRenderer.color = new Color(129, 0, 255, .5f);
                effector.rotationalOffset = 180f;
                waitTime = 0.5f;
                StartCoroutine("ReappearingPlatform");
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    IEnumerator ReappearingPlatform()
    {
        yield return new WaitForSeconds(2f);
        spriteRenderer.color = new Color(129, 0, 255, 1f);
        effector.rotationalOffset = 0;
    }
}
