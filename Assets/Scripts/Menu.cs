using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    public TextMesh[] options;
    int currentOption;
    public GameObject menuScreen;
    public GameObject infoScreen;
    public GameObject creditsScreen;
    public GameObject Bg;
    bool inMenu;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        inMenu = true;
        currentOption = 0;
        options[currentOption].color = new Color(1, 0, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (inMenu)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                buttonClicked();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || (Input.GetMouseButton(0) && timer<=0))
            {
                GameManager.Instance.stopSound();
                GameManager.Instance.playSound("Teclas");
                Bg.GetComponent<SpriteRenderer>().color = Color.white;
                creditsScreen.SetActive(false);
                infoScreen.SetActive(false);
                menuScreen.SetActive(true);
                inMenu = true;
            }
        }
        if (inMenu)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                GameManager.Instance.stopSound();
                GameManager.Instance.playSound("Teclas");

                currentOption--;
                if (currentOption < 0) currentOption = 3;

            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                GameManager.Instance.stopSound();
                GameManager.Instance.playSound("Teclas");

                currentOption = (currentOption + 1) % 4;
            }

            updateOptions();
        }
    }
    public void changeToMouse(int i)
    {
        if (i != currentOption)
        {
            GameManager.Instance.stopSound();
            GameManager.Instance.playSound("Teclas");
        }
        currentOption = i;
        updateOptions();
    }
    void updateOptions()
    {
        for(int i = 0; i < options.Length; ++i)
        {
            options[i].color = new Color(0.7058824f, 0.6235294f, 0.3294118f);
        }
        options[currentOption].color = new Color(1, 0, 0, 1);
    }
    public void buttonClicked()
    {
        Color grey = new Color(0.5f, 0.5f, 0.5f);
        GameManager.Instance.stopSound();
        GameManager.Instance.playSound("Teclas");
        switch (currentOption)
        {
            case 0:
                GameManager.Instance.nextLevel();
                break;
            case 1:
                Bg.GetComponent<SpriteRenderer>().color = grey;
                timer = 0.25f; // Necesario para que funcione con el raton.
                menuScreen.SetActive(false);
                infoScreen.SetActive(true);
                inMenu = false;
                break;
            case 2:
                Bg.GetComponent<SpriteRenderer>().color = grey;
                timer = 0.25f; // Necesario para que funcione con el raton.
                menuScreen.SetActive(false);
                creditsScreen.SetActive(true);
                inMenu = false;
                break;
            case 3:
                Application.Quit();
                break;
        }
    }
}
