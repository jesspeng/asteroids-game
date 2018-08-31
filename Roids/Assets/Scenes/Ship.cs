using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {
    //public variables used to tune the ship movement
    public Vector3 forceVector;
    public float rotationSpeed;
    public float rotation;
    public AudioClip deathKnell;

    // Use this for initialization
    void Start () {
        forceVector.x = 1.0f;
        rotationSpeed = 2.0f;
	}

    /* forced changes to rigid body physics parameters should be done through
    the FixedUpdate() method, not the Update() method

    should be used whenever you are applying user forces to rigid body components

    runs a fixed number of times each frame regardless of framerate to update
    realtime physics*/
    private void FixedUpdate()
    {
        // force thruster
        if (Input.GetAxisRaw("Vertical") > 0) 
        {
            GetComponent<Rigidbody>().AddRelativeForce(forceVector); 
        }
        if (Input.GetAxisRaw("Horizontal") > 0) 
        {
            rotation += rotationSpeed;
            Quaternion rot = Quaternion.Euler(new Vector3(0, rotation, 0));
            GetComponent<Rigidbody>().MoveRotation(rot); 
            //gameObject.transform.Rotate(0, 2.0f, 0.0f); 

        } 
        else if (Input.GetAxisRaw("Horizontal") < 0) 
        {
            rotation -= rotationSpeed;
            Quaternion rot = Quaternion.Euler(new Vector3(0, rotation, 0));
            GetComponent<Rigidbody>().MoveRotation(rot); 
            //gameObject.transform.Rotate(0, -2.0f, 0.0f); 
        }


    }

    public GameObject bullet; //game object to spawn
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            AudioSource.PlayClipAtPoint(deathKnell, gameObject.transform.position);
            Debug.Log("Fire!" + rotation);
            /* spawn bullet from the tip of the ship and not inside */
            Vector3 spawnPos = gameObject.transform.position;
            spawnPos.x += 1.5f * Mathf.Cos(rotation * Mathf.PI / 180);
            spawnPos.z -= 1.5f * Mathf.Sin(rotation * Mathf.PI / 180);

            //instantiate the bullet
            GameObject obj = Instantiate(bullet, spawnPos, Quaternion.identity) as GameObject;

            // get the bullet script component of the new bullet instance
            Bullet b = obj.GetComponent<Bullet>();

            // set the direction the Bullet will travel in
            Quaternion rot = Quaternion.Euler(new Vector3(0, rotation, 0));
            b.heading = rot; 
        }

	}
}
