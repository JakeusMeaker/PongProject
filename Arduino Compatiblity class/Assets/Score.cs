using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : Arduino {

    private string score;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        	
	}

    public string WriteToArduino()
    {
        score = "test";

        return score;
    }
}
