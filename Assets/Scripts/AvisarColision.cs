using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvisarColision : MonoBehaviour
{
    PlayerMoves pm;
    // Start is called before the first frame update
    public enum state
    {
        IZQ, DER, UP, DOWN
    };
    public state stado;
    void Start()
    {
        pm = transform.GetComponentInParent<PlayerMoves>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Wall") || coll.CompareTag("Door") || coll.CompareTag("Switch") || (coll.CompareTag("TrailDoor") && !pm.isTrailing()))
        {
            if (stado == state.UP)
            {
                GetComponentInParent<PlayerMoves>().collis(0);
            }
            if (stado == state.DOWN)
            {
                GetComponentInParent<PlayerMoves>().collis(1);

            }
            if (stado == state.DER)
            {
                GetComponentInParent<PlayerMoves>().collis(2);

            }
            if (stado == state.IZQ)
            {
                GetComponentInParent<PlayerMoves>().collis(3);

            }
        }
    }
}
