using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Add Scene management 

/*Public so it can be accessed. It's static because it doesn't inherit from MonoBehaviour because it won't be in the scene*/
public static class Utilities 
{
    /*Public variable that holds times player has died*/
    public static int playerDeaths = 0;

    /*Method that takes ref as argument and returns a string*/
    public static string UpdateDeathCount(ref int countReference)
    {   
        /*Shows next number of current death count*/
        countReference += 1;
        return "Next time you'll be at number" + countReference;
    }

    /*RestartGame contains Restart Game logic*/
    public static void RestartGame()
    {   
        SceneManager.LoadScene(0);
        /*Set time to one*/
        Time.timeScale = 1.0f;

        /*Debugs player's deaths by passing playerDeaths as ref to uUpdateDeathCount*/
        Debug.Log("Player deaths: " + playerDeaths);
        string message = UpdateDeathCount(ref playerDeaths);
        Debug.Log("Player deaths: " + playerDeaths);
    }

    public static bool RestartGame(int scene_index)
    {   
        /*If scene index is negative then throw an exception*/
        if(scene_index < 0)
        {
            throw new System.ArgumentException("Scene index cannot be negative");
        }

        SceneManager.LoadScene(scene_index);
        /*Set time to one*/
        Time.timeScale = 1.0f;
        return true;
    }
}
