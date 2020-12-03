using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopesManagement : MonoBehaviour
{
    public bool horizontal = true;
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
        GameObject player = other.gameObject;
        PlayerMoves pm = player.GetComponent<PlayerMoves>();
        if (horizontal)
        {
            pm.horizontal_rope = true;
            player.transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);

            if (player.GetComponent<Rigidbody>().velocity.x < 0.0f)
            {
                player.GetComponent<Rigidbody>().velocity = new Vector3(-5.37f, 0.0f, 0.0f);
            }
            else
            {
                player.GetComponent<Rigidbody>().velocity = new Vector3(5.37f, 0.0f, 0.0f);
            }

        }
        else {
            pm.horizontal_rope = false;
            player.transform.position = new Vector3(transform.position.x, player.transform.position.y, player.transform.position.z);

            if (player.GetComponent<Rigidbody>().velocity.y < 0.0f)
            {
                player.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, -5.37f, 0.0f);
            }
            else
            {
                player.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 5.37f, 0.0f);
            }
        }
        pm.change_state("ROPE");
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject player = other.gameObject;
        PlayerMoves pm = player.GetComponent<PlayerMoves>();
        pm.change_state("INI");
    }
}
