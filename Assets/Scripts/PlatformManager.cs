using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager Instance = null;

    [SerializeField]
    GameObject platformPrefab;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;

        }else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(platformPrefab, new Vector2(5.22f, 4.53f), platformPrefab.transform.rotation);
        Instantiate(platformPrefab, new Vector2(12.56f, 5.29f), platformPrefab.transform.rotation);
        Instantiate(platformPrefab, new Vector2(19.27f, 5.29f), platformPrefab.transform.rotation);
        Instantiate(platformPrefab, new Vector2(26.19f, 5.29f), platformPrefab.transform.rotation);
    }

   IEnumerator SpawnPlatform(Vector2 spawnPosition)
    {
        yield return new WaitForSeconds(5f);
        Instantiate(platformPrefab, spawnPosition, platformPrefab.transform.rotation);
    }
}
