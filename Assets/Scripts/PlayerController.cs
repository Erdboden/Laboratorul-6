using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}


public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;
    public GameObject engineLeft;
    public GameObject engineRight;

    private GameController gameController;
    private Rigidbody myRigidbody;
    private void Start()
    {
        this.myRigidbody = this.GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
      
        engineRight.SetActive(false);
        engineLeft.SetActive(false);
        float moveHorizontal = Input.GetAxis("Horizontal");
 

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        this.myRigidbody.velocity = movement * speed;

        this.myRigidbody.position = new Vector3
                (
                    Mathf.Clamp(this.myRigidbody.position.x, boundary.xMin, boundary.xMax),
                    1f,
                    -8f
                );
        if(Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") < 0)
            engineRight.SetActive(true);
        if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") > 0)
            engineLeft.SetActive(true);
        /*if (this.myRigidbody.position.x<0)
        {
            // this.myRigidbody.rotation = Quaternion.Euler(this.myRigidbody.velocity.x * -tilt,90f , 90f);
            engineRight.SetActive(true);

        }
        if (this.myRigidbody.position.x>0)
        {
            //this.myRigidbody.rotation = Quaternion.Euler(this.myRigidbody.velocity.x * -tilt, -90f, -90f);
            engineLeft.SetActive(true);
        }*/
       

    }
}