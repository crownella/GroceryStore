using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    public GroceryItem[] groceryItemsMaster; //all possible grocery items
    public Aisle[] aislesMaster; //all items in store
    public Transform[] exitPointsMaster; //all points a customer can go to leave
    public GameObject[] shoppingPathsMaster; //all possible shopping paths
    public GameObject[] staffPathsMaster; //all possible staff paths
    public CheckOut[] checkOutsMaster; //all possible check outs
    public Stock[] allShelves;


    //score
    public Image[] Stars;
    public int score = 30;
    public int scoreIncrease;
    public int scoreDecrease;


    //Customer Spawner
    public float customerSpawnDelay;
    public float minCustomerSpawnTime;
    public float maxCustomerSpawnTime;

    //Customer
    public int maxShoppingListSize;
    public int minShoppingListSize;
    public int minConfusion;
    public int MaxConfusion;
    public int minCustomerSpeed;
    public int maxCustomerSpeed;

    //Staff Spawner
    public int numberOfStaff;

    //Staff
    public int minStaffSpeed;
    public int maxStaffSpeed;
    public int minShelfStockAcceptable;

    //Starting Shelf Stock
    public int startingShelfStock;
    public int shelfStockMaxSize;

    //check out
    public float checkOutTimeMultiplier = 2;

    
    

    public void Awake()
    {
        //set intial stock
        foreach(Stock shelf in allShelves)
        {
            shelf.stockMaxSize = shelfStockMaxSize;
            shelf.currentStock = startingShelfStock;
        }
    }

    public void Update()
    {

        if (score >= 50)
        {
            for(int i =0; i < 5; i++)
            {
                Stars[i].enabled = true;
            }
        }
        else if(score >= 40)
        {
            for (int i = 0; i < 5; i++)
            {
                if(i > 3)
                {
                    Stars[i].enabled = false;
                }
                else
                {
                    Stars[i].enabled = true;
                } 
            }
        }
        else if (score >= 30)
        {
            for (int i = 0; i < 5; i++)
            {
                if (i > 2)
                {
                    Stars[i].enabled = false;
                }
                else
                {
                    Stars[i].enabled = true;
                }
            }
        }
        else if (score >= 20)
        {
            for (int i = 0; i < 5; i++)
            {
                if (i > 1)
                {
                    Stars[i].enabled = false;
                }
                else
                {
                    Stars[i].enabled = true;
                }
            }
        }
        else if (score >= 10)
        {
            for (int i = 0; i < 5; i++)
            {
                if (i > 0)
                {
                    Stars[i].enabled = false;
                }
                else
                {
                    Stars[i].enabled = true;
                }
            }
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                Stars[i].enabled = false;
            }
        }
    }

}
