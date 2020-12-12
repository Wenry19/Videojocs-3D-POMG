using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvisarColision : MonoBehaviour
{
    PlayerMoves pm;
    PlayerAnimations pa;
    float timer;
    // Start is called before the first frame update
    public enum state
    {
        IZQ, DER, UP, DOWN
    };
    public state stado;
    void Start()
    {
        pm = transform.GetComponentInParent<PlayerMoves>();
        pa = transform.GetComponentInParent<PlayerAnimations>();
        timer = 0f;
    }
    public void Update()
    {
        timer -= Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        managePlayerLives(other);
    }
    void managePlayerLives(Collider coll)
    {
        if (coll.CompareTag("Spikes"))
        {
            GameManager.Instance.playSound("Explosion");
            GameManager.Instance.goCheckPoint();
        }
        else if (coll.CompareTag("CheckPoint"))
        {
            GameManager.Instance.playSound("Checkpoint");
            GameManager.Instance.setCheckPoint(coll.transform.position);
            Destroy(coll.gameObject);
        }
    }

    // Update is called once per frame
    //if(timer <= 0)
        //    if (coll.CompareTag("Wall") || (coll.CompareTag("Door") && coll.name[0]!='C' && coll.gameObject.GetComponent<Renderer>().enabled) || 
        //        coll.CompareTag("Switch") || (coll.CompareTag("InviDoor") && coll.name[0] != 'C' && coll.gameObject.GetComponent<Renderer>().enabled) || 
        //        (coll.CompareTag("TrailDoor") && !pm.isTrailing()))
        //    {
        //        GameManager.Instance.playColli();
        //        pa.callCollisionAnimation();
        //        if (stado == state.UP)
        //        {
        //            print("Arriba");
        //            GetComponentInParent<PlayerMoves>().collis(0);
        //        }
        //        if (stado == state.DOWN)
        //        {
        //            print("aba");

        //            GetComponentInParent<PlayerMoves>().collis(1);

        //        }
        //        if (stado == state.DER)
        //        {
        //            print("der");

        //            GetComponentInParent<PlayerMoves>().collis(2);

        //        }
        //        if (stado == state.IZQ)
        //        {
        //            print("izq");

        //            GetComponentInParent<PlayerMoves>().collis(3);

        //        }
        //            timer = 0.1f;
        //    }
        //}

    }
