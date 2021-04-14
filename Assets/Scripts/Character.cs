using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*An object is the instance of a class. */
public class Character
{
    /*Creating an object from character class*/
    //First Character is the type. Second Character references the class. 
    
    //Character hero = new Character();

    public string name;

    /*All characters' experience begins in 0*/
    public int exp = 0;

    public int age = 0;

    //Add constructor

    public Character()
    {
        name = "Not assigned";
    }

    // public Character(string name)
    // {
    //     this.name = name;
    // }

    // public Character(string age)
    // {
    //     this.name = age;
    // }

    public Character(string name, int age, int exp)
    {
        this.name = name;
        this.age = age;
        this.exp = exp;
    }

    /*virtual keyword allows child classes to modify the method*/
    public virtual void PrintStats()
    {
        Debug.LogFormat("Hero: {0} - Age: {1} - Exp: {2}", name, age, exp);
    }

    private void Reset()
    {
        this.name  = "Not assigned";
        this.exp = 0;
    }
}  

/*Create Weapon Struct*/
 public struct Weapon
{
    public string  name;
    public int  damage;

    public Weapon(string name, int damage)
    {
        this.name = name;
        this.damage = damage;
    }


    public  void printWeaponStats()
    {
        Debug.LogFormat("Weapon: {0} - Damage: {1}", name, damage);
    }
}

