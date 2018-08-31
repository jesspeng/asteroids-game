using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ScoreManager : MonoBehaviour {
    public static int score;
    Text scoreText; 
	// Use this for initialization
	void Start () {
        scoreText = GetComponent<Text>();
        score = 0; 
	}
	
	// Update is called once per frame
	void Update () {
        setScore(); 
	}

    void setScore() {
        scoreText.text = "Score: " + score.ToString(); 
    }
}
