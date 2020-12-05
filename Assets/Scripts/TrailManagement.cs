using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailManagement : MonoBehaviour
{
    public GameObject Trail;
    public float iniTimeToSpawn;
    float timeToSpawn;
    GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        timeToSpawn = iniTimeToSpawn;
        parent = new GameObject("ParentOfTrailsObject");
        parent.transform.position = transform.position;
        parent.tag = "ParentOfTrailsObject";

    }

    // Update is called once per frame
    void Update()
    {
        timeToSpawn -= Time.deltaTime;
        if (timeToSpawn <= 0) {
            timeToSpawn = iniTimeToSpawn;
            GameObject obj = (GameObject)Instantiate(Trail, new Vector3(transform.position.x, transform.position.y, transform.position.z), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
            obj.transform.parent = parent.transform;
        }
    }
}
