using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterScript : MonoBehaviour {
    
    //variables to be logged
    float hInput;
    public bool onGround;
    private Rigidbody rb;
    public float jumpSpeed = 5f;
    public float moveSpeed = 3f;
    Animation animation;
    //public Material chMaterial;
	
    // Use this for initialization
	void Start () {
        onGround = true;
        rb = GetComponent<Rigidbody>();
        animation = GetComponent<Animation>();
        animation.Play("Idle");
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("d")) { transform.Rotate(0, -90, 0, Space.World); }
        if (Input.GetKey("d"))
        {
            rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, 0f);
            animation.Play("Run");
        }
        if (Input.GetKeyUp("d"))
        {
            rb.velocity = new Vector3(0f, 0f, 0f);
            animation.Play("Idle");
            transform.Rotate(0, +90, 0, Space.World);
        }
        if (Input.GetKeyDown("a")) { transform.Rotate(0, 90, 0, Space.World); }
        if (Input.GetKey("a"))
        {
            rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0f);
            animation.Play("Run");
        }
        if (Input.GetKeyUp("a"))
        {
            rb.velocity = new Vector3(0f, 0f, 0f);
            animation.Play("Idle");
            transform.Rotate(0, -90, 0, Space.World);
        }
        if (onGround)
        {
            if (Input.GetKeyDown("space"))
            {
                rb.velocity += new Vector3(0f, jumpSpeed, 0f);
                onGround = false;
            }

        }
     }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("platform"))
        {
            onGround = true;
        }
    }
   
}
