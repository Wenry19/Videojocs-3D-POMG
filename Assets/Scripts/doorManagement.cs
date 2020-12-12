using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorManagement : MonoBehaviour
{
    public GameObject[] doors;
    public GameObject[] colliders;

    float timer = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        //if (num_doors == current_num_doors) {
            
        //    current_num_doors += 1; //para cortarlo todo
        //    //esto antes estaba en el trigger pero no funcionaba pork para que enviase doors a ba tenia que volver a detectar trigger enter
        //}
        if(timer <= 0)
        {
            ButtonActivation ba = GetComponentInParent<ButtonActivation>();
            ba.doors = doors;
            ba.colliders = colliders;
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(doors);
        bool already_in = false;
        //if (current_num_doors < num_doors)
        //{
        if (other.name[0] != 'C')
        {
            for (int i = 0; i < doors.Length; i++)
            {
                if (doors[i].GetInstanceID() == other.GetInstanceID())
                {
                    already_in = true;
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].GetInstanceID() == other.GetInstanceID())
                {
                    already_in = true;
                    break;
                }
            }
        }
        if (!already_in && (other.CompareTag("Door") || other.CompareTag("InviDoor")))
        {
                    //Debug.Log(other.name);
            if (other.name[0] != 'C')
            {
                if (doors.Length == 0)
                {

                    doors = new GameObject[] { other.gameObject };
                    if (other.CompareTag("InviDoor"))
                    {
                        Renderer rendFather = other.GetComponent<Renderer>();
                        Renderer rendChild = other.GetComponentInChildren<Renderer>();
                        
                        rendFather.enabled = false;
                        rendChild.enabled = true;
                    }
                }

                else
                {
                    //Debug.Log(doors.Length);

                    List<GameObject> aux_list = new List<GameObject>(doors);
                    aux_list.Add(other.gameObject);
                    doors = aux_list.ToArray();

                    if (other.CompareTag("InviDoor"))
                    {
                        Renderer rendFather = other.gameObject.GetComponentInChildren<Renderer>();
                        Renderer rendChild = other.transform.GetChild(0).GetComponentInChildren<Renderer>();

                        rendFather.enabled = false;
                        rendChild.enabled = true;
                    }
                }
            }
            else
            {
                if (colliders.Length == 0)
                {
                    colliders = new GameObject[] { other.gameObject };
                }

                else
                {
                    List<GameObject> aux_colli_list = new List<GameObject>(colliders);
                    aux_colli_list.Add(other.gameObject);
                    colliders = aux_colli_list.ToArray();
                }
            }
        }
        //}
    }
   
}
