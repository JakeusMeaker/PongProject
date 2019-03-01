using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private float speed = 10f;
    private int startSpeed = 6;
    [SerializeField]
    private float multiplier = 1.05f;
    [SerializeField]
    private Transform spawnPoint;

    private Rigidbody rb;

    //Use this for initialization
    void Start ()
    {       
        rb = GetComponent<Rigidbody>(); //Finds the rigid body on the object
        Launch(); 
    }
	
    private void OnCollisionEnter(Collision other)
    {
        //when the ball collides with anything tagged "paddle" it adds a slight amount of speed to the balls velocity
        if(other.collider.tag == "paddle")
        {
            float newSpeed = speed * multiplier;
            rb.velocity = rb.velocity.normalized * newSpeed;
            speed = newSpeed;
        }        
    }  

    void Launch()
    {
        //launches the ball in a random direction to the right
        rb.velocity = Vector3.zero;
        rb.AddForce(new Vector3(startSpeed, Random.Range(-3f, 3f), 0), ForceMode.Impulse);
    }

    public void Respawn()
    {
        //disables the ball and places it back at the spawn point then re-enables it and launches it again
        this.gameObject.SetActive(false);
        transform.position = spawnPoint.position;
        this.gameObject.SetActive(true);
        Launch();
    }



}
