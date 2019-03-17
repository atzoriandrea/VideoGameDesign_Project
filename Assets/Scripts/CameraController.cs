using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public enum RotationAxis
    {
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxis axes = RotationAxis.MouseX;
    
    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;
    public float sensHorizontal = 10.0f;
    public float sensVertical = 10.0f;
    public float _rotationX = 0;
    public float _rotationY = 0;
    private Vector3 _velocity = Vector3.zero;

    // Update is called once per frame
    private void Start()
    {
        
    }
    void Update()
    {
        if (axes == RotationAxis.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensHorizontal * Time.deltaTime, 0);
        }
        else if (axes == RotationAxis.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensVertical ;
            _rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
            //gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position, Camera.main.transform.position, ref _velocity, 0.5f);

        }
    }
}
