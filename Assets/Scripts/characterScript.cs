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

    public string rightKeyCode = "d";
    public string leftKeyCode = "a";
    public string jumpKeyCode = "space";
    public int playerWallLayer, playerLayer;

    Animation chAnimation;
    RaycastHit hit;
	public GameObject obj;
    //public Material chMaterial;
	
    // Use this for initialization
	void Start () {
        onGround = true;
        rb = GetComponent<Rigidbody>();
        chAnimation = GetComponent<Animation>();
        chAnimation.Play("Idle");
        Physics.IgnoreLayerCollision(playerLayer, playerWallLayer);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(rightKeyCode)) { transform.Rotate(0, -90, 0, Space.World); }
        if (Input.GetKey(rightKeyCode))
        {
            rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, 0f);
            chAnimation.Play("Run");
        }
        if (Input.GetKeyUp(rightKeyCode))
        {
            rb.velocity = new Vector3(0f, 0f, 0f);
            chAnimation.Play("Idle");
            transform.Rotate(0, +90, 0, Space.World);
        }
        if (Input.GetKeyDown(leftKeyCode)) { transform.Rotate(0, 90, 0, Space.World); }
        if (Input.GetKey(leftKeyCode))
        {
            rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0f);
            chAnimation.Play("Run");
        }
        if (Input.GetKeyUp(leftKeyCode))
        {
            rb.velocity = new Vector3(0f, 0f, 0f);
            chAnimation.Play("Idle");
            transform.Rotate(0, -90, 0, Space.World);
        }

        Vector3 down = transform.TransformDirection(Vector3.down);

        if (Physics.Raycast(transform.position, down, out hit, 0.205f)) { onGround = true; }
        else onGround = false;
        //print("There is something in front of the object!");

        if (onGround)
        {
            if (Input.GetKeyDown(jumpKeyCode))
            {
                rb.velocity += new Vector3(0f, jumpSpeed, 0f);
                onGround = false;
            }
        }


        if (Input.GetKeyDown("p"))
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
