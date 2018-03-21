using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerControlScript : MonoBehaviour {

<<<<<<< HEAD
	private Rigidbody rb;
	public float speed;
	private int count;
	public Text countText;
	public Text winText;
	public bool onGround;
	public float jumpSpeed = 5f;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		onGround = true;
		winText.text=" ";
	}

	void FixedUpdate() //Before any physics operation
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		if (onGround)
		{
			if (Input.GetKeyDown("space"))
			{
				rb.velocity = new Vector3(0f,jumpSpeed,0f);
				onGround = false;
			}

		}

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement*speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText ();
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) {
			winText.text = "You Win";
		}
	}
=======

    public bool onGround;
    private Rigidbody rb;           //player character rigidbody
    public float jumpSpeed = 5f;         
    public float speed;             //player motion speed
    private int count;              //pickup count
    public Text countText;          //display pickup count
    public Text winText;            //display winning message

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();             //updates count text
        winText.text = " ";
        onGround = true;
    }
	
	// Update is called once per frame
	void Update () {
        //Horizontal Movement Mechanic (needs to be replaced)
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb.velocity += new Vector3(speed*moveHorizontal, 0.0f, 0.0f);

        //Jump Mechanic
        if (onGround)
        {
            if (Input.GetKeyDown("space"))
            {
                rb.velocity += new Vector3(0f, jumpSpeed, 0f);
                onGround = false;
            }

        }

    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "You Win";
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("platform"))
        {
            onGround = true;
        }
    }

>>>>>>> 7ea965f1b35629271e01eecb014fc87afc87fd50
}

