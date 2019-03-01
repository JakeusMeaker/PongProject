using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private float speed = 10f;
    int startSpeed = 10;
    [SerializeField]
    private Transform spawnPoint;

    Rigidbody rb;
    [SerializeField] private float multiplier = 1.05f;

    //Use this for initialization
    void Start ()
    {       
        rb = GetComponent<Rigidbody>();
        Launch();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    private void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "paddle")
        {
            float newSpeed = speed * multiplier;
            rb.velocity = rb.velocity.normalized * newSpeed;
            speed = newSpeed;
        }        
    }  

    void Launch()
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(new Vector3(startSpeed, Random.Range(-3f, 3f), 0), ForceMode.Impulse);
    }

    public void Respawn()
    {
        this.gameObject.SetActive(false);
        transform.position = spawnPoint.position;
        this.gameObject.SetActive(true);
        Launch();
    }



}
