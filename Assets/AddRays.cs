using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRays : MonoBehaviour
{
    public GameObject ray;
    // Start is called before the first frame update
    void Start()
    {
        GameObject raysUp = transform.GetChild(6).gameObject;
        GameObject raysDown = transform.GetChild(7).gameObject;
        GameObject raysLeft = transform.GetChild(8).gameObject;
        GameObject raysRight = transform.GetChild(9).gameObject;

        GameObject raysLeftUp = transform.GetChild(10).gameObject;
        GameObject raysRightUp = transform.GetChild(11).gameObject;
        GameObject raysLeftDown = transform.GetChild(12).gameObject;
        GameObject raysRightDown = transform.GetChild(13).gameObject;

        Vector3 iniposup = transform.position + new Vector3(transform.localScale.x/2.0f, transform.localScale.y/2.0f + 0.01f, transform.localScale.z/2.0f);
        for (int i = 0; i < 16; i++) {
            for (int j = 0; j < 16; j++) {
                GameObject go = Instantiate(ray, iniposup - new Vector3 (0.05f * i, 0.0f, 0.05f * j), transform.rotation);
                go.transform.parent = raysUp.transform;
            }
        }

        Vector3 iniposdown = transform.position + new Vector3(transform.localScale.x / 2.0f, -transform.localScale.y / 2.0f - 0.01f, transform.localScale.z / 2.0f);
        for (int i = 0; i < 16; i++)
        {
            for (int j = 0; j < 16; j++)
            {
                GameObject go = Instantiate(ray, iniposdown - new Vector3(0.05f * i, 0.0f, 0.05f * j), transform.rotation);
                go.transform.parent = raysDown.transform;
            }
        }

        Vector3 iniposleft = transform.position + new Vector3(-transform.localScale.x / 2.0f - 0.01f, transform.localScale.y / 2.0f, transform.localScale.z / 2.0f);
        for (int i = 0; i < 16; i++)
        {
            for (int j = 0; j < 16; j++)
            {
                GameObject go = Instantiate(ray, iniposleft - new Vector3(0.0f, 0.05f * i, 0.05f * j), transform.rotation);
                go.transform.parent = raysLeft.transform;
            }
        }

        Vector3 iniposright = transform.position + new Vector3(transform.localScale.x / 2.0f + 0.01f, transform.localScale.y / 2.0f, transform.localScale.z / 2.0f);
        for (int i = 0; i < 16; i++)
        {
            for (int j = 0; j < 16; j++)
            {
                GameObject go = Instantiate(ray, iniposright - new Vector3(0.0f, 0.05f * i, 0.05f * j), transform.rotation);
                go.transform.parent = raysRight.transform;
            }
        }

        //esquinas
        Vector3 iniposrightup = transform.position + new Vector3(transform.localScale.x / 2.0f + 0.01f, transform.localScale.y / 2.0f + 0.01f, transform.localScale.z / 2.0f);
        for (int i = 0; i < 16; i++)
        {
            GameObject go = Instantiate(ray, iniposrightup - new Vector3(0.0f, 0.0f, 0.05f * i), transform.rotation);
            go.transform.parent = raysRightUp.transform;
        }

        Vector3 iniposleftup = transform.position + new Vector3(-transform.localScale.x / 2.0f - 0.01f, transform.localScale.y / 2.0f + 0.01f, transform.localScale.z / 2.0f);
        for (int i = 0; i < 16; i++)
        {
            GameObject go = Instantiate(ray, iniposleftup - new Vector3(0.0f, 0.0f, 0.05f * i), transform.rotation);
            go.transform.parent = raysLeftUp.transform;
        }

        Vector3 iniposrightDown = transform.position + new Vector3(transform.localScale.x / 2.0f + 0.01f, -transform.localScale.y / 2.0f - 0.01f, transform.localScale.z / 2.0f);
        for (int i = 0; i < 16; i++)
        {
            GameObject go = Instantiate(ray, iniposrightDown - new Vector3(0.0f, 0.0f, 0.05f * i), transform.rotation);
            go.transform.parent = raysRightDown.transform;
        }

        Vector3 iniposleftDown = transform.position + new Vector3(-transform.localScale.x / 2.0f - 0.01f, -transform.localScale.y / 2.0f - 0.01f, transform.localScale.z / 2.0f);
        for (int i = 0; i < 16; i++)
        {
            GameObject go = Instantiate(ray, iniposleftDown - new Vector3(0.0f, 0.0f, 0.05f * i), transform.rotation);
            go.transform.parent = raysLeftDown.transform;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
