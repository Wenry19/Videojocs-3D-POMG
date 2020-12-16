using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    public GameObject player;
    public TextMesh pressSpace;
    float angleX;
    float angleY;
    float angleZ;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 3;
        angleX = Random.Range(-90, 90);
        angleY = Random.Range(-90, 90);
        angleZ = Random.Range(-90, 90);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        
        if(timer <= 0)
        {
            pressSpace.text = "Press Space or click to go back to menu";
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                GameManager.Instance.loadLevel(0);
            }
        }

        player.transform.Rotate(angleX * Time.deltaTime, angleY * Time.deltaTime, angleZ * Time.deltaTime);
    }
}
