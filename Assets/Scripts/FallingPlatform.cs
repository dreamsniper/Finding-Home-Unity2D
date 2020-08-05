using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Rigidbody2D myRB;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();

            if (player.grounded)
            {
                PlatformManager.Instance.StartCoroutine("SpawnPlatform", new Vector2(transform.position.x, transform.position.y));
                Invoke("DropPlatform", 0.5f);
                Destroy(gameObject, 2f);
            }
        }
    }
     
    void DropPlatform()
    {
        myRB.isKinematic = false;
    }
}
