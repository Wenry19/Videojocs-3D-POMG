using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoves : MonoBehaviour
{
    public enum enemyType
    {
        CONSTANT, FOLLOW, LASTMOMENTCHASE
    };
    public enemyType type;

    public float speedX;
    public float speedY;
    public float time;
    float A;
    public Vector3 ini_pos;
    delegate void Behaviour();
    Behaviour enemy_behaviour;
    public bool horizontal;
    GameObject player;

    public float distanceToChase;
    public float speedInChase;
    public  bool primerSentido;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        RaycastHit hit1;
        RaycastHit hit2;
        Vector3 pointOfHit2 = new Vector3(0,0,0);
        Ray Ray1 = new Ray(transform.GetChild(0).transform.position,  Vector3.down);
        Ray Ray2 = new Ray(transform.GetChild(1).transform.position,  Vector3.up);

        if (horizontal) {
            Ray1 = new Ray(transform.GetChild(0).transform.position, Vector3.left);
            Ray2 = new Ray(transform.GetChild(1).transform.position, Vector3.right);
        }


        if (Physics.Raycast(Ray1, out hit1) && Physics.Raycast(Ray2, out hit2)) {
            A = (hit1.distance + hit2.distance) / 2;
            pointOfHit2 = hit2.point;
        }

        if (!horizontal) ini_pos = new Vector3(transform.position.x, hit1.point.y + A + transform.localScale.y/2f, 0.0f);
        else ini_pos = new Vector3(hit1.point.x + A + transform.localScale.y / 2f, transform.position.y, 0.0f);

        transform.position = ini_pos;


        switch (type)
        {
            case enemyType.CONSTANT:
                enemy_behaviour += constant_move;
                break;

            case enemyType.FOLLOW:
                enemy_behaviour += follow_player;
                break;

            case enemyType.LASTMOMENTCHASE:
                enemy_behaviour += chaseLastMoment;
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        enemy_behaviour();
    }

    void constant_move() {
        if (!horizontal)
        {
            if (ini_pos.y - transform.position.y >= A)
            {
                primerSentido = true;
            }
            else if(ini_pos.y - transform.position.y <= -A)
            {
                primerSentido = false;
            }

            if(primerSentido)
            transform.position = new Vector3(transform.position.x, transform.position.y + speedY * Time.deltaTime, 0f);
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - speedY * Time.deltaTime, 0f);

            }
        }
        else
        {
            if (ini_pos.x - transform.position.x >= A)
            {
                primerSentido = true;
            }
            else if (ini_pos.x - transform.position.x <= -A)
            {
                primerSentido = false;
            }

            if (primerSentido)
                transform.position = new Vector3(transform.position.x + speedX * Time.deltaTime, transform.position.y , 0f);
            else
            {
                transform.position = new Vector3(transform.position.x - speedX * Time.deltaTime, transform.position.y, 0f);

            }
        }
    }
    void follow_player() {
        float aux = 0.0f;
        float margen = 0.2f;
        if (!horizontal)
        {
            if (player.transform.position.y > transform.position.y + margen)
            {
                aux = Mathf.Clamp(transform.position.y + (speedY * Time.deltaTime), ini_pos.y - A, ini_pos.y + A);

            }
            else if (player.transform.position.y < transform.position.y - margen)
            {
                aux = Mathf.Clamp(transform.position.y - (speedY * Time.deltaTime), ini_pos.y - A, ini_pos.y + A);
            }
            else aux = transform.position.y;

            transform.position = new Vector3(transform.position.x, aux, 0.0f);
        }
        else
        {
            if (player.transform.position.x > transform.position.x + margen)
            {
                aux = Mathf.Clamp(transform.position.x + (speedX * Time.deltaTime), ini_pos.x - A, ini_pos.x + A);
            }
            else if (player.transform.position.x < transform.position.x - margen)
            {
                aux = Mathf.Clamp(transform.position.x - (speedX * Time.deltaTime), ini_pos.x - A, ini_pos.x + A);
            }
            else aux = transform.position.x;

            transform.position = new Vector3(aux, transform.position.y, 0.0f);
        }
    }
    void chaseLastMoment()
    {
        if (horizontal)
        {
            if(Mathf.Abs(transform.position.y - player.transform.position.y) > distanceToChase)
            {
                constant_move();
            }
            else
            {
                speedX += speedInChase;
                follow_player();
                speedX -= speedInChase;

            }
        }
        else
        {
            if (Mathf.Abs(transform.position.x - player.transform.position.x) > distanceToChase)
            {
                constant_move();
            }
            else
            {
                speedY += speedInChase;
                follow_player();
                speedY -= speedInChase;

            }
        }
    }
}
