using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject customerPrefab;

    public Transform[] spawnPoints;

    public GameManger gM;
    
    
    // Start is called before the first frame update
    void Start()
    {
        gM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManger>();

        int randomSpawn = Random.Range(0, spawnPoints.Length - 1);

        Instantiate(customerPrefab, spawnPoints[randomSpawn].position, spawnPoints[randomSpawn].rotation);
        
        StartCoroutine(SpawnDelay());
    }

    IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(gM.customerSpawnDelay);

        int randomSpawn = Random.Range(0, spawnPoints.Length - 1);

        Instantiate(customerPrefab, spawnPoints[randomSpawn].position, spawnPoints[randomSpawn].rotation);

        StartCoroutine(SpawnCustomers());
    }


    IEnumerator SpawnCustomers()
    {
        yield return new WaitForSeconds(Random.Range(gM.minCustomerSpawnTime, gM.maxCustomerSpeed));

        int randomSpawn = Random.Range(0, spawnPoints.Length - 1);

        Instantiate(customerPrefab, spawnPoints[randomSpawn].position, spawnPoints[randomSpawn].rotation);

        StartCoroutine(SpawnCustomers());
    }
}
