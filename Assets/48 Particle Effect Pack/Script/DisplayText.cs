using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayText : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnGUI();
        }
    }

    void OnGUI()
    {
       
        GUI.Box(new Rect(10, 10, 150, 100), "Obtain The Flame to gain DoubleJump");
    }
}
