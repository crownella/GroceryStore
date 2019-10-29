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
    
}
