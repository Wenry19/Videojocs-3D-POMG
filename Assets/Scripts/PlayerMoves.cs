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

    //bool coliarri, coliabajo, colider, coliizqu;
    Rigidbody rb;

    private void Awake()
    {
        GameManager.Instance.setPlayer(gameObject);

    }
    // Start is called before the first frame update
    void Start()
    {
        player_state = state.INI;
        transform.position = GameManager.Instance.getCheckPointPosition();
    }
    public void collis(int col)
    {
        GameManager.Instance.playColli();
        transform.GetComponent<PlayerAnimations>().callCollisionAnimation();
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
        float time = Time.deltaTime;
        if (player_state == state.INI)
        {
            float movY, movX;
            if (arriba)
            {
                movY = speedY * time;
            }
            else movY = -speedY * time;
            if (derecha)
            {
                movX = speedY * time;
            }
            else movX = -speedY * time;

            transform.position = new Vector3(transform.position.x + movX, transform.position.y + movY, 0);
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                GameManager.Instance.playSound("Space");
                arriba = !arriba;
            }
        }
        else if (player_state == state.ROPE) {
            float movY, movX;
            movX = movY = 0;
            float movAdicional = 3f;

            if (horizontal_rope)
            {
                if (derecha)
                    movX = (speedX + movAdicional) * time;
                else
                    movX = (-speedX- movAdicional) * time;
            }
            else
            {
                if (arriba)
                    movY = (speedY + movAdicional) * time;
                else
                    movY = (-speedY - movAdicional) * time;
            }

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                GameManager.Instance.playSound("Space");
                if (horizontal_rope)
                {
                    derecha = !derecha;
                }
                else
                {
                    arriba = !arriba;
                }
            }
            transform.position = new Vector3(transform.position.x + movX, transform.position.y + movY, 0);
        }
    }

    public void change_state(string new_state) {
        if (new_state == "ROPE") player_state = state.ROPE;
        else if (new_state == "INI") player_state = state.INI;
    }

    public bool isRight()
    {
        return derecha;
    }

    public bool getHorizontalRope()
    {
        return horizontal_rope;
    }

    public bool isUp()
    {
        return arriba;
    }

    public bool isTrailing()
    {
        return transform.GetChild(0).gameObject.activeInHierarchy;
    }
    public bool notOnRopes()
    {
        return player_state != state.ROPE;
    }
}
