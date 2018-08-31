using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
    public int pointValue;
  
	// Use this for initialization
	void Start () {
        pointValue = 10; 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject deathExplosion;

    public void Die() 
    {


        // rotate particle system so it flies the right way 
        Instantiate(deathExplosion, gameObject.transform.position, Quaternion.AngleAxis(-90, Vector3.right));

        GameObject obj = GameObject.Find("GlobalObject");
        Global g = obj.GetComponent<Global>();
        g.score += pointValue; 

        if (gameObject != null) {
            Destroy(this.gameObject); 
        }

    }

}
