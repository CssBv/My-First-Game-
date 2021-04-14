using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{   
    private float onscreenDelay = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, onscreenDelay);
    }
}
