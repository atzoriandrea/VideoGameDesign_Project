using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour {

    public float yRotation;
    public float xRotation;

    public float lookSensitivity;
    GameObject body;
    GameObject spine;

    private void Start()
    {
        lookSensitivity = 4;
        body = GameObject.Find("Character_Hero_Knight_Male");
        spine = GameObject.Find("Character_Hero_Knight_Male").transform.Find("Root").Find("Hips").Find("Spine_01").gameObject;
    }
    void Update()
    {
        yRotation += Input.GetAxis("Mouse X") * lookSensitivity;
        xRotation -= Input.GetAxis("Mouse Y") * lookSensitivity;
        xRotation = Mathf.Clamp(xRotation, -45, 60);
        transform.rotation = Quaternion.Euler(xRotation, body.transform.eulerAngles.y, 0);
        
    }
    private void LateUpdate()
    {
        yRotation += Input.GetAxis("Mouse X") * lookSensitivity;
        xRotation -= Input.GetAxis("Mouse Y") * lookSensitivity;
        xRotation = Mathf.Clamp(xRotation, -45, 60);
        //In caso si stia mirando col tasto destro del mouse
        if (Input.GetMouseButton(1))
            spine.transform.rotation = Quaternion.Euler(body.transform.eulerAngles.x, body.transform.eulerAngles.y+90 , xRotation - 90);
        if(Input.GetMouseButtonUp(1))

        Debug.Log(spine.transform.rotation);
    }
}
