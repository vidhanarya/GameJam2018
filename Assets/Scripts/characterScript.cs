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
    public float reactivate;

    public string rightKeyCode = "d";
    public string leftKeyCode = "a";
    public string jumpKeyCode = "space";
    public int playerWallLayer, playerLayer;

    Animation chAnimation;
    RaycastHit hit;
	public GameObject obj,InstanceObj;
    //public Material chMaterial;
	
    // Use this for initialization
	void Start () {
        onGround = true;
        rb = GetComponent<Rigidbody>();
        chAnimation = GetComponent<Animation>();
        chAnimation.Play("Idle");
        Physics.IgnoreLayerCollision(playerLayer, playerWallLayer);
        Destroy(obj.GetComponent<Collider>());
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
			if (count_blue > 0) {
				create (new Vector3 (transform.position.x, transform.position.y+0.4f, transform.position.z));
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
            print("collide with blue pickup");
			other.gameObject.SetActive(false);
			count_blue = count_blue + 1;
			//SetCountText ();
		}
		}
	void create(Vector3 m)
	{
        StartCoroutine(spawnPickup_blue(m));
	}
    IEnumerator spawnPickup_blue(Vector3 m)
    {
        InstanceObj = Instantiate(obj, m, Quaternion.identity);
        count_blue = count_blue - 1;
        InstanceObj.SetActive(true);
        print("entered the activate numerator");
        for(float f = reactivate; f > 0; f -= 0.1f)
        {
            yield return null; 
        }
        InstanceObj.AddComponent<BoxCollider>();
        yield return new WaitForSeconds(1f);
        InstanceObj.GetComponent<BoxCollider>().isTrigger = true;
        print("collider enabled");
    }
}
