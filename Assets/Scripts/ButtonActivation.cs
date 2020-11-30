using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivation : MonoBehaviour
{
    bool activate = true;
    public GameObject[] doors;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void collisionButton()
    {
        manageDoor();
        if (activate)
        {
            transform.rotation = Quaternion.Euler(90.0f, 180.0f, -90.0f);
            activate = false;
        }
        else
        {
            transform.rotation = Quaternion.Euler(90.0f, 0.0f, -90.0f);
            activate = true;
        }
    }

    void manageDoor() {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].SetActive(!doors[i].activeInHierarchy); // Si la puerta esta activada la desactivara, y al reves.
        }
    }
}
