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
            GameObject player = other.transform.parent.gameObject;

            player.GetComponent<PlayerMoves>().enabled = false;
            player.GetComponent<PlayerAnimations>().enabled = false;
            player.GetComponent<RaysManage>().enabled = false;

            player.GetComponent<WinAnimation>().win(transform.position);

        }
    }
}
