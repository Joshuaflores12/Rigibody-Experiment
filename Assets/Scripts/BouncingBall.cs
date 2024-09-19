using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    public Rigidbody rb;
    public float gravityScale = 1.0f;
    public static float globalGravity = 9.8f;
    public float forceAmount;

   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 gravity = globalGravity * gravityScale * Vector3.down;
        rb.AddForce(gravity, ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            rb.AddForce(Vector3.up * forceAmount, ForceMode.Impulse);
            forceAmount -= 5f;
            if (forceAmount <= 0) 
            {
            forceAmount = 0;
            }
            
        }
    }
}
