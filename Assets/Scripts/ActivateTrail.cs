using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTrail : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {
            other.transform.parent.GetChild(0).gameObject.SetActive(true);
            other.transform.parent.GetComponent<TrailRenderer>().enabled = true;
            Destroy(gameObject);
        }
    }
}
