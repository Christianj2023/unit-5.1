using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLock : MonoBehaviour
{
    public float movespeed;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	player = GameObject.FindWithTag("Player");
        transform.position = new Vector3(player.transform.position.x, 0f, player.transform.position.z - 10);
    }
}
