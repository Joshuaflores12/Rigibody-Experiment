using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltControl : MonoBehaviour
{
    [SerializeField] private float tiltSpeed;
    

    // Update is called once per frame
    void Update()
    {
        float horizontal = -Input.GetAxis("Vertical");
        transform.Rotate(Vector3.forward, horizontal * Time.deltaTime * tiltSpeed);

    }
}
