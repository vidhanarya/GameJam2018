using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterScript : MonoBehaviour {
    
    //variables to be logged
    float hInput, vInput;
    public bool onGround;
    private Rigidbody rb;
    public float jumpSpeed = 5f;
    public float moveSpeed = 3f;
    //public Material chMaterial;
	
    // Use this for initialization
	void Start () {
        print("Yo, I am the character");
        onGround = true;
        rb = GetComponent<Rigidbody>();
        //chMaterial = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
        hInput = Input.GetAxis("Horizontal");
        //vInput = Input.GetAxis("Vertical");
        if (onGround)
        {
            if (Input.GetKeyDown("space"))
            {
                rb.velocity = new Vector3(0f,jumpSpeed,0f);
                onGround = false;
            }

        }
        transform.Translate(hInput * Time.deltaTime*moveSpeed, 0f, 0f);
        //transform.Translate(0f, vInput * Time.deltaTime*moveSpeed, 0f);
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("platform"))
        {
            onGround = true;
        }
    }
    
    //void onDestroy()
    //{
    //   Destroy(chMaterial);
    //}
}
