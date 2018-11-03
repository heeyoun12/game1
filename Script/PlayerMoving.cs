using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour {

    public float movingSpeed = 1.0f;
    public float xSensitivity = 1.0f;
    public float ySensitivity = 1.0f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float yRot = Input.GetAxis("Mouse X") * xSensitivity;
        float xRot = Input.GetAxis("Mouse Y") * ySensitivity;

        //오브젝트(기준이 되는 축을 유지해야 됨)와 카메라 회전을 분리해야 됨
        //쿼터니안은 곱해야 누적됨
        this.transform.localRotation *= Quaternion.Euler(0, yRot, 0);
        gameObject.transform.GetChild(2).gameObject.transform.localRotation *= Quaternion.Euler(-xRot, 0, 0);//부호 주의

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += gameObject.transform.GetChild(2).gameObject.transform.forward * movingSpeed*Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += gameObject.transform.GetChild(2).gameObject.transform.right * movingSpeed * Time.deltaTime;


        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += gameObject.transform.GetChild(2).gameObject.transform.forward * -movingSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += gameObject.transform.GetChild(2).gameObject.transform.right * -movingSpeed * Time.deltaTime;
        }
    }

}
