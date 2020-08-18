using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionPoint : MonoBehaviour
{
    //public Transform waypoint;
    public GameObject portal;
    public GameObject player;
    private static bool justTeleported;

    private void Awake()
    {
        justTeleported = false;
    }
    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!justTeleported)
            {
                justTeleported = true;
                player.transform.position = new Vector2(portal.transform.position.x, portal.transform.position.y);
                yield return new WaitForSeconds(2f);
                justTeleported = true;

            }
        }
    }
    IEnumerator OnTriggerExit2D(Collider2D col)
    {
        if (justTeleported)
        {

            justTeleported = true;
            yield return new WaitForSeconds(2f);
            justTeleported = false;
        }

    }
}
