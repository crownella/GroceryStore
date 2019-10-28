using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This Script is a class for a Stock of a Grocery Item
 * Author Kate Howell
*/

public class Stock : MonoBehaviour
{
    public int stockMaxSize;
    public int currentStock;
    public Transform accessSpot;


    public void AddMore(int howManyToAdd, Inventory whoToTakeItFrom)
    {
        //if the stock is full
        if(currentStock + howManyToAdd > stockMaxSize)
        {
            //stock is set to max
            currentStock = stockMaxSize;

            //how many items couldnt be added
            int itemsLeft = (currentStock + howManyToAdd) - stockMaxSize;

            //remove the items that could be added from the staffs inventory, 
            whoToTakeItFrom.currentInventory -= howManyToAdd - itemsLeft;

            return;

        }

        //if the stock is not full

        currentStock += howManyToAdd;
        whoToTakeItFrom.currentInventory -= howManyToAdd;
  
    }

    public void Take(int howManyToTake, Inventory whoToGiveItTo)
    {
        
        
        //if there isnt enough stock to take
        if(currentStock < howManyToTake)
        {
            //if the staffs inventory can fit the current stock
            if(whoToGiveItTo.currentInventory + currentStock < whoToGiveItTo.inventoryMaxSize)
            {
                if (whoToGiveItTo is Cart)
                {
            
                }
                whoToGiveItTo.currentInventory += currentStock;
                currentStock = 0;
                return;
            }

            //if the staff cant take all of it
            //calcaute how much the staff can take
            int canTake = whoToGiveItTo.inventoryMaxSize - whoToGiveItTo.currentInventory;

            int stockAmount = currentStock - canTake; // amount that cant be taken

            currentStock = stockAmount;

            whoToGiveItTo.currentInventory = whoToGiveItTo.inventoryMaxSize;
            return;

        }

        //if the stock has enough to be taken

        //if the staff can take the amount they asked for
        if(whoToGiveItTo.currentInventory + howManyToTake < whoToGiveItTo.inventoryMaxSize)
        {
            whoToGiveItTo.currentInventory += howManyToTake;
            currentStock -= howManyToTake;
            return;
        }

        //if for some weird reason they cant 
        print("Staff Error");
    }
    
    //take method for customer 
    //return type is if method is successful
    public bool AddToCart(int howManyToTake, Cart whoToGiveItTo, GroceryItem itemToAdd)
    {
        //if theres an error an howmanytotake = 0
        if (howManyToTake == 0)
        {
            print("Error: Stock being asked to add 0 items to cart: " + whoToGiveItTo.gameObject.name);
        }
        
        //if stock is empty, this method fails
        if (currentStock < 1)
        {
            return false;
        }
        
        //if there isnt enough stock to take
        if(currentStock < howManyToTake)
        {
            currentStock = 0;
            for (int i = 0; i <= currentStock; i++)
            {
                //for the amount of current stock left, add that many of the item to add to the itemsInCart list
                whoToGiveItTo.itemInCart.Add(itemToAdd);
                return true;
            }

        }

        //if the stock has enough to be taken

        for (int i = 0; i <= howManyToTake; i++)
        {
            whoToGiveItTo.itemInCart.Add(itemToAdd);
            currentStock -= 1;
        }

        return true;
    }
}
