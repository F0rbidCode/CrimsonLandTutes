using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileActor : MonoBehaviour
{
    public float speed; //sets the speed the projectile will travel at
    public Vector3 direction; //sets the direction of travel
    public float Lifetime; //sets the desired life time of the projectile

    // Start is called before the first frame update
    void Start()
    {
        direction = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime; //move the projectile allong its path at its set speed

        Lifetime-= Time.deltaTime; //reduce the lifetime by the elapesed time
        if(Lifetime < 0 ) //when the lifetime reaches 0
        {
            Destroy(gameObject); //destroy the projectile
        }
    }

    //to be called when projectile collides with an enemy
    private void OnCollisionEnter(Collision hit)
    {
        if (hit.collider.tag == "Enemy") //check if the collision was with an enemy
        {
            Destroy(hit.collider.gameObject); //destry the collided with object
        }
        Destroy(gameObject); //destroy the projectile
    }
}
