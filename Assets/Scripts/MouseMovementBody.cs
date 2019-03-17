using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovementBody : MonoBehaviour
{

    float yRotation;
    float lookSensitivity;
    float lookSmoothnes;

    private void Start()
    {
        lookSensitivity = 4;
        lookSmoothnes = 0.0f;
    }

    void Update()
    {
        yRotation += Input.GetAxis("Mouse X") * lookSensitivity;
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }

}

