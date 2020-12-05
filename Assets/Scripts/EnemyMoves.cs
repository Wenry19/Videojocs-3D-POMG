using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoves : MonoBehaviour
{
    public float speedX;
    public float speedY;
    public float time;
    float A;
    public Vector3 ini_pos;
    delegate void Behaviour();
    Behaviour enemy_behaviour;
    bool horizontal = false;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //Debug.Log(transform.GetChild(0).transform.position);
        //Debug.Log(transform.GetChild(1).transform.position);
        RaycastHit hit1;
        RaycastHit hit2;
        Ray Ray1 = new Ray(transform.GetChild(0).transform.position,  Vector3.down);
        Ray Ray2 = new Ray(transform.GetChild(1).transform.position,  Vector3.up);

        if (speedX != 0) {
            Ray1 = new Ray(transform.GetChild(0).transform.position, Vector3.right);
            Ray2 = new Ray(transform.GetChild(1).transform.position, Vector3.left);
            horizontal = true;
        }


        if (Physics.Raycast(Ray1, out hit1, Mathf.Infinity) && Physics.Raycast(Ray2, out hit2)) {
            A = (hit1.distance + hit2.distance) / 2;
            Debug.Log(A);
        }


        if (!horizontal) ini_pos = new Vector3(transform.position.x, hit1.point.y + A + transform.localScale.y/2, 0.0f);
        else ini_pos = new Vector3(hit1.point.x + A + transform.localScale.x / 2, transform.position.y, 0.0f);

        transform.position = ini_pos;

        enemy_behaviour += follow_player;
    }

    // Update is called once per frame
    void Update()
    {
        enemy_behaviour();
    }

    void constant_move() {
        if (speedY != 0)
        {
            time += Time.deltaTime;
            transform.position = new Vector3(0.0f, A * Mathf.Sin(speedY * time), 0.0f) + ini_pos;
        }
        if (speedX != 0)
        {
            time += Time.deltaTime;
            transform.position = new Vector3(A * Mathf.Sin(speedX * time), 0.0f, 0.0f) + ini_pos;
        }
    }
    void follow_player() {
        float aux = 0.0f;
        if (!horizontal)
        {
            if (player.transform.position.y > transform.position.y)
            {
                aux = Mathf.Clamp(transform.position.y + speedY, ini_pos.y - A, ini_pos.y + A);
                
            }
            else if (player.transform.position.y < transform.position.y) {
                aux = Mathf.Clamp(transform.position.y - speedY, ini_pos.y - A, ini_pos.y + A);
            }
            transform.position += new Vector3(0.0f, aux, 0.0f);
        }
        else
        {
            if (player.transform.position.x > transform.position.x)
            {
                aux = Mathf.Clamp(transform.position.x + speedX, ini_pos.x - A, ini_pos.x + A);
            }
            else if (player.transform.position.x < transform.position.x)
            {
                aux = Mathf.Clamp(transform.position.x - speedX, ini_pos.x - A, ini_pos.x + A);
            }
            transform.position += new Vector3(aux, 0.0f, 0.0f);
        }
    }
}
