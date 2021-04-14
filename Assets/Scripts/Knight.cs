using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Creates class child of Character class*/

public class Knight: Character

{   
    public Weapon weapon;
    /*Declare Base Constructor --> Takes constructor from character class*/
    public Knight (string name, int age, int exp, Weapon weapon): base(name, age, exp)
    {
        this.weapon = weapon;
    }

    /*Method from parent class can be modified with override keyword*/
    public override void PrintStats()
    {
        Debug.LogFormat("Hail {0}, Your age is: {1}, Your experience is: {2}, Take up your {3}", name, age, exp, weapon.name);
    }
    
    
}