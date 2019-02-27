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
        rb.AddForce(new Vector3(speed, Random.Range(-0.9f, 0.9f), 0), ForceMode.Impulse);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        rb.AddForce(new Vector3(rb.velocity.x, Random.Range(-2f, 2f), 0), 0);
    }

    /*private void OnCollisionEnter(Collision other)
    {

            if(other.gameObject.tag == "paddle")
            {
                
            }
    }*/



}
