using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float speed = 1f;
    
    Rigidbody rb;
    //Use this for initialization
	void Start ()
    {       
        rb = GetComponent<Rigidbody>();
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "paddle")
        {
            rb.AddForce(new Vector3(speed * Time.deltaTime, Random.Range(-2f, 2f), 0), 0);
        }
    }

    void Launch()
    {
        rb.AddForce(new Vector3(Random.Range(-speed, speed), Random.Range(-0.9f, 0.9f), 0), ForceMode.Impulse);
    }



}
