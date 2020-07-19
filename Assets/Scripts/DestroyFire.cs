using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFire : MonoBehaviour
{
    public float aliveTime;

    // Awake is called before the first frame update
    void Awake()
    {
        //destroys fire from scene and refreshes memory
        Destroy(gameObject, aliveTime);
    }
}
