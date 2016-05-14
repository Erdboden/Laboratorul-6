using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public float speed;
    private Rigidbody myRigidbody;

    
    void Start()
    {
        this.myRigidbody = this.GetComponent<Rigidbody>();
        this.myRigidbody.velocity = transform.forward * speed;
    }
}