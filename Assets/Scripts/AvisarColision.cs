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
        if (other.CompareTag("Enemy"))
        {
            if (stado == state.UP)
            {
                //print("Arriba");
                GetComponentInParent<PlayerMoves>().collis(0);
            }
            if (stado == state.DOWN)
            {
                //print("aba");

                GetComponentInParent<PlayerMoves>().collis(1);

            }
            if (stado == state.DER)
            {
                //print("der");

                GetComponentInParent<PlayerMoves>().collis(2);

            }
            if (stado == state.IZQ)
            {
                //print("izq");

                GetComponentInParent<PlayerMoves>().collis(3);

            }
        }
    }
    void managePlayerLives(Collider coll)
    {
        if (coll.CompareTag("Spikes"))
        {
            GameManager.Instance.playSound("Explosion");
            callAnimacionMuerte();           
        }
        else if (coll.CompareTag("CheckPoint"))
        {
            GameManager.Instance.playSound("Checkpoint");
            GameManager.Instance.setCheckPoint(coll.transform.position);
            Destroy(coll.gameObject);
        }
    }
    public void callAnimacionMuerte()
    {
        StartCoroutine("animacionMuerte");

    }
    IEnumerator animacionMuerte()
    {
        GameObject player = transform.parent.gameObject;
        player.GetComponent<MeshRenderer>().enabled = false;
        player.GetComponent<PlayerMoves>().enabled = false;
        player.GetComponent<PlayerAnimations>().enabled = false;

        player.transform.GetChild(2).GetComponent<BoxCollider>().enabled = false;
        player.transform.GetChild(3).GetComponent<BoxCollider>().enabled = false;
        player.transform.GetChild(4).GetComponent<BoxCollider>().enabled = false;
        player.transform.GetChild(5).GetComponent<BoxCollider>().enabled = false;

        GameObject particles = player.transform.GetChild(14).gameObject;
        particles.SetActive(true);
        yield return new WaitForSeconds(2);
        particles.SetActive(false);
        GameManager.Instance.goCheckPoint();

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
