using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class PlatformController : MonoBehaviour
{
    //Types of platforms
    public GameObject normalPlatform;
    public GameObject powerPlatform;
    public GameObject deathPlatform;

    private GameObject platform;

    public float currentY;
    private float offset;
    Vector3 topLeft;

    // Start is called before the first frame update
    void Start()
    {
        topLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        offset = 1.2f;
        
        GeneratePlatforms(50);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GeneratePlatforms(int num)
    {
        for (int i = 0; i < num; i++)
        {
            float distanceX = Random.Range(topLeft.x + offset, -topLeft.x - offset);
            float distanceY = Random.Range(2f,5f);

            currentY += distanceY;
            Vector3 platfornPos = new Vector3(distanceX, distanceY);
            int randonPlatform = Random.Range(1, 10);

            if (randonPlatform == 1)
            {
                platform = Instantiate(powerPlatform, platfornPos, Quaternion.identity);
            }
            else if (randonPlatform == 2)
            {
                platform = Instantiate(deathPlatform, platfornPos, Quaternion.identity);
            }
            else
            {
                platform = Instantiate(normalPlatform, platfornPos, Quaternion.identity);
            }
        }
    }
    
    
}
