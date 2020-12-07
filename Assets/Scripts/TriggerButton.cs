using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerButton : MonoBehaviour
{
    ButtonActivation button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponentInParent<ButtonActivation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider coll)
    {
        button.collisionButton();
    }
}
