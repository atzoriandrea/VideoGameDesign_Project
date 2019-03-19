using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour {

    float yRotation;
    float xRotation;

    float lookSensitivity;
    //float lookSmoothnes;
    GameObject body;

    private void Start()
    {
        lookSensitivity = 4;
        //lookSmoothnes = 0.0f;
        body = GameObject.Find("Character_Hero_Knight_Male");
    }
    void Update()
    {
        yRotation += Input.GetAxis("Mouse X") * lookSensitivity;
        xRotation -= Input.GetAxis("Mouse Y") * lookSensitivity;

        xRotation = Mathf.Clamp(xRotation, -45, 60);
        transform.rotation = Quaternion.Euler(xRotation, body.transform.eulerAngles.y, 0);
    }
}
