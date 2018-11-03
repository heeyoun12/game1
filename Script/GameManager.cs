using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject[] SpawnPoints;
    public GameObject zombie;
    public GameObject bullet;
    public GameObject player;
	// Use this for initialization
	void Start () {
        // Mouse Lock

        Cursor.lockState = CursorLockMode.Locked;

        // Cursor visible

        Cursor.visible = false;

		foreach(var item in SpawnPoints)
        {
            if (Random.Range(0, 3) == 0)
                continue;
            Instantiate(zombie, item.transform.position, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
	}
}
