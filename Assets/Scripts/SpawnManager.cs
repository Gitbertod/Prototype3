using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private float timeSpawn = 1;
    private float repeatRate = 1;
    private PlayerController playerControllerScript;
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("spawnObstacles",timeSpawn, repeatRate);

    }

   
    void Update()
    {
        
    }

    void spawnObstacles() 
    {
        if (playerControllerScript.gameOver == false)
        Instantiate(obstaclePrefab, transform.position,transform.rotation);
    
    }
}
