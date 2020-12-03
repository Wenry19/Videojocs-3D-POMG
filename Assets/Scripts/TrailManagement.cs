using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailManagement : MonoBehaviour
{
    public GameObject Trail;
    public float iniTimeToSpawn = 0.5f;
    float timeToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        timeToSpawn = iniTimeToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        timeToSpawn -= Time.deltaTime;
        if (timeToSpawn <= 0) {
            timeToSpawn = iniTimeToSpawn;
            Instantiate(Trail, new Vector3(transform.position.x, transform.position.y, transform.position.z), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        }
    }
}
