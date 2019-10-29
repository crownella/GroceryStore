using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : Inventory
{
   public List<GroceryItem> itemInCart = new List<GroceryItem>();
    public bool boughtAllItems;
    public int positionInQueue = -1;

   void Start()
   {
      inventoryMaxSize = 1000000; //cart capacity is unlimited
   }
}
