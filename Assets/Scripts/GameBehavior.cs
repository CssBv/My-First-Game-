using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using CustomExtensions;

/*Adopts IManagement Interface*/
public class GameBehavior : MonoBehaviour, IManagement
{   
    /*Private variable that is back of State*/
    private string state;

    public Stack<string> lootStack = new Stack<string>();

    /*Create delegate that holds method that receives text and returns void*/
    public delegate void DebugDelegate(string newText);

    /*Create instance of DebugDelegate named debug. */
    public DebugDelegate debug = Print;

    /*Public variable declared in IManager with set and get*/
    public string State
    {
        get{return state;}

        set{state = value;}
    }

    void Start()
    {
        Initialize();

        /*Create an instance of Inventory List Class*/
        InventoryList<string> inventoryList= new InventoryList<string>(); 

        /*Try with an integer list*/
        //InventoryList<int> itemsNumber = new InventoryList<int>();

        inventoryList.setItem("Potion");
        //itemsNumber.setItem(53);

        /*TESTING with ints*/
        //Debug.Log(inventoryList.item);
        //Debug.Log(itemsNumber.item);

    }

    public void Initialize()
    {   
        /*Sets state*/
        state = "Manager initialized";
        state.FancyDebug();
        /*Prints state*/
        debug(state); 
        /*Calls LogWithDelegate and passes debug variable*/
        LogWithDelegate(debug);

        lootStack.Push("Sword of doom");
        lootStack.Push("HP+");
        lootStack.Push("Plastic Sword");
        lootStack.Push("Enchanted bunny");

        /*Empty stack*/
        //lootStack.Clear();

        GameObject player = GameObject.Find("Player");

        PlayerBehavior playerBehavior = player.GetComponent<PlayerBehavior>();

        playerBehavior.playerJump += HandlePlayerJump;

    }

    public void HandlePlayerJump()
    {
        Debug.Log("Player has jumped");
    }

    /*Declares print as a static method that takes a string*/
    public static void Print(string newText)
    {
        Debug.Log(newText);
    }

    /*Declares method that takes DebugDelegate Type. It cant take a method as an argument*/
    public void LogWithDelegate(DebugDelegate del)
    {
        del("Delegating the debug task...");
    }

    public void printLootReport()
    {   
        /*Removes Enchanted Bunny and stores it in current_item*/
        var current_item = lootStack.Pop();
        /*Stores next item after Enchanted bunny and prints it. Stores next item of a stack*/
        var next_item = lootStack.Peek();
        
        /*Know if an element exists in the stack. Returns a true value if it's there*/
        //var itemFound = lootStack.Contains("HP+");

        // if(itemFound)
        // {
        //     Debug.Log("You've collected HP+");
        // }

        //Debug.Log(itemFound);
        
        /*Copying stack elements to an array*/
        //string [] copiedLoot = new string[lootStack.Count];

        /*Giving the array a starting index*/
        //numbers.CopyTo(copiedLoot, 0);

        /*Convert stack to array*/
        //lootStack.ToArray();

        /*Returns a string representing the stack object*/
        //lookStack.ToString();

        Debug.LogFormat("You got a {0}. Maybe next time you'll catch a {1}", current_item, next_item);
    }

    public string labelText = "Collect the four items and win your freedom!";
    
    /*Variable for max Items. Const keyword means the variable's never is going to change*/
    public readonly int maxItems = 4;

    /*Flag for showing winning screen*/
    public bool WinScreen = false;


    /*Flag for showing lose wcreen*/
    public bool LoseScreen = false;


    /*Private variable that holds number of objects collected by player*/
    private int collected_items = 0;


    /*Updates screen by receiving as arguments message and screen. Called in player's health calculation and also number of collected items*/
    private void UpdateValues(string message , bool screen)
    {   
        labelText = message;
        screen = true;
        Time.timeScale = 0f;
    }
        
    // }
   
   /*Create variable with set and get properties*/
    public int Items
    {   
        /*Return value of collected items everytime are Items are accesed by an outside class*/
        get{return collected_items; }

        /*Use set property to update collected items values whenever its updated */
        set
        {   collected_items = value;

            /*If collected items is higher than maxItems then print (update labelText)....*/
            if(collected_items >= maxItems)
            {   
                UpdateValues("You collected all items!", WinScreen);
            }

            else
            {
                labelText = "Item found! Only " + (maxItems - collected_items + " " +  "more to go!");
            }

            /*Print the modified value*/
            Debug.LogFormat("Items collected: {0}", collected_items);
        }
    }

     /*Private variable that holds player's health*/
    private int playerHP = 10;

    /*Set variable named hP for backing up player's HP*/
    public int HP
    {
        get{return playerHP;}

        set
        {
            playerHP = value;

            /*Set conditions dictates that if lives are 0 or less, loseScreen is true. */
            if(playerHP <= 0)
            {
                // labelText = "You died!";
                // LoseScreen = true;
                // Time.timeScale = 0;
                UpdateValues("You died!", LoseScreen);
            }
            else
            {
                labelText = "OUCH!";
            }
        }
    }
    
    /*ONGUI method to house UI Code*/
    void OnGUI()
    {   
        /*Call GUI class and Box method.  Rectangle class takes x, y, width and height*/
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health:" + playerHP);

        GUI.Box(new Rect(20, 50, 150, 25), "Items collected: " + collected_items);

        /*GUI Label to place labelText. Screen class and width and height properties give you absolute values. Print in the middle of screen*/
        GUI.Label(new Rect(Screen.width /2 - 100, Screen.height - 50,300, 50), labelText);

        /*If winScreen is true display the following button*/
        if(WinScreen)
        {
            /*Place it inside an if so it's inside can be executed when its clicked. It's value is true when it's clicked*/
            if(GUI.Button(new Rect(Screen.width /2- 100, Screen.height /2 - 50, 200, 100), "You WON"))
            {   
                /*Calls Utilities class and RestartGame method*/
                Utilities.RestartGame(0);
            }
        }

        /*If loseScreen is true then */
        if(LoseScreen)
        {   /*Button with You LOST message appears. If user clicks it, it restarts the game*/
            if(GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "You LOST!"))
            {   
                try
                {   
                    /*MEthod that might cause an exception*/
                    Utilities.RestartGame(-1);
                    debug("Level Succesfully");
                }
                /*catch includes a System.ArgumentException  type that is going to handle the variable named e*/
                catch(System.ArgumentException e)
                {   
                    /*Restarts the game if exception is thrown */
                    Utilities.RestartGame(0);
                    /*Prints costumized message and adds what the exception returns by using toString method*/
                    debug("Reverting to scene 0" + e.ToString());
                }
                finally
                {
                    debug("End of exception handling code. Restart Handled!");
                }
            }
        }
    }
} 

