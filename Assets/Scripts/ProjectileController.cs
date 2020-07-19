using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    //reference to projectiles body 
    Rigidbody2D myRB;
    public float fireSpeed;

    // Awake is called before the first frame update 
    void Awake()
    {
        myRB = GetComponent<Rigidbody2D>();
        if (transform.localRotation.z > 0)
        {
            //adds force to fire to propell forward
            myRB.AddForce(new Vector2(-1, 0) * fireSpeed, ForceMode2D.Impulse);
        }
        else
        {
            //adds force to fire to propell forward
            myRB.AddForce(new Vector2(1, 0) * fireSpeed, ForceMode2D.Impulse);
        }
    }

    public void RemoveForce()
    {
        myRB.velocity = new Vector2(0, 0);
    }
}
