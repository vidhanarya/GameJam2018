using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	private int count;
	public Text countText;
	public Text winText;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text=" ";
	}

	void FixedUpdate() //Before any physics operation
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 5*moveVertical, 0);

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
}

