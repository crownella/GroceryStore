using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : Inventory
{
   public List<GroceryItem> itemInCart = new List<GroceryItem>();

   void Start()
   {
      inventoryMaxSize = 1000000; //cart capacity is unlimited
   }
}
