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
        desatascar();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float ySpeed = rb.velocity.y;
            rb.velocity = new Vector3(rb.velocity.x, -ySpeed, 0);
        }
    }

    void desatascar() {
        float ySpeed = rb.velocity.y;
        float xSpeed = rb.velocity.x;
        if (ySpeed <= 0 && ySpeed != -3.75) ySpeed = -3.75f;
        else if (ySpeed >= 0 && ySpeed != 3.75) ySpeed = 3.75f;
        if (xSpeed <= 0 && xSpeed != -3.75) xSpeed = -3.75f;
        else if (xSpeed >= 0 && xSpeed != 3.75) xSpeed = 3.75f;

        rb.velocity = new Vector3(xSpeed, ySpeed, 0);
    }
}
