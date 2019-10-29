using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public GroceryItem[] groceryItemsMaster; //all possible grocery items
    public Aisle[] aislesMaster; //all items in store
    public Transform[] exitPointsMaster; //all points a customer can go to leave
    public GameObject[] shoppingPathsMaster; //all possible shopping paths
    public CheckOut[] checkOutsMaster; //all possible check outs

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

    //Starting Stock
    public int startingStock;

    //check out
    public float checkOutTimeMultiplier = 2;

}
