using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject customerPrefab;

    public Transform[] spawnPoints;
    
    
    // Start is called before the first frame update
    void Start()
    {
        int randomSpawn = Random.Range(0, spawnPoints.Length - 1);

        Instantiate(customerPrefab, spawnPoints[randomSpawn].position, spawnPoints[randomSpawn].rotation);
        
        StartCoroutine(SpawnCustomers());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator SpawnCustomers()
    {
        yield return new WaitForSeconds(Random.Range(0, 20));

        int randomSpawn = Random.Range(0, spawnPoints.Length - 1);

        Instantiate(customerPrefab, spawnPoints[randomSpawn].position, spawnPoints[randomSpawn].rotation);

        StartCoroutine(SpawnCustomers());
    }
}
