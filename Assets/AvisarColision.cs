using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvisarColision : MonoBehaviour
{
    // Start is called before the first frame update
    public enum state
    {
        IZQ,DER,UP,DOWN
    };
    public state stado;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider coll)
    {
        if(stado == state.UP)
        {
            GetComponentInParent<PlayerMoves>().collis(0);
            print("arri");
        }
        if (stado == state.DOWN)
        {
            GetComponentInParent<PlayerMoves>().collis(1);
            print("aba");

        }
        if (stado == state.DER)
        {
            GetComponentInParent<PlayerMoves>().collis(2);
            print("der");

        }
        if (stado == state.IZQ)
        {
            GetComponentInParent<PlayerMoves>().collis(3);
            print("izq");

        }
    }
}
