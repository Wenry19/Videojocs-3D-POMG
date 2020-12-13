using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void win(Vector3 pos)
    {

        transform.position = pos;
        GameManager.Instance.stopSound();
        GameManager.Instance.playSound("WinLevel");

        GameManager.Instance.stopMusic();
        StartCoroutine("won");
    }
    IEnumerator won()
    {
        float duration = 5f;
        float shrink = 1.0003f;
        float startRotation = transform.eulerAngles.y;
        float endRotation = startRotation + 900f;
        float t = 0.0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            float yRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % 180.0f;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation,
            transform.eulerAngles.z);
            transform.localScale = new Vector3(transform.localScale.x / shrink, transform.localScale.y / shrink, transform.localScale.z / shrink);
            yield return null;
        }
        GameManager.Instance.nextLevel();
        yield return null;
    }
}
