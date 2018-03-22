using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1WallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        print("wall triggered");
        if (other.gameObject.CompareTag("Player"))
        {
            print("player1walltriggered");
        }
    }
}
