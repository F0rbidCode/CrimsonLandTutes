using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;

public class PlayerActor : MonoBehaviour
{
    //initialise the player controller variable
    private CharacterController controller;

    public float speed = 5.0f; //set the players movement speed

    // Start is called before the first frame update
    void Start()
    {
        //get the chacter controller from the object in the scene
        controller = gameObject.GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move_direction = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            move_direction.Set(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            move_direction.Set(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            move_direction.Set(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            move_direction.Set(1, 0, 0);
        }
        controller.Move(move_direction * Time.deltaTime * speed);


        ////////////////////////////////////////////
        ///Destroying an enemy
        /////////////////////////////////////////////
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouse_pos = Input.mousePosition; //get the mouse position

            Ray mouse_ray = Camera.main.ScreenPointToRay(mouse_pos); //use the current camera to cnver mouse position to a ray

            Plane player_plane = new Plane(Vector3.up, transform.position); //create a plane that faces the same position as the player

            float ray_distance = 0;
            player_plane.Raycast(mouse_ray, out ray_distance); //claculate the distance along the ray that the intersect occurs

            Vector3 cast_point = mouse_ray.GetPoint(ray_distance); //use the ray distance to calculate the point of collision

            Vector3 to_cast_point = cast_point - transform.position;
            to_cast_point.Normalize(); //get the vector in the direction to the point
            Ray fire_ray = new Ray(transform.position, to_cast_point); //cast a ray along that direction

            RaycastHit info;
            if (Input.GetMouseButtonDown(0) && Physics.Raycast(fire_ray, out info)) //if the ray hits a target
            {
                if (info.collider.tag == "Enemy") //check that the ray hits an enemy
                    Destroy(info.collider.gameObject); //destroy the target
            }
        }
        
    }
}
