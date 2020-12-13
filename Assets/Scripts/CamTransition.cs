using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTransition : MonoBehaviour
{
    public Camera cam;
    public Vector3 cam_pos;
    public float speed;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        cam_pos = transform.GetChild(0).transform.position;
        timer = 5f;

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            transform.GetComponent<BoxCollider>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            StopCoroutine("transition");
            StartCoroutine("transition");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopCoroutine("transition");
        }
    }

    IEnumerator transition() {
        int count = 150;
        while (Vector3.Distance(cam.transform.position, cam_pos) > 0.001 && count > 0)
        {
            --count;
            cam.transform.position = Vector3.Lerp(cam.transform.position, cam_pos, speed);
            yield return new WaitForSeconds(0.01f);
        }
        cam.transform.position = cam_pos;
        yield return null;
    }
}
