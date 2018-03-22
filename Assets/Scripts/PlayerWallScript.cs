using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallScript : MonoBehaviour
{
    public string player;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        print("wall triggered");
        if (other.gameObject.CompareTag(player))
        {
            print("player1walltriggered");
        }
    }
}
