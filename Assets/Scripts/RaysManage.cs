using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaysManage : MonoBehaviour
{
    List<Ray> raysUp;
    List<Ray> raysDown;
    List<Ray> raysLeft;
    List<Ray> raysRight;

    List<Ray> raysLeftUp;
    List<Ray> raysRightUp;
    List<Ray> raysLeftDown;
    List<Ray> raysRightDown;

    RaycastHit hit;
    PlayerMoves pm;

    public float hit_dist;
    public float hit_dist_esq;

    // Start is called before the first frame update
    void Start()
    {
        pm = GetComponent<PlayerMoves>();
        //cuando tengamos mas rayos inicializarlos con un for

        raysUp = new List<Ray>();
        raysDown = new List<Ray>();
        raysLeft = new List<Ray>();
        raysRight = new List<Ray>();
        raysLeftUp = new List<Ray>();
        raysRightUp = new List<Ray>();
        raysLeftDown = new List<Ray>();
        raysRightDown = new List<Ray>();

        for (int i = 0; i < transform.GetChild(6).childCount; i++)
        {
            raysUp.Add(new Ray(transform.GetChild(6).transform.GetChild(i).transform.position, Vector3.up));
            raysDown.Add(new Ray(transform.GetChild(7).transform.GetChild(i).transform.position, Vector3.down));
            raysLeft.Add(new Ray(transform.GetChild(8).transform.GetChild(i).transform.position, Vector3.left));
            raysRight.Add(new Ray(transform.GetChild(9).transform.GetChild(i).transform.position, Vector3.right));
        }

        for (int i = 0; i < transform.GetChild(10).childCount; i++)
        {
            raysLeftUp.Add(new Ray(transform.GetChild(10).transform.GetChild(i).transform.position, Vector3.left + Vector3.up));
            raysRightUp.Add(new Ray(transform.GetChild(11).transform.GetChild(i).transform.position, Vector3.right + Vector3.up));
            raysLeftDown.Add(new Ray(transform.GetChild(12).transform.GetChild(i).transform.position, Vector3.left + Vector3.down));
            raysRightDown.Add(new Ray(transform.GetChild(13).transform.GetChild(i).transform.position, Vector3.right + Vector3.down));
        }
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
            raysUp[i] = new Ray(transform.GetChild(6).transform.GetChild(i).transform.position, Vector3.up);
            if (Physics.Raycast(raysUp[i], out hit))
            {
                //print("up_dist: " + hit.distance);
                if ((Mathf.Abs(hit.distance) < hit_dist) && (hit.collider.CompareTag("Wall") || (hit.collider.CompareTag("Door") && hit.collider.name[0] != 'C' && hit.collider.gameObject.GetComponent<Renderer>().enabled) ||
                    hit.collider.CompareTag("Switch") || (hit.collider.CompareTag("InviDoor") && hit.collider.name[0] != 'C' && hit.collider.gameObject.GetComponent<Renderer>().enabled) ||
                    (hit.collider.CompareTag("TrailDoor") && !pm.isTrailing())))
                {
                    if (hit.collider.CompareTag("Switch") && hit.collider.name == "ActivateCollision") {
                        hit.collider.GetComponentInParent<ButtonActivation>().collisionButton();
                    }
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
            raysDown[i] = new Ray(transform.GetChild(7).transform.GetChild(i).transform.position, Vector3.down);
            if (Physics.Raycast(raysDown[i], out hit))
            {
                //print("down_dist: " + hit.distance);
                if ((Mathf.Abs(hit.distance) < hit_dist) && (hit.collider.CompareTag("Wall") || (hit.collider.CompareTag("Door") && hit.collider.name[0] != 'C' && hit.collider.gameObject.GetComponent<Renderer>().enabled) ||
                    hit.collider.CompareTag("Switch") || (hit.collider.CompareTag("InviDoor") && hit.collider.name[0] != 'C' && hit.collider.gameObject.GetComponent<Renderer>().enabled) ||
                    (hit.collider.CompareTag("TrailDoor") && !pm.isTrailing())))
                {
                    if (hit.collider.CompareTag("Switch") && hit.collider.name == "ActivateCollision")
                    {
                        hit.collider.GetComponentInParent<ButtonActivation>().collisionButton();
                    }
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
            raysRight[i] = new Ray(transform.GetChild(9).transform.GetChild(i).transform.position, Vector3.right);
            if (Physics.Raycast(raysRight[i], out hit))
            {
                //print("right_dist: " + hit.distance);
                if ((Mathf.Abs(hit.distance) < hit_dist) && (hit.collider.CompareTag("Wall") || (hit.collider.CompareTag("Door") && hit.collider.name[0] != 'C' && hit.collider.gameObject.GetComponent<Renderer>().enabled) ||
                    hit.collider.CompareTag("Switch") || (hit.collider.CompareTag("InviDoor") && hit.collider.name[0] != 'C' && hit.collider.gameObject.GetComponent<Renderer>().enabled) ||
                    (hit.collider.CompareTag("TrailDoor") && !pm.isTrailing())))
                {
                    if (hit.collider.CompareTag("Switch") && hit.collider.name == "ActivateCollision")
                    {
                        hit.collider.GetComponentInParent<ButtonActivation>().collisionButton();
                    }
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
            raysLeft[i] = new Ray(transform.GetChild(8).transform.GetChild(i).transform.position, Vector3.left);
            if (Physics.Raycast(raysLeft[i], out hit))
            {
                //print("left_dist: " + hit.distance);
                if ((Mathf.Abs(hit.distance) < hit_dist) && (hit.collider.CompareTag("Wall") || (hit.collider.CompareTag("Door") && hit.collider.name[0] != 'C' && hit.collider.gameObject.GetComponent<Renderer>().enabled) ||
                    hit.collider.CompareTag("Switch") || (hit.collider.CompareTag("InviDoor") && hit.collider.name[0] != 'C' && hit.collider.gameObject.GetComponent<Renderer>().enabled) ||
                    (hit.collider.CompareTag("TrailDoor") && !pm.isTrailing())))
                {
                    if (hit.collider.CompareTag("Switch") && hit.collider.name == "ActivateCollision")
                    {
                        hit.collider.GetComponentInParent<ButtonActivation>().collisionButton();
                    }
                    //print("left");
                    pm.collis(3);
                    break;
                }
            }
        }
    }

    //esquinas
    void checkCollLeftUp()
    {
        for (int i = 0; i < raysLeftUp.Count; i++)
        {
            Debug.DrawRay(transform.GetChild(10).transform.GetChild(0).transform.position, Vector3.left + Vector3.up, Color.blue);
            raysLeftUp[i] = new Ray(transform.GetChild(10).transform.GetChild(i).transform.position, Vector3.left + Vector3.up);
            if (Physics.Raycast(raysLeftUp[i], out hit))
            {
                //print("left_dist: " + hit.distance);
                if ((Mathf.Abs(hit.distance) < hit_dist_esq) && (hit.collider.CompareTag("Wall") || (hit.collider.CompareTag("Door") && hit.collider.name[0] != 'C' && hit.collider.gameObject.GetComponent<Renderer>().enabled) ||
                    hit.collider.CompareTag("Switch") || (hit.collider.CompareTag("InviDoor") && hit.collider.name[0] != 'C' && hit.collider.gameObject.GetComponent<Renderer>().enabled) ||
                    (hit.collider.CompareTag("TrailDoor") && !pm.isTrailing())))
                {
                    if (hit.collider.CompareTag("Switch") && hit.collider.name == "ActivateCollision")
                    {
                        hit.collider.GetComponentInParent<ButtonActivation>().collisionButton();
                    }
                    //print("left");
                    pm.collis(0);
                    pm.collis(3);
                    break;
                }
            }
        }
    }
    void checkCollRightUp()
    {
        for (int i = 0; i < raysRightUp.Count; i++)
        {
            Debug.DrawRay(transform.GetChild(11).transform.GetChild(0).transform.position, Vector3.right + Vector3.up, Color.blue);
            raysRightUp[i] = new Ray(transform.GetChild(11).transform.GetChild(i).transform.position, Vector3.right + Vector3.up);
            if (Physics.Raycast(raysRightUp[i], out hit))
            {
                //print("left_dist: " + hit.distance);
                if ((Mathf.Abs(hit.distance) < hit_dist_esq) && (hit.collider.CompareTag("Wall") || (hit.collider.CompareTag("Door") && hit.collider.name[0] != 'C' && hit.collider.gameObject.GetComponent<Renderer>().enabled) ||
                    hit.collider.CompareTag("Switch") || (hit.collider.CompareTag("InviDoor") && hit.collider.name[0] != 'C' && hit.collider.gameObject.GetComponent<Renderer>().enabled) ||
                    (hit.collider.CompareTag("TrailDoor") && !pm.isTrailing())))
                {
                    if (hit.collider.CompareTag("Switch") && hit.collider.name == "ActivateCollision")
                    {
                        hit.collider.GetComponentInParent<ButtonActivation>().collisionButton();
                    }
                    //print("left");
                    pm.collis(0);
                    pm.collis(2);
                    break;
                }
            }
        }
    }

    void checkCollLeftDown()
    {
        for (int i = 0; i < raysLeftDown.Count; i++)
        {
            Debug.DrawRay(transform.GetChild(12).transform.GetChild(0).transform.position, Vector3.left + Vector3.down, Color.blue);
            raysLeftDown[i] = new Ray(transform.GetChild(12).transform.GetChild(i).transform.position, Vector3.left + Vector3.down);
            if (Physics.Raycast(raysLeftDown[i], out hit))
            {
                //print("left_dist: " + hit.distance);
                if ((Mathf.Abs(hit.distance) < hit_dist_esq) && (hit.collider.CompareTag("Wall") || (hit.collider.CompareTag("Door") && hit.collider.name[0] != 'C' && hit.collider.gameObject.GetComponent<Renderer>().enabled) ||
                    hit.collider.CompareTag("Switch") || (hit.collider.CompareTag("InviDoor") && hit.collider.name[0] != 'C' && hit.collider.gameObject.GetComponent<Renderer>().enabled) ||
                    (hit.collider.CompareTag("TrailDoor") && !pm.isTrailing())))
                {
                    if (hit.collider.CompareTag("Switch") && hit.collider.name == "ActivateCollision")
                    {
                        hit.collider.GetComponentInParent<ButtonActivation>().collisionButton();
                    }
                    //print("left");
                    pm.collis(1);
                    pm.collis(3);
                    break;
                }
            }
        }
    }

    void checkCollRightDown()
    {
        for (int i = 0; i < raysRightDown.Count; i++)
        {
            Debug.DrawRay(transform.GetChild(13).transform.GetChild(0).transform.position, Vector3.right + Vector3.down, Color.blue);
            raysRightDown[i] = new Ray(transform.GetChild(13).transform.GetChild(i).transform.position, Vector3.right + Vector3.down);
            if (Physics.Raycast(raysRightDown[i], out hit))
            {
                //print("left_dist: " + hit.distance);
                if ((Mathf.Abs(hit.distance) < hit_dist_esq) && (hit.collider.CompareTag("Wall") || (hit.collider.CompareTag("Door") && hit.collider.name[0] != 'C' && hit.collider.gameObject.GetComponent<Renderer>().enabled) ||
                    hit.collider.CompareTag("Switch") || (hit.collider.CompareTag("InviDoor") && hit.collider.name[0] != 'C' && hit.collider.gameObject.GetComponent<Renderer>().enabled) ||
                    (hit.collider.CompareTag("TrailDoor") && !pm.isTrailing())))
                {
                    if (hit.collider.CompareTag("Switch") && hit.collider.name == "ActivateCollision")
                    {
                        hit.collider.GetComponentInParent<ButtonActivation>().collisionButton();
                    }
                    //print("left");
                    pm.collis(1);
                    pm.collis(2);
                    break;
                }
            }
        }
    }
}
