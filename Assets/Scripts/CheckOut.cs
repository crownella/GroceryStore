using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOut : MonoBehaviour
{
    public List<GameObject> Customers = new List<GameObject>();
    public GameObject[] customerLocations;
    private int maxCapacity;
    public bool Occupied;


    
    // Start is called before the first frame update
    void Start()
    {
        maxCapacity = customerLocations.Length;
    }

    private void Update()
    {
        if (!Occupied)
        {
            if (Top())
            {
                Occupied = true;
                StartCoroutine(CheckOutCart(Peek()));
            }
        }

       
    }

    IEnumerator CheckOutCart(Cart CustomerCart)
    {
        if (CustomerCart == null)
            throw new System.Exception("No Customer To Check Out");

        yield return new WaitForSeconds(CustomerCart.itemInCart.Count);

        Occupied = false;
        Pop();
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

    // Returns cart if pop was successful, null if unsuccessful
    public Cart Pop()
    {
        if(Customers.Count > 0 && Customers[0] != null)
        {

            Cart cart = Customers[0].GetComponent<Cart>();

            if(cart == null)
                throw new System.Exception("Customer Missing Cart");

            Customers.RemoveAt(0);
            return cart;
        }

        return null;
    }

    // Returns true if list has a first element
    public bool Top()
    {
        if (Customers.Count > 0 && Customers[0] != null)
        {
            return true;
        }

        return false;
    }

    //gets the index of a given customer
    public int getIndex(GameObject Customer)
    {
        return Customers.IndexOf(Customer);
    }

    public Cart Peek()
    {
        if (Customers.Count > 0 && Customers[0] != null)
        {
            Cart cart = Customers[0].GetComponent<Cart>();
            if (cart == null)
                throw new System.Exception("Customer Missing Cart");
            return cart;
        }

        return null;
    }




}
