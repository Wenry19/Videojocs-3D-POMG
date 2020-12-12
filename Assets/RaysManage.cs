using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaysManage : MonoBehaviour
{
    List<Ray> raysUp;
    List <Ray> raysDown;
    List <Ray> raysLeft;
    List <Ray> raysRight;

    RaycastHit hit;
    PlayerMoves pm;

    public float hit_dist;

    // Start is called before the first frame update
    void Start()
    {
        pm = GetComponent<PlayerMoves>();
        //cuando tengamos mas rayos inicializarlos con un for

        raysUp = new List<Ray>();
        raysDown = new List<Ray>();
        raysLeft = new List<Ray>();
        raysRight = new List<Ray>();

        raysUp.Add(new Ray(transform.GetChild(6).transform.GetChild(0).transform.position, Vector3.up));
        raysDown.Add(new Ray(transform.GetChild(7).transform.GetChild(0).transform.position, Vector3.down));
        raysLeft.Add(new Ray(transform.GetChild(8).transform.GetChild(0).transform.position, Vector3.left));
        raysRight.Add(new Ray(transform.GetChild(9).transform.GetChild(0).transform.position, Vector3.right));
    }

    // Update is called once per frame
    void Update()
    {
        checkCollUp();
        checkCollDown();
        checkCollLeft();
        checkCollRight();
    }

    void checkCollUp()
    {
        for (int i = 0; i < raysUp.Count; i++)
        {
            Debug.DrawRay(transform.GetChild(6).transform.GetChild(0).transform.position, Vector3.up, Color.black);
            raysUp[i] = new Ray(transform.GetChild(6).transform.GetChild(0).transform.position, Vector3.up);
            if (Physics.Raycast(raysUp[i], out hit))
            {
                //print("up_dist: " + hit.distance);
                if ((Mathf.Abs(hit.distance) < hit_dist) && (hit.collider.CompareTag("Wall") || (hit.collider.CompareTag("Door") && hit.collider.name[0] != 'C' && hit.collider.gameObject.GetComponent<Renderer>().enabled) ||
                    hit.collider.CompareTag("Switch") || (hit.collider.CompareTag("InviDoor") && hit.collider.name[0] != 'C' && hit.collider.gameObject.GetComponent<Renderer>().enabled) || 
                    (hit.collider.CompareTag("TrailDoor") && !pm.isTrailing())))
                {
                    //print("up");
                    pm.collis(0);
                    break;
                }
            }
        }
    }

    void checkCollDown()
    {
        for (int i = 0; i < raysDown.Count; i++)
        {
            Debug.DrawRay(transform.GetChild(7).transform.GetChild(0).transform.position, Vector3.down, Color.red);
            raysDown[i] = new Ray(transform.GetChild(7).transform.GetChild(0).transform.position, Vector3.down);
            if (Physics.Raycast(raysDown[i], out hit))
            {
                //print("down_dist: " + hit.distance);
                if ((Mathf.Abs(hit.distance) < hit_dist) && (hit.collider.CompareTag("Wall") || (hit.collider.CompareTag("Door") && hit.collider.name[0] != 'C' && hit.collider.gameObject.GetComponent<Renderer>().enabled) ||
                    hit.collider.CompareTag("Switch") || (hit.collider.CompareTag("InviDoor") && hit.collider.name[0] != 'C' && hit.collider.gameObject.GetComponent<Renderer>().enabled) ||
                    (hit.collider.CompareTag("TrailDoor") && !pm.isTrailing())))
                {
                    //print("down");
                    pm.collis(1);
                    break;
                }
            }
        }
    }
    void checkCollRight()
    {
        for (int i = 0; i < raysRight.Count; i++)
        {
            Debug.DrawRay(transform.GetChild(9).transform.GetChild(0).transform.position, Vector3.right, Color.green);
            raysRight[i] = new Ray(transform.GetChild(9).transform.GetChild(0).transform.position, Vector3.right);
            if (Physics.Raycast(raysRight[i], out hit))
            {
                //print("right_dist: " + hit.distance);
                if ((Mathf.Abs(hit.distance) < hit_dist) && (hit.collider.CompareTag("Wall") || (hit.collider.CompareTag("Door") && hit.collider.name[0] != 'C' && hit.collider.gameObject.GetComponent<Renderer>().enabled) ||
                    hit.collider.CompareTag("Switch") || (hit.collider.CompareTag("InviDoor") && hit.collider.name[0] != 'C' && hit.collider.gameObject.GetComponent<Renderer>().enabled) ||
                    (hit.collider.CompareTag("TrailDoor") && !pm.isTrailing())))
                {
                    //print("right");
                    pm.collis(2);
                    break;
                }
            }
        }
    }

    void checkCollLeft()
    {
        for (int i = 0; i < raysLeft.Count; i++)
        {
            Debug.DrawRay(transform.GetChild(8).transform.GetChild(0).transform.position, Vector3.left, Color.blue);
            raysLeft[i] = new Ray(transform.GetChild(8).transform.GetChild(0).transform.position, Vector3.left);
            if (Physics.Raycast(raysLeft[i], out hit))
            {
                //print("left_dist: " + hit.distance);
                if ((Mathf.Abs(hit.distance) < hit_dist) && (hit.collider.CompareTag("Wall") || (hit.collider.CompareTag("Door") && hit.collider.name[0] != 'C' && hit.collider.gameObject.GetComponent<Renderer>().enabled) ||
                    hit.collider.CompareTag("Switch") || (hit.collider.CompareTag("InviDoor") && hit.collider.name[0] != 'C' && hit.collider.gameObject.GetComponent<Renderer>().enabled) ||
                    (hit.collider.CompareTag("TrailDoor") && !pm.isTrailing())))
                {
                    //print("left");
                    pm.collis(3);
                    break;
                }
            }
        }
    }

}
