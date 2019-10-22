using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This Script is an abstract class for a GroceryItem
 * Author Kate Howell
*/
public abstract class GroceryItem : MonoBehaviour
{
    public Transform accessSpot;
    public int price;
    public Stock Supply;
    public Stock Shelf;
}
