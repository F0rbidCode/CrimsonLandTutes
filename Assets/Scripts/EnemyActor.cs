using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActor : MonoBehaviour
{
    private PlayerActor player; //store a referance to the target (player)
    public float Speed = 4.0f; //the movement speed of the enemy

    private Vector3 toTarget;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerActor>();
    }

    // Update is called once per frame
    void Update()
    {
        //calculate the vector to the player
        toTarget = player.transform.position - this.transform.position;
        toTarget = toTarget.normalized;
        //move the enemy towards the target
        this.transform.position += toTarget * Time.deltaTime * Speed;
        
        
    }
}
