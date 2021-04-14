using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningCurve : MonoBehaviour
{   
    public bool PureOfHeart = true;
    public bool hasSecretIncantation = false;
    public string item = "Life Orb";

    public int firstNum = 20;
    public int secondNum = 21;
    public int result;
    public int gold = 53;
    public int playerLives = 3;

    private Transform camTransform;

    /*Create two variables*/
    public GameObject directionLight; 
    private Transform lightTransform;
    

    //Longhand Initializer for arrays
    int [] topPlayerScores = new int[] {23, 220, 1500};


    //Shorthand Initializer for arrays
    //string [] Phrases = {"I like tacos", "WOOMY", "VEEMO"};
  
    void Start()
    {
        openChamber();
        //addNumbers(firstNum, secondNum);



        string decision = "Um, maybe next time...";
        int diceResult = 7;
        string [] Phrases = {"I like tacos", "WOOMY", "VEEMO"};
        int [] HighScores = {100, 200, 300, 1000};
        string catchy = Phrases[2];


        /*Create party members List*/
        List <string> questPartyMembers = new List<string>(){ "Agent 8", "Agent 3", "Marie", "Marina"};
        
        /*Add a member to Party members List*/
        questPartyMembers.Add("Octoling");
        List <int> scores = new List<int>(){50, 51, 20, 35, 120};

        Dictionary<string, int > weapons = new Dictionary<string, int>()
        {
            {"Aerospray PG", 3},
            {"Dapple Dualies", 2},
            {"Slosher", 5}
        };

        Dictionary<string, int> store = new Dictionary<string, int>()
        {
            {"Apple", 10},
            {"Longsome Raspberry", 500},
            {"Gold Fried Egg", 15},
            {"Blue sandwich", 100}
        };

        /*Add elemento to dictionary*/
        weapons.Add("Dualies", 50);

        /*Update dictionary key value pair*/
        weapons["Slosher"] = 10; 
        
        /*Make key value a variable*/
        int slosherNumber = weapons["Slosher"];

        int dualiesNumber = weapons["Dualies"];


        /*Remove element from dictionary*/
        weapons.Remove("Dualies");


        /*Update value*/
        if(weapons.ContainsKey("Slosher"))
        {
            weapons["Slosher"] = 90;
        }


        
        /*Add a member to party members List with a certain index*/
        questPartyMembers.Insert(1, "You");

        /*Removing element from List using index*/
        scores.RemoveAt(0); 

        /*Removing element from list using it's name*/
        scores.Remove(20);

        //Normal switch case 
        switch(decision)
        {
            case "Yes, I will go on a date with you!":
                Debug.Log("YAY!");
                break;
            
            case "Um, maybe next time...":
                Debug.Log("Oh...");
                break;
        }

        /*Fall through case. If you don't tyoe a condition don't add anything to it, it will automatically go to the next case statement. */
        switch(diceResult)
        {
            case 7:
            case 27:
                Debug.Log("Critical Hit!");
                break;
            case 28:
                Debug.Log("Too bad.");
                 break;
        }

        Debug.Log($"The catchy phrase is: {catchy}");
        Debug.LogFormat("Party members {0}", questPartyMembers.Count);

        foreach (int i in scores)
        {
            Debug.Log(i);
        }

        /*Print number of sloshers (Print Dictionary Key Value)*/
        Debug.LogFormat($"{slosherNumber}");
        Debug.LogFormat($"{dualiesNumber}");


        // for(int i = 0; i < questPartyMembers.Count; i++)
        // {
        //     Debug.LogFormat("Index: {0} -  {1}", i, questPartyMembers[i]);

        //     //If questPartyMembers[i] matches Marie print Hello There, Marie. 
        //     if(questPartyMembers[i] == "Marie")
        //     {
        //         Debug.Log("Hello there, Marie");
        //     }
        // }

        foreach(string partyMember in questPartyMembers)
        {
            Debug.LogFormat("Hello,{0}  ", partyMember);
        }

        //Print elements from dictionary usinf foreach
        foreach(KeyValuePair<string, int> kpv in weapons)
        {
            Debug.LogFormat("Weapon: {0} - Number: {1} ", kpv.Key, kpv.Value);
        }

        foreach (KeyValuePair<string, int> kpv in store)
        {
            if(gold < kpv.Value)
            {
                Debug.LogFormat("Item: {0}, Not enough gold coins!", kpv.Key);
            }
            else
            {
                Debug.LogFormat("Item: {0}, Can afford!", kpv.Key);
            }
        }

        /*We've specified a local variable of KeyValuePair, called kvp, 
        which is a common naming convention in programming like calling the for loop initializer i, 
        and set the key and value types to string and int to match store dictionary.*/
        foreach(KeyValuePair <string, int> kpv in store)
        {
            Debug.LogFormat("Item: {0} - Prize: {1}", kpv.Key, kpv.Value);

        } 


        /*Decrement playerlives value from 3 to 0.  While playerlives is greater than 0, print Alive. */
        while (playerLives > 0)
        {
            Debug.Log("Still Alive, dude!");
            playerLives--;
        }
        
        Debug.LogFormat("KO!");  


        // Character hero = new Character("Link", 34);
        // Debug.LogFormat("Character: {0} - Experience: {1}", hero.name, hero.exp);

        // Character heroine = new Character("Agatha", 14);
        // Debug.LogFormat("Heroine: {0} - Age: {1} - Experience: {2}", heroine.name, heroine.age, heroine.exp);

        Character hero = new Character("darkmario", 23, 1);
        hero.PrintStats();

        //Create variable equal it to hero. 
        Character hero2 = hero;

        hero2.name = "Kadam da bat";


        

        Character heroine = new Character("Cassandragon", 22, 2);
        heroine.PrintStats();

        Weapon epicBow = new Weapon("Epic Bow", 10);
        epicBow.printWeaponStats();

        Weapon regularBow = new Weapon("Woof Bow", 105);
        Weapon warBow = regularBow;

        regularBow.printWeaponStats();
        
        warBow.name = "Mop";
        warBow.damage = 200;
        warBow.printWeaponStats();
        
        /*Create instance of child class Knight that inherited from Character class*/
        Knight player1 = new Knight("Link", 20, 0, epicBow);
        player1.PrintStats();

        // Knight player2 = new Knight("Zelda", 19, 0, regularBow);
        // player2.PrintStats();

        camTransform = this.GetComponent<Transform>();
        Debug.Log(camTransform.localPosition);
        

        /*Find Game Object Directional Light without script being attached to it*/
        //directionLight = GameObject.Find("Directional Light");
        lightTransform = directionLight.GetComponent<Transform>();
        Debug.Log(lightTransform.localPosition);
    }  

    public void openChamber()
    {
        if(PureOfHeart == true && hasSecretIncantation == false)
        {
            Debug.Log("You are a true heroe!");
        }
        else if (PureOfHeart == true && hasSecretIncantation == true)
        {
            Debug.Log("Come back when you have completed all tasks");
        }
        else
        {
            Debug.Log("You haven't completed any task yet.");
        }

    }
 

    // public void addNumbers(int firstNumber, int secondNumber)
    // {
    //     result = firstNumber + secondNumber;
    //     Debug.Log($"Your result is: {result}");
    // }

    void Update()
    {
        
    }
   
}

 //Two slashes for commenting one line
    
    
    /*
        Slash and asterisk and asterisk and slash for commething several lines
    
    */

///  <summary> 
///Example
/// </summary>