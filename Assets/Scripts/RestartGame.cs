using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public float restartTime;
    bool restartNow = false;
    float resetTime;

    // Update is called once per frame
    void Update()
    {
        if (restartNow && resetTime <= Time.time)
        {
            //SceneManager.LoadScene(0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void RestartTheGame()
    {
        restartNow = true;
        resetTime = Time.time + restartTime;
    }
}
