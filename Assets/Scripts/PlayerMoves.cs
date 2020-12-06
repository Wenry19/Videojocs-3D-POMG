using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoves : MonoBehaviour
{
    public enum state { 
        INI, ROPE
    };
    public state player_state;
    public float speedX;
    public float speedY;
    public bool horizontal_rope;
    bool spacePressed;
    bool derecha = true;
    bool arriba = true;

    bool coliarri, coliabajo, colider, coliizqu;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        player_state = state.INI;
        rb = GetComponent<Rigidbody>();
        rb.drag = 0;
        rb.angularDrag = 0;
        rb.AddForce(new Vector3(speedX, speedY, 0));
    }
    public void collis(int col)
    {
        if (col == 0)
        {
            arriba = false;
        }
        if (col == 1)
        {
            arriba = true;
        }
        if (col == 2)
        {
            derecha = false;
        }
        if (col == 3)
        {
            derecha = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (player_state == state.INI)
        {
            //desatascar();
            float movY, movX;
            if (arriba)
            {
                movY = speedY;
            }
            else movY = -speedY;
            if (derecha)
            {
                movX = speedY;
            }
            else movX = -speedY;

            transform.position = new Vector3(transform.position.x + movX, transform.position.y + movY, 0);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                arriba = !arriba;
            }
        }
        else if (player_state == state.ROPE) {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (horizontal_rope)
                {
                    float xSpeed = rb.velocity.x;
                    rb.velocity = new Vector3(-xSpeed, 0, 0);
                }
                else
                {
                    float ySpeed = rb.velocity.y;
                    rb.velocity = new Vector3(0, -ySpeed, 0);
                }
            }
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

    public void change_state(string new_state) {
        if (new_state == "ROPE") player_state = state.ROPE;
        else if (new_state == "INI") player_state = state.INI;
    }
}
