using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public int Speed { get; set; }
    public int JumpForce { get; set; } 
    Transform t;
    Vector3 jumpVector;
    private Rigidbody _rigidB;
    void Start(){
        _rigidB = GetComponent<Rigidbody>();
        Speed = 5;
        JumpForce = 20;

    }
    void Update(){

        jumpVector.x = (Input.GetAxis("Horizontal") * JumpForce);
        jumpVector.y = JumpForce;
        jumpVector.z = (Input.GetAxis("Vertical") * JumpForce);
        if (Input.GetKey("w"))
        {
            _rigidB.AddForce(Vector3.forward * Speed);
        }
        if (Input.GetKey("s"))
        {
            _rigidB.AddForce(Vector3.back * Speed);
        }
        if (Input.GetKey("d"))
        {
            _rigidB.AddForce(Vector3.right * Speed);
        }
        if (Input.GetKey("a"))
        {
            _rigidB.AddForce(Vector3.left * Speed);
        }
    }

    void FixedUpdate(){

        var forward = Camera.main.transform.forward;    
        forward.y = 0;//
        var desiredMoveDirection = forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal");

        transform.Translate(desiredMoveDirection * Speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = 12;
        }
        else
        {
            Speed = 5;
        }
        if (Input.GetKeyDown("space"))
        {

            _rigidB.MovePosition(_rigidB.position + jumpVector * Time.deltaTime);
        }

    }
  
}

