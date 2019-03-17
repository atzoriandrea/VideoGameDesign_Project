using UnityEngine;
using System.Collections;
using System.Timers;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float gravity = -9.8f;
    public float jumpForce; 
    private CharacterController _charCont;
    public Animator anim;
    Vector3 movement;
    float deltaX, deltaZ;
    bool walking, running;
    // Use this for initialization
    void Start(){
        _charCont = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        jumpForce = 3.0f;
        speed = 4;
        walking = running = false;
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
            if ((deltaZ != 0 || deltaX != 0) && !Input.GetKey(KeyCode.LeftShift))
            {

                anim.SetBool("walking", true);
            }
            else
            {
                anim.SetBool("walking", false);
            }
            movement = new Vector3(deltaX, 0, deltaZ);//Vettore movimento
            movement = transform.TransformDirection(movement);
            if (Input.GetButton("Jump"))
            {

                //movement.y = jumpForce;
                anim.SetFloat("jump", jumpForce);
            }
            
        }
        movement.y += gravity * Time.deltaTime;
        _charCont.Move(movement * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 8;
            if (deltaZ != 0 || deltaX != 0)
            {
                anim.SetBool("running", true);
                anim.SetBool("walking", false);
            }
            else
            {
                anim.SetBool("running", false);
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetBool("running", false);
            speed = 4;
           
        }
    }
 

}

