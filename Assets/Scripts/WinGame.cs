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
        if (other.CompareTag("Player"))
        {
            haswon = true;
            PlayerHealth playerWins = other.gameObject.GetComponent<PlayerHealth>();
            playerWins.WinGame();
        }
    }
}
