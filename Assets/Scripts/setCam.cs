﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setCam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        GameManager.Instance.setCam(gameObject);
        if(!GameManager.Instance.getFirstTimeInLevel())
        transform.position = GameManager.Instance.getCamPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
