using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float MoveSpeed;
    public float JumpForce;
    Transform t;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        MoveSpeed = 1.5f;
        JumpForce = 5.5f;
    }
    void Update()
    {

    }

    void FixedUpdate()
    {
        Vector3 targetDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        targetDirection = Camera.main.transform.TransformDirection(targetDirection);
        targetDirection.y = 0.0f;
        //var desiredMoveDirection = forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal");

        transform.Translate(targetDirection * MoveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            MoveSpeed = 2.3f;
        }
        else
        {
            MoveSpeed = 1.5f;
        }
        if (Input.GetKeyDown("space"))
            rb.AddForce(transform.up * JumpForce);
    }

}