using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Declares namespace that holds all extensions*/
namespace CustomExtensions
{   
    /*Creates static class */
    public static class StringExtensions
    {   
     
        /*Adds static method to string extension class. This string class makes method an extension*/
        public static void FancyDebug(this string str)
        {   
            /*Prints string's length*/
            Debug.LogFormat("This string contains {0} characters", str.Length);
        }
    }

}
