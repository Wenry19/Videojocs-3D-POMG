using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InviDoor : MonoBehaviour
{
    float timer;
    // Start is called before the first frame update
    void Start()
    { 
        timer = 1f; // Se le da un tiempo para ser detectado por el detector de puertas
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                GetComponent<MeshRenderer>().enabled = true;
                gameObject.SetActive(false);
            }
        }
    }
}
