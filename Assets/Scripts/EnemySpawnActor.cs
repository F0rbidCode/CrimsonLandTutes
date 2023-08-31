using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnActor : MonoBehaviour
{
    public GameObject enemy_prefab; //holds the prefeab for the enemy we want to spwan
    public float spawn_time; //seconds between spawns
    public float spawn_radius; //distance from the player to spawn

    private PlayerActor player; //referance to the player
    private float spawn_timer; //the timer that counts down to controle spawning

    // Start is called before the first frame update
    void Start()
    {
        spawn_timer = spawn_time; //set the spawn timer to equal the desired spawn time
        player = GameObject.FindObjectOfType<PlayerActor>(); //set the referance to the player to be the player object in scene
        
    }

    // Update is called once per frame
    void Update()
    {
        spawn_timer -= Time.deltaTime; //count down the timer each frame


        if (spawn_timer < 0) //when the spawn tiemr reaches 0
        {
            spawn_timer = spawn_time; //reset the spawn timer


            float spawn_angle = Random.Range(0, 2 * Mathf.PI);//Pick a random angle in radians to set a spawn point
            Vector3 spawn_direction = new Vector3(Mathf.Sin(spawn_angle), 0, Mathf.Cos(spawn_angle)); //calculate the direction to the spawn poitn as a vector
            spawn_direction *= spawn_radius;

            Vector3 spawn_point = player.transform.position + spawn_direction; //set the spawn point
            Instantiate(enemy_prefab, spawn_point, Quaternion.identity); //spawn the enemy at the location
        }       

    }
}
