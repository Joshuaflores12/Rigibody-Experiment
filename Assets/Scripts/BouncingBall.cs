using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] private float gravityScale = 1.0f; // rb's Gravity Scale
    [SerializeField] private static float globalGravity = 9.8f; // Earth's gravity
    [SerializeField] private float forceAmount; // force applied
    [SerializeField] private float decayF;      // percentage of loss energy to force
    [SerializeField] private float minForceAmount; // min force for velocity to come to a hault
    [SerializeField] private float coefficientOfResititution; 
   

   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        decayF = coefficientOfResititution;
    }

    void FixedUpdate()
    {
        Vector3 gravity = globalGravity * gravityScale * Vector3.down; // The objects fall speed is determined by gravity
        rb.AddForce(gravity, ForceMode.Acceleration); // continous gravity application

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            decayF = coefficientOfResititution; // COR is based on the elasticity of the material where ranges from 0 - 1 the higher it is the higher the energy is stored and lost upon impact with another object
            forceAmount *= decayF; // to get the percentage of the energy lost of which will be the new force amount 
            
            if (forceAmount > minForceAmount)
            {
                rb.AddForce(Vector3.up * forceAmount, ForceMode.Impulse);

            }
            else 
            {
                rb.velocity = Vector3.zero;
            }
        }
    }
}
