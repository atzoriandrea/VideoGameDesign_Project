using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public int Speed;
    public int JumpForce;
    Transform t;
    Vector3 jumpVector;
    public Rigidbody _rigidB;
    void Start()
    {
        _rigidB = GetComponent<Rigidbody>();
        Speed = 25;
        //mainCamera = ;
        JumpForce = 5;
    }
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        //Salto
        if (Input.GetKeyDown("space"))
        {
            
            _rigidB.AddForce(new Vector3(0, 10 * _rigidB.mass, 0), ForceMode.Impulse);

        }
    }

    void FixedUpdate()
    {
        jumpVector.x = (Input.GetAxis("Horizontal") * JumpForce);
        jumpVector.y = JumpForce;
        jumpVector.z = (Input.GetAxis("Vertical") * JumpForce);

        //differenza tra posizione del personaggioe della camera
        Vector3 fromCameraToMe = transform.position - Camera.main.transform.position;
        //azzera la differenza di altezza
        fromCameraToMe.y = 0;
        //In caso riceva un input (wasd)
        if (Input.GetAxisRaw("Vertical") != 0.0 || Input.GetAxisRaw("Horizontal") != 0.0)
        {
            //sposta il personaggio in modo relativo alla camera (da problemi sullo spostamento laterale)
            transform.Translate((fromCameraToMe * Input.GetAxisRaw("Vertical") + Camera.main.transform.right * (Input.GetAxisRaw("Horizontal")*-1)) * Speed * Time.deltaTime);
        }
        else
        {
            //azzera la velocità di spostamento se non si preme nulla
            _rigidB.velocity = new  Vector3(0,_rigidB.velocity.y,0);
        }
       
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Speed = 40;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Speed = 25;
        }



    }

}