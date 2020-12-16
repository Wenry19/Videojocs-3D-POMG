using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public Menu menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseEnter()
    {
        menu.changeToMouse(0);
    }
    private void OnMouseDown()
    {
        menu.changeToMouse(0);
        menu.buttonClicked();
    }
}
