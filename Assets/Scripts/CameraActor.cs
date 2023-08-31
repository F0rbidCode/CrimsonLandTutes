using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraActor : MonoBehaviour
{
    public Transform target; //store a referance to the target (player)

    private Vector3 boom; //used to controle the distance between the player and the camera

    // Start is called before the first frame update
    void Start()
    {
        //Get the vector from the target to the player
        boom = this.transform.position - target.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Set our position to be the same relative to the player
        Vector3 target_pos = target.position + boom;
        this.transform.position = target_pos;
    }
}
