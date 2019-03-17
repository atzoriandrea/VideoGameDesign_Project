using UnityEngine;
using System.Collections;
using System.Timers;

public class PlayerController : MonoBehaviour
{   
    public float speed;
    public float gravity;
    public float jumpForce; 
    private CharacterController _charCont;
    Vector3 movement;
    float deltaX, deltaZ;
    // Use this for initialization
    void Start(){
        _charCont = GetComponent<CharacterController>();
        jumpForce = 5.0f;
        speed = 4;
        gravity = -9.8f;
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(_charCont.isGrounded);
        //Quando il character è sul suolo
        if (_charCont.isGrounded)
        {
            deltaX = Input.GetAxis("Horizontal") * speed;
            deltaZ = Input.GetAxis("Vertical") * speed;
            movement = new Vector3(deltaX, 0, deltaZ);//Vettore movimento
            movement = transform.TransformDirection(movement);
            if (Input.GetButton("Jump"))
            {
                movement.y = jumpForce;
            }
        }
        movement.y += gravity * Time.deltaTime;
        _charCont.Move(movement * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 8;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 4;
        }
    }

    void OnCollisionEnter(Collider collision)
    {
        movement.y -= gravity * Time.deltaTime;
    }

}

