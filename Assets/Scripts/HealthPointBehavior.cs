using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPointBehavior : MonoBehaviour
{   
    public GameBehavior gameManager;

    void Start()
    {   
        /*Create variable that stores GameManager gameobject's script*/
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }
    /*When the collision happens, remove the health item*/

    /*This method includes a collision type argument */
    void OnCollisionEnter(Collision colission)
    {    
        /*The colission class has a gameobject type. It's referencing any gameobject. If the object is the player...*/
        if(colission.gameObject.name == "Player")
        {   
            /*Then destroy the prefab (The element this code is in is a child of a prefab )*/
            Destroy(this.transform.parent.gameObject);
        }

        /*Print that item was collected*/
        Debug.Log("Item collected!");

        /*Increment item count by one*/
        gameManager.Items += 1;
        gameManager.printLootReport();
    }
    
}
