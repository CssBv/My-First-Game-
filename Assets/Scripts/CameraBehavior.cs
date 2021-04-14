using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour 
{   
    /*Distance between camera and player*/
    public Vector3 camOffset = new Vector3(0f, 1f, -9f);

    /*Creates transform variable*/
    private Transform target;

    void Start()
    {
        /*Finds Player 3d object and retrieves it's transform information. This means player's position and stored in target variable*/
        target =  GameObject.Find("Player").transform;
    } 
    /*LateUpdate method has to execute after Update: Updates target's last position*/
    void LateUpdate()
    {   
        /*The TransformPoint method calculates and returns a relative position in the world space.*/
        transform.position = target.TransformPoint(camOffset);

        /*The LookAt method updates the capsule's rotation every frame, focusing on the Transform parameter we pass in, which, in this case, is the target:
        Rotates the transform so the forward vector points at /target/'s current position.*/
        transform.LookAt(target);
    }
}