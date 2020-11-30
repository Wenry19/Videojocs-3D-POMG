using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorManagement : MonoBehaviour
{
    public int num_doors;
    public GameObject[] doors;
    int current_num_doors = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (num_doors == current_num_doors) {
            ButtonActivation ba = GetComponentInParent<ButtonActivation>();
            ba.doors = doors;
            current_num_doors += 1; //para cortarlo todo
            //esto antes estaba en el trigger pero no funcionaba pork para que enviase doors a ba tenia que volver a detectar trigger enter
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(doors);
        bool already_in = false;
        if (current_num_doors < num_doors)
        {
            for (int i = 0; i < current_num_doors; i++)
            {
                if (doors[i].GetInstanceID() == other.GetInstanceID())
                {
                    already_in = true;
                }
            }
            if (!already_in && other.CompareTag("Wall"))
            {
                if (current_num_doors == 0)
                {
                    doors = new GameObject[] { other.gameObject };
                    current_num_doors += 1;
                }
                else
                {
                    List<GameObject> aux_list = new List<GameObject>(doors);
                    aux_list.Add(other.gameObject);
                    doors = aux_list.ToArray();
                    current_num_doors += 1;
                }
            }
        }
    }
   
}
