using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IManagement
{
    string State {get; set;}
 
    void Initialize();

}

// /*Creates class with abstract keyword*/
// public abstract class BaseManager
// { 
// 	/*declare variable that can only be accessed my classes that inherit from BaseManager*/
// 	protected string state;
// 	/*Abstract string with get and set to be implemented by subclasses*/
// 	public abstract string state {get; set;}
// 	/*Method Implemented in subclass*/
// 	public abstract void Initialize();
// }



//  public class CombatManager: BaseManager 
//  {

//      public override string state
//      {
//          get { return _state; }
//          set { _state = value; }
//      }
 

//      public override void Initialize()
//      {
//          _state = "Manager initialized..";
//          Debug.Log(_state);
//      }
//  } 