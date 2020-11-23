using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoves : MonoBehaviour
{
    public float speedX;
    public float speedY;
    bool spacePressed;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = 0;
        rb.angularDrag = 0;
        rb.AddForce(new Vector3(speedX, speedY, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float ySpeed = rb.velocity.y;

            rb.velocity = new Vector3(rb.velocity.x, -ySpeed, 0);
        }
    }
}
