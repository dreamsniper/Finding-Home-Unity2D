using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBox : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.GetComponent<PlayerController>()) ;
        {
            Destroy(gameObject);
        }
        
    }
}
