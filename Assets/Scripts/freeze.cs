using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freeze : MonoBehaviour {

    public float freezeTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    void OnTriggerEnter(Collider other)
    {
        print("triggered");
        if (other.gameObject.CompareTag("Player"))
        {
            print("Collision with character");
            Destroy(gameObject.gameObject.GetComponent<Mesh>());
            Destroy(other.gameObject.GetComponent<characterScript>());
            StartCoroutine(Freeze(other,freezeTime));
        }
    }
    IEnumerator Freeze(Collider other, float freezeTime)
    {
        print("entered numerator");
        for (float f = freezeTime; f >= 0; f -= 0.1f)
        {
            other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            print("execute once");
            yield return null;
        }
        
        other.gameObject.AddComponent<characterScript>();
        print("script added");
        Destroy(gameObject);
    }
}
