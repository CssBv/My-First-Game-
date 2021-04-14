using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{   
    /*Create Transform type variable named patrolRoute (For stoting patrolRoute empty parent)*/
    public Transform patrolRoute;

    /*Create transform typ list called locations. It will store all childs from patrolRoute*/
    public List<Transform> locations;

    /*Variable for tracking in what location enemies are currently in*/
    private int locationIndex = 0;

    /*Variable to sor NavMesh component that we dragged to nemy cgameobject*/
    private NavMeshAgent agent;

    public Transform player;

    /*Variable that stores enemy's lives*/
    private int lives = 3;

    /*Access variable to enemy's lives by get and set*/
    public int enemy_lives
    {   
        /*Get propert if lives count*/
        get{return lives;}

        private set
        {   
            /*Setting enemy's lives. If lives are 0 or less, destroy the eenemy gameobject*/
            lives = value;

            if(lives <= 0)
            {
                Destroy(this.gameObject);
                Debug.Log("Enemy Down.");
            }
        }
    }

    /*Variable that will store player's transform property value* /
    public Transform player;

    /*Whenever player gets close to enemy (enters enemy's radius)*/
    void OnTriggerEnter(Collider other)
    {   
        /*Accessing name of colliding object*/
        if(other.name == "Player")
        {
            Debug.Log("Found player! ATTACK!");

            /*If the player gets close, chase them*/
            agent.destination = player.position;
        }
    }

    /*Initialize  Patrol Route*/
    void Start()
    {   
        /*Uses GetComponent to get the NavMesh component of enemy gameobject*/
        agent = GetComponent<NavMeshAgent>();

        /*Return reference from Player*/
        player = GameObject.Find("Player").transform;

        /*Initialize route*/
        InitializePatrolRoute();
        MoveToNextLocation();
    }

    void InitializePatrolRoute()
    {
        /*For each child in patroRoute, add a child in locations*/
        foreach(Transform child in patrolRoute)
        {   
            /*Add each child to locations list*/
            locations.Add(child);
        }
    }

    void Update()
    {   
        /*remainingDistance returns how far the NavMeshAgent component currently is from its set destination
        pathPending returns a true or false Boolean, depending on whether Unity is computing a path for the NavMeshAgent component.
        If the agent is very close to its destination, and no other path is being computed, the if statement returns true and calls MoveToNextPatrolLocation()*/
        if(agent.remainingDistance < 0.2f && !agent.pathPending)
        {
            MoveToNextLocation();
        }
    }

    void MoveToNextLocation()
    {   
        /*If locations is empty, we use the return keyword to exit the method without continuing*/
        if(locations.Count == 0)
        {
            return;
        }

        /*destination is a Vector3  position in 3D Space. locations[LocationIndex* grabs the transform item in location at a given index. Adding position references
        the Transform component's vector 3 position*/
        agent.destination = locations[locationIndex].position;
        
        /*Dividing an index by the maximum number of items in a collection is a quick way to always find the next item. */
        locationIndex = (locationIndex + 1) % locations.Count;
    }
    
    /*When player leaves the enemy's rssasdius*/
    void OnTriggerExit(Collider other)
    {
        Debug.Log("Player left. Resume patrol!");
    }

    /*If bullets (clones) collision with enemy, decrease enemy's lives by one. Unity adds clone name to instances of a gameobject */
    void OnCollisionEnter(Collision collision)
    {   
        
        if(collision.gameObject.name == "Bullet(Clone)")
        {
            enemy_lives -= 1;
            Debug.Log("Critical Hit");
        }
    }
}
