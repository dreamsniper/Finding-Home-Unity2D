using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int coinValue = 1;
    public AudioClip pickedUpCoin;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(pickedUpCoin, transform.position);

            Destroy(gameObject);
            ScoreManager.instance.ChangeScore(coinValue);
        }
    }
}
