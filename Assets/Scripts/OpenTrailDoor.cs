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
    private void OnTriggerEnter(Collider coll)
    {
        GameObject traildoor = coll.gameObject;
        GameObject trail_manag = transform.parent.GetChild(0).gameObject;
        GameObject player = transform.parent.gameObject;
        if (traildoor.CompareTag("TrailDoor") && trail_manag.activeInHierarchy)
        {
            GameManager.Instance.playSound("Open");

            traildoor.transform.parent.gameObject.SetActive(false); // El parent contiene todos los traildoors dels map
            trail_manag.SetActive(false);
            player.GetComponent<TrailRenderer>().enabled = false;
            Destroy(GameObject.FindGameObjectWithTag("ParentOfTrailsObject"));
        }
    }
}
