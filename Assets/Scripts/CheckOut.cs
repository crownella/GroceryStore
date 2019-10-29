using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOut : MonoBehaviour
{
    public List<GameObject> Customers = new List<GameObject>();
    public GameObject[] customerLocations;
    public int maxCapacity;


    
    // Start is called before the first frame update
    void Start()
    {
        maxCapacity = customerLocations.Length;
    }


    // Returns true if push is successful
    public bool Push(GameObject objectToAdd)
    {
        if(Customers.Count + 1 < maxCapacity)
        {
            Customers.Add(objectToAdd);
            return true;
        }

        return false;
    }

    // Returns true if pop was successful
    public bool Pop()
    {
        if(Customers.Count > 0)
        {
            Customers.RemoveAt(0);
            return true;
        }

        return false;
    }


}
