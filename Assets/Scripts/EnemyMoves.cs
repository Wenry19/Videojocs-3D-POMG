using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoves : MonoBehaviour
{
    public float speedX;
    public float speedY;
    public float time;
    public float A;
    public Vector3 ini_pos;
    // Start is called before the first frame update
    void Start()
    {
        ini_pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
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
}
