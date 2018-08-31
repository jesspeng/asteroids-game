using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Bullet : MonoBehaviour {
    public Vector3 thrust;
    public Quaternion heading;

	// Use this for initialization
	void Start () {
        //travel straight in the x-axis 
        thrust.x = 400.0f;

        // do not passively decelerate
        GetComponent<Rigidbody>().drag = 0;

        //set direction it will travel in
        GetComponent<Rigidbody>().MoveRotation(heading);

        // apply thrust once, no need to apply it again since it will not decelerate
        GetComponent<Rigidbody>().AddRelativeForce(thrust);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        // the collision contains a lot of info, but it's the colliding object we're most interested in
        Collider collide = collision.collider;
        ScoreManager.score += 1; 
        if (collide.CompareTag("Asteroid"))
        {
            Asteroid roid = collide.gameObject.GetComponent<Asteroid>();
            if (roid != null)
            {
                // let the other object handle its own death 
                roid.Die();
            }

            // destroy the bullet which collided with the Asteroid
            if (gameObject != null) {
                Destroy(this.gameObject); 
            }
        } 
        else 
        {
            // if we collided with something else, print to console what the other thing was
            Debug.Log("Collided with " + collide.tag); 
        }
    }
}
