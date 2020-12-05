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
        GameObject traildoor = collision.gameObject;
        GameObject trail_manag = transform.GetChild(0).gameObject;
        if (traildoor.CompareTag("TrailDoor") && trail_manag.activeInHierarchy)
        {
            traildoor.transform.parent.gameObject.SetActive(false);
            transform.GetChild(0).gameObject.SetActive(false);
            Destroy(GameObject.FindGameObjectWithTag("ParentOfTrailsObject"));
        }
    }
}
