using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPosCamera : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.setFirstCameraPos(transform.position);
    }
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.levelVisTransition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
