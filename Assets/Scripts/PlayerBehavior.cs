using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{   

    /*Create a delegate that returns void*/
    public delegate void JumpingEvent();

    /*Create event of JumpEventTime named playerJump. Playerjump can be treated as a method*/
    public event JumpingEvent playerJump;

    /*How fast moves Fordward and backward*/
    public float moveSpeed = 10f;

    /*How fast player rotates left and right*/
    public float rotateSpeed = 75f;

    //public string message = "Pikachupi";

    /*New variable that stores applied force for the jump*/
    public float jumpVelocity = 5f;

    /*Vertical axis input*/
    private float verticalInput;

    /*Horizontal axis input*/
    private float horizontalInput;

    /*Distance between player and ground*/
    public float distanceToGround = 0.1f;

    /*Variable to store gameManager */
    private GameBehavior game_manager;

    /*Layer mask variable for collider detection*/
    public LayerMask groundLayer;

    /*Create Bullet GameObject*/
    public GameObject bullet;

    /*Setting bullet speed*/
    public float bulletSpeed = 100f;

    /*Create a rigidbody type variable*/
    private Rigidbody rb;

    /*Variable for storing player*/
    private CapsuleCollider col;

    void Start()
    {   
        /*Start method Fires what is initialized when you click play*/
        /*GetComponent method checks whether the component type (Rigibody in this case) is in the gameobject*/
        rb = GetComponent<Rigidbody>();

        /*Find and return collider of the player*/
        col = GetComponent<CapsuleCollider>();

        /*Variable Stores gamebehaviour instance from gameManager gameobject*/
        game_manager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }

    void Update()
    {   
        /*Detects up or down keys and multiplies values by how fast the player moves forward and backwards*/
        verticalInput = Input.GetAxis("Vertical") * moveSpeed;

        /*Detects player's rotation and multiplies values by how fast the player rotates*/
        horizontalInput = Input.GetAxis("Horizontal") * rotateSpeed;

        /* Vector3.forward multiplied by verticalInput and Time.deltaTime supplies the direction and speed the capsule 
        needs to move forward or back along the z axis at the speed we've calculated.
        */
        //this.transform.Translate(Vector3.forward * verticalInput * Time.deltaTime);

        /*Uses the Rotate method to rotate the capsule's Transform component relative to the vector we pass in as a parameter*/
        //this.transform.Rotate(Vector3.up * horizontalInput * Time.deltaTime);
    }

    /*Any rigidbody code always goes in fixedUpdate method. FixedUpdate is used for all physics code*/
    void FixedUpdate()
    {   
        /*Rotation Vector*/
        Vector3 rotation = Vector3.up * horizontalInput;

        /*To use rotation method we have to use a quaternion value. Returns euler angles*/
        Quaternion angle_rotation = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        /*Player's transform position is multiplied by vertical inputs. Move Position method applies force. */
        rb.MovePosition(this.transform.position + this.transform.forward * verticalInput * Time.fixedDeltaTime);

        /*multiply angle rot (user input by rigibody rotation to get left and right rotation*/
        rb.MoveRotation(rb.rotation * angle_rotation);

        /*If space bar is pressed down*/
        if(isGrounded() && Input.GetKeyDown(KeyCode.Space))
        {       
            /*Add as arguments vector up, jump velocity and forcemode. We specify that applied force will be up with the velocity we set and 
            Forcemode.Impulse delivers and instant force to an object while taking it mass into account*/
            rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
            

            /*PlayerJump is called when force is applied to player (When player jumps).*/
            playerJump();
        }
        
        /*If left mouse button is pressed (0)...*/
        if(Input.GetMouseButtonDown(0))
        {   
            /*Assign instance of bullet prefab to newBullet, We put the bullets in front of the player to avoid collisions. We cast the result to the same type of newbullet.
            This method takes 4 arguments:
            -original object
            -position
            -orientation
            -parent*/
            GameObject newBullet = Instantiate(bullet, this.transform.position + new Vector3(1, 0, 0), this.transform.rotation) as GameObject;

            /*We store newBullets rigidbody in bulletRB */
            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();

            /*We set velocity */
            bulletRB.velocity = this.transform.forward * bulletSpeed;
        }
    }


    /*Method isgrounded with a return bool type*/
    private bool isGrounded()
    {   
        /*Local vector3 variable to store the position at the bottom of capsule collider. All collider componentes have a bounds property
        The bottom of the collider is the 3D point at center x, min y and center z*/
        Vector3 capsuleBottom = new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z);

        /*Create a local bool type variable that will store the valu from checkcapsule method from physics class.
        
        It takes the following five arguments:  Start, End, Radius, LayerMask, The layer mask we want to check collisions to is groundLayer,  QueryTriggerAction (Ignore colliders that are triggers)*/
        bool grounded = Physics.CheckCapsule(col.bounds.center, capsuleBottom, distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);

        return grounded;
    }

    /**/
    void OnCollisionEnter(Collision collision)
    {   
        /*If collision between enemy object and player is detected, decrease player's heath by one* by using setter property HP*/
        if(collision.gameObject.name == "Enemy")
        {
            game_manager.HP -= 1;
        }
    }

}