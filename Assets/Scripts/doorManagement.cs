using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorManagement : MonoBehaviour
{
    public GameObject[] doors;
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
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(doors);
        bool already_in = false;
        //if (current_num_doors < num_doors)
        //{
        for (int i = 0; i < doors.Length; i++)
        {
            if (doors[i].GetInstanceID() == other.GetInstanceID())
            {
                already_in = true;
                break;
            }
        }
        if (!already_in && (other.CompareTag("Door") || other.CompareTag("InviDoor")))
        {
            if (doors.Length == 0)
            {
                doors = new GameObject[] { other.gameObject };
                if (other.CompareTag("InviDoor"))
                {
                    other.transform.gameObject.SetActive(false);
                }
                //current_num_doors += 1;
            }
            else
            {
                List<GameObject> aux_list = new List<GameObject>(doors);
                aux_list.Add(other.gameObject);
                doors = aux_list.ToArray();

                if (other.CompareTag("InviDoor"))
                {
                    other.transform.gameObject.SetActive(false);
                }
                //current_num_doors += 1;
            }
        }
        //}
    }
   
}
