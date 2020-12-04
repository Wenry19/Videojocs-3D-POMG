using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTrailDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject go = collision.gameObject;
        GameObject trail_manag = transform.GetChild(0).gameObject;
        if (go.CompareTag("TrailDoor") && trail_manag.activeInHierarchy)
        {
            go.transform.parent.gameObject.SetActive(false); // Si la puerta esta activada la desactivara, y al reves.
        }
    }
}
