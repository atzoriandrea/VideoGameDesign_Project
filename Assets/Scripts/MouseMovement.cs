﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour {

    float yRotation;
    float xRotation;
    float lookSensitivity = 4;
    float currentXRotation;
    float currentYRotation;
    float yRotationV;
    float xRotationV;
    float lookSmoothnes;
    private void Start()
    {
        lookSensitivity = 4;
        lookSmoothnes = 0.3f;
    }

    void Update()
    {
        yRotation += Input.GetAxis("Mouse X") * lookSensitivity;
        xRotation -= Input.GetAxis("Mouse Y") * lookSensitivity;
        xRotation = Mathf.Clamp(xRotation, -45, 45);
        currentXRotation = Mathf.SmoothDamp(currentXRotation, xRotation, ref xRotationV, lookSmoothnes) ;
        currentYRotation = Mathf.SmoothDamp(currentYRotation, yRotation, ref yRotationV, lookSmoothnes) ;
        transform.rotation = Quaternion.Euler(xRotation, GameObject.Find("Character_Hero_Knight_Male").transform.eulerAngles.y, 0); 
    }
}
