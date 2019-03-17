using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovementBody : MonoBehaviour
{

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
        lookSmoothnes = 0.3f;
        lookSensitivity = 4;
    }


    void Update()
    {
        yRotation += Input.GetAxis("Mouse X") * lookSensitivity;
        currentYRotation = Mathf.SmoothDamp(currentYRotation, yRotation, ref yRotationV, lookSmoothnes);
        transform.rotation = Quaternion.Euler(0, yRotation , 0);
    }
}