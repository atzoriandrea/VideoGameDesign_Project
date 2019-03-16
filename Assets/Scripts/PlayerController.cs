using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public int Speed;
    public int JumpForce;
    Transform t;
    Vector3 jumpVector;
    //Vector3 fromCameraToMe;
    //public GameObject mainCamera;
    public Rigidbody _rigidB;
    void Start()
    {
        _rigidB = GetComponent<Rigidbody>();
        Speed = 3;
        //mainCamera = ;
        JumpForce = 420;
    }
    void Update()
    {
        jumpVector.x = (Input.GetAxis("Horizontal") * JumpForce);
        jumpVector.y = JumpForce;
        jumpVector.z = (Input.GetAxis("Vertical") * JumpForce);
    }

    void FixedUpdate()
    {
        Vector3 fromCameraToMe = transform.position - Camera.main.transform.position;
        fromCameraToMe.y = 0;
        if (Input.GetAxisRaw("Vertical") != 0.0 || Input.GetAxisRaw("Horizontal") != 0.0)
        {
            transform.Translate(fromCameraToMe * Input.GetAxisRaw("Vertical")+ Camera.main.transform.right * (Input.GetAxisRaw("Horizontal")*-1) * Speed * Time.deltaTime);
        }
        else
        {
            _rigidB.velocity = Vector3.zero;
        }
       
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = 7;
        }
        else
        {
            Speed = 3;
        }
        if (Input.GetKeyDown("space"))
        {
            _rigidB.AddForce(new Vector3(0, 10 * _rigidB.mass, 0), ForceMode.Impulse);

        }
        

    }

}