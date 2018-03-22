using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObject : MonoBehaviour {


    public GameObject spawnItem;
    public GameObject player;


    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject clone;
			clone = Instantiate(spawnItem, new Vector3(transform.position.x - 0.4f, transform.position.y + 0.144814f, transform.position.z), Quaternion.identity);
        }
    }
}
