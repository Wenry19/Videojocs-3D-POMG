using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodModeText : MonoBehaviour
{
    TextMesh tm;
    // Start is called before the first frame update
    void Start()
    {
        tm = transform.GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        bool godMode = GameManager.Instance.getGodMode();
        if (godMode) tm.text = "God Mode Active";
        else tm.text = "";
    }
}
