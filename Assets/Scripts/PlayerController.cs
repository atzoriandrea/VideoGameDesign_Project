using UnityEngine;
using System.Collections;
using System.Timers;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float gravity = -9.8f;
    public float JumpForce;
    public bool crouch;
    private CharacterController _charCont;
    Vector3 movement;
    float deltaX, deltaZ;
    Animator anim;
    // Use this for initialization
    void Start()
    {
        _charCont = GetComponent<CharacterController>();
        JumpForce = 1.0f;
        speed = 2f;
        crouch = false;
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(deltaX.ToString() + deltaZ.ToString() );
        if (Input.GetKeyDown(KeyCode.C)) {
            crouch = !crouch;
            anim.SetBool("crouch", crouch);
        }
        if (Input.GetButton("Fire1"))
        {
            anim.SetTrigger("swordattack");

        }
        if (_charCont.isGrounded)
        {
            deltaX = Input.GetAxis("Horizontal") * speed;
            deltaZ = Input.GetAxis("Vertical") * speed;
            //camminata avanti
            if ((deltaZ > 0) && !Input.GetKey(KeyCode.LeftShift))
            {
                if (!crouch)
                {
                    anim.SetBool("walkback", false);
                    anim.SetBool("walking", true);
                }
                else {
                    anim.SetBool("crouchwalk", true);
                }
            }
            //camminata indietro
            else if ((deltaZ < 0) && !Input.GetKey(KeyCode.LeftShift))
            {
                if (!crouch)
                {
                    anim.SetBool("walkback", true);
                    anim.SetBool("walking", false);
                }
                else {
                    anim.SetBool("crouchback", true);
                }
            }
            //fermo
            else
            {
                anim.SetBool("crouchback", false);
                anim.SetBool("crouchwalk", false);
                anim.SetBool("walking", false);
                anim.SetBool("walkback", false);
            }
            movement = new Vector3(deltaX, movement.y, deltaZ);//Vettore movimento
            movement = transform.TransformDirection(movement);
            //corsa avanti
            if (Input.GetKey(KeyCode.Space) && deltaZ >= 0)
            {
                anim.SetBool("jump", true);
                movement.y = JumpForce;
            }
            //corsa indietro
            else if (Input.GetKey(KeyCode.Space) && deltaZ < 0) {
                anim.SetBool("jumpback", true);
                movement.y = JumpForce;
            }
        }
        
        movement.y += gravity * Time.deltaTime;
        //ferma salto
        if (_charCont.isGrounded && !Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("jump", false);
            anim.SetBool("jumpback", false);
        }
        _charCont.Move(movement * Time.deltaTime);
        //Corsa in avanti
        if (Input.GetKey(KeyCode.LeftShift) &&  deltaZ >= 0)
        {
            crouch = false;
            anim.SetBool("crouch",false);
            anim.SetBool("crouchback", false);
            anim.SetBool("crouchwalk", false);
            anim.SetBool("walkback", false);
            anim.SetBool("runback", false);
            anim.SetBool("walking", false);
            anim.SetBool("running", true);
            speed = 4.5f;
        }
        //Corsa all'indietro
        if (Input.GetKey(KeyCode.LeftShift) && deltaZ < 0)
        {
            crouch = false;
            anim.SetBool("crouch", false);
            anim.SetBool("crouchback", false);
            anim.SetBool("crouchwalk", false);
            anim.SetBool("running", false);
            anim.SetBool("walking", false);
            anim.SetBool("walkback", false);
            anim.SetBool("runback", true);
            speed = 3.5f;
        }
        //fine corsa
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetBool("runback", false);
            anim.SetBool("running", false);
            speed = 2f;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "swordcollider")
        {
           // Physics.IgnoreCollision(collision.collider, _charCont.collider);
        }

    }

}

