using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed = 1f;
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;
    private Rigidbody rb;

    void Start(){
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * Input.GetAxis("Mouse Y");
        transform.Rotate(v, h, 0);
        //transform.Translate(v, h, 0);
    }

    void FixedUpdate()
    {
        transform.Translate(speed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, speed * Input.GetAxis("Vertical") * Time.deltaTime);
    }
    private void OnCollisionStay(Collision collision)
    {
    	//test davide
        //test 2
        float salto = Input.GetAxis("Jump");
        Vector3 v = new Vector3(0, salto * 5, 0);
        rb.AddForce(v, ForceMode.Impulse);
    }
}