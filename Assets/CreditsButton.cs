using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsButton : MonoBehaviour
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
        menu.changeToMouse(2);
    }
    private void OnMouseDown()
    {
        menu.changeToMouse(2);
        menu.buttonClicked();
    }
}
