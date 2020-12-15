using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    public GameObject player;
    float angleX;
    float angleY;
    float angleZ;
    // Start is called before the first frame update
    void Start()
    {
        angleX = Random.Range(-90, 90);
        angleY = Random.Range(-90, 90);
        angleZ = Random.Range(-90, 90);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            GameManager.Instance.loadLevel(0);
        }
        

        player.transform.Rotate(angleX * Time.deltaTime, angleY * Time.deltaTime, angleZ * Time.deltaTime);
    }
}
