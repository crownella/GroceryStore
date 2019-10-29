using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOut : MonoBehaviour
{
    public List<GameObject> Customers = new List<GameObject>();
    public GameObject[] customerLocations;
    private int maxCapacity;
    public bool Occupied;

    private float _checkOutTimeMultiplier;


    
    // Start is called before the first frame update
    void Start()
    {
        GameManger gM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManger>();
        maxCapacity = customerLocations.Length;
        _checkOutTimeMultiplier = gM.checkOutTimeMultiplier;
    }

    private void Update()
    {
        if (!Occupied)
        {
            if (Top())
            {
                print("Take Next Customer " + Customers.Count);
                Occupied = true;
                StartCoroutine(CheckOutCart(Peek()));
            }
        }

        
       
    }

    IEnumerator CheckOutCart(Cart CustomerCart)
    {
        if (CustomerCart == null)
            throw new System.Exception("No Customer To Check Out");

        yield return new WaitForSeconds(CustomerCart.itemInCart.Count * _checkOutTimeMultiplier);

        print("Done Checking out " + Customers.Count);
        CustomerCart.positionInQueue = -1;
        CustomerCart.boughtAllItems = true;
        Occupied = false;
        Pop();
    }


    // Returns true if push is successful
    public bool Push(GameObject objectToAdd)
    {
        
        if (Customers.Count + 1 < maxCapacity)
        {
            objectToAdd.GetComponent<Cart>().positionInQueue = Customers.Count;
            Customers.Add(objectToAdd);
            print("Customer Added " + Customers.Count);
            return true;
        }
        

        return false;
    }

    // Returns cart if pop was successful, null if unsuccessful
    public Cart Pop()
    {
        
        if (Customers.Count > 0 && Customers[0] != null)
        {

            Cart cart = Customers[0].GetComponent<Cart>();

            if(cart == null)
                throw new System.Exception("Customer Missing Cart");


            Customers.RemoveAt(0);
            print("Pop " + Customers.Count);

            foreach(GameObject Customer in Customers)
            {
                Customer.GetComponent<Cart>().positionInQueue -= 1;
            }
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
        Cart givenCart = Customer.GetComponent<Cart>();
        if(givenCart == null)
        {
            throw new System.Exception("Cant Find Cart of Customer");
        }

        for(int i = 0; i < Customers.Count; i++)
        {
            Cart testCart = Customers[i].GetComponent<Cart>();
            

            if (testCart == null)
            {
                throw new System.Exception("Cant Find Cart of Customer");
            }
            if (givenCart == null)
            {
                throw new System.Exception("Cant Find Cart of Customer");
            }

            //if the carts are the same, treat them as the same customer
            if (testCart.itemInCart.Equals(givenCart.itemInCart))
            {
                return i;
            }
        }

        //not in list
        return -1;
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
