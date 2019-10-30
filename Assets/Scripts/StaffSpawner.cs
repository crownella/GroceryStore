using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffSpawner : MonoBehaviour
{
    public GameObject staffPrefab;

    public Transform[] spawnPoints;

    private GameManger gM;


    // Start is called before the first frame update
    void Start()
    {
        gM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManger>();

        for(int i =0; i < gM.numberOfStaff; i++)
        {
            int randomSpawn = Random.Range(0, spawnPoints.Length - 1);
            Instantiate(staffPrefab, spawnPoints[randomSpawn].position, spawnPoints[randomSpawn].rotation);
        }

    }

}
