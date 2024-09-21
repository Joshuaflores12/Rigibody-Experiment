using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] private float gravityScale = 1.0f;
    [SerializeField]private static float globalGravity = 9.8f;
    [SerializeField]private float forceAmount;
   

   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 gravity = globalGravity * gravityScale * Vector3.down;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            rb.AddForce(Vector3.up * forceAmount, ForceMode.Impulse);
        }
    }
}
