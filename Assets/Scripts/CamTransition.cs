using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTransition : MonoBehaviour
{
    public Camera cam;
    public Vector3 cam_pos;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        cam_pos = transform.GetChild(0).transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            StartCoroutine("transition");
        }
    }

    IEnumerator transition() {
        while (Vector3.Distance(cam.transform.position, cam_pos) > 0.1)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, cam_pos, speed);
            yield return new WaitForSeconds(0.01f);
        }
        yield return null;
    }
}
