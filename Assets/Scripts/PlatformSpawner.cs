using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    public float distanceBetweenPlatforms = 2f;
    public static float platformHeight = 2f;
    public float playerHeight;
    public float increaseDistance = 0.01f;

    private Queue<GameObject> platformQueue = new Queue<GameObject>();
    public GameObject platform;
    public GameObject player;
    public Camera gameCamera;

    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject _generatedPlatform = GeneratePlatform();
            platformQueue.Enqueue(_generatedPlatform);
        }
    }

    void Update()
    {
        if (platformHeight - player.transform.position.y <= 15f)
        {
            RepositionPlatform();
            if (distanceBetweenPlatforms < 10f)
                distanceBetweenPlatforms += increaseDistance;
        }
    }

    GameObject GeneratePlatform()
    {
        GameObject newPlatform = Instantiate(platform, new Vector3((Random.value * 12f) - 6f, platformHeight, 0f), Quaternion.identity);
        platformHeight += distanceBetweenPlatforms;
        return newPlatform;
    }

    void RepositionPlatform()
    {
        if (gameCamera.transform.position.y > platformHeight - 20f)
        {
            GameObject _poppedPlatform = platformQueue.Dequeue();
            _poppedPlatform.transform.position = new Vector3((Random.value * 12f) - 6f, platformHeight, 0f);
            platformQueue.Enqueue(_poppedPlatform);
            platformHeight += distanceBetweenPlatforms;
        }
    }
}


