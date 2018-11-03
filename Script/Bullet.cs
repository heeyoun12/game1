using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed = 100000.0f;
    public GameObject player;
    public float timer = 0.0f;
	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
            transform.position += player.transform.GetChild(2).transform.forward * speed*Time.deltaTime;
        timer ++;
        if (timer >= 5000*Time.deltaTime)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
