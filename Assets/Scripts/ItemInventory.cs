using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Declares generic class named Inventory List*/
/*If we wanted to make this class to only accept class types then check next comment:*/
public class InventoryList<T> //where T: class
{   
    /*Creates private item with generic type*/
    private T _item;

    /*Public item property with private backing variable*/
    public T item
    {
        get {return _item; }
    }

    public void initializeInventory()
    {
        Debug.Log("Initialized Generic List...");
    }

    /*Method that sets item that is passed as a generic argument, so it can take any type you want*/
    public void setItem(T newItem)
    {   
        /*Back variable equals to generic assigned argumnt*/
        _item = newItem;
        Debug.Log("New item added");
    }
}