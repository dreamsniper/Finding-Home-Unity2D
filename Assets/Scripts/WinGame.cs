using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    public bool haswon;

    private void Start()
    {
        haswon = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        haswon = true;

        if (other.CompareTag("Player"))
        {
            PlayerHealth playerWins = other.gameObject.GetComponent<PlayerHealth>();
            playerWins.WinGame();
        }
    }
}
