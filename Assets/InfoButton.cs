using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButton : MonoBehaviour
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
        menu.changeToMouse(1);
    }
    private void OnMouseDown()
    {
        //menu.changeToMouse(1);
        menu.buttonClicked();
    }
}
