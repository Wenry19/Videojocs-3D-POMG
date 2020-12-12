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

        if (other.name == "RopeDetector")
        {
            GameManager.Instance.startRope();
            GameObject player = other.transform.parent.gameObject;
            PlayerMoves pm = player.GetComponent<PlayerMoves>();

            if (horizontal)
            {
                pm.horizontal_rope = true;
                player.transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);

                
            }
            else
            {
                pm.horizontal_rope = false;
                player.transform.position = new Vector3(transform.position.x, player.transform.position.y, player.transform.position.z);

            }
            pm.change_state("ROPE");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "RopeDetector")
        {
            GameManager.Instance.stopRope();

            GameObject player = other.transform.parent.gameObject;
            PlayerMoves pm = player.GetComponent<PlayerMoves>();
            pm.change_state("INI");
        }
    }
}
