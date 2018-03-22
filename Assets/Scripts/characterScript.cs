using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterScript : MonoBehaviour {
    
    //variables to be logged
    float hInput;
    public bool onGround;
	private int count_red;
	private int count_blue;
    private Rigidbody rb;
    public float jumpSpeed = 5f;
    public float moveSpeed = 3f;
    Animation animation;
	public GameObject obj;
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

		if(Input.GetKeyDown("p"))
		{
			//count_blue = count_blue - 1;
			if (count_blue > 0) {
				if (transform.position.x > 6.64) {
					create (new Vector3 (transform.position.x + 1, transform.position.y+0.4f, transform.position.z));
				} 
				else {
					create (new Vector3 (transform.position.x - 1, transform.position.y+0.4f, transform.position.z));
				}
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
	void OnTriggerEnter(Collider other)
	{
		if (count_red + count_blue >= 4) {
			return;
		}

		if (other.gameObject.CompareTag ("pickup_red")) {
			other.gameObject.SetActive(false);
			count_red = count_red + 1;
			//SetCountText ();
		}
		if (other.gameObject.CompareTag ("pickup_blue")) {
			other.gameObject.SetActive(false);
			count_blue = count_blue + 1;
			//SetCountText ();
		}
		}
	void create(Vector3 m)
	{
		Instantiate (obj, m, Quaternion.identity); 
		obj.SetActive (true);
		count_blue = count_blue - 1;
	}
}
