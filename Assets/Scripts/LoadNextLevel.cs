using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {
            //other.transform.parent.GetComponent<WinAnimation>().win(transform.position);
            GameManager.Instance.playSound("WinLevel");
            //GameManager
            GameManager.Instance.nextLevel();
        }
    }
}
