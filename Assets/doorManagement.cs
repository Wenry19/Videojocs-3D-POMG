using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorManagement : MonoBehaviour
{
    public int num_doors;
    List<GameObject> doors;
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
        bool already_in = false;
        if (doors.Count < num_doors)
        {
            for (int i = 0; i < doors.Count; i++)
            {
                if (doors[i].GetInstanceID() == other.GetInstanceID())
                {
                    already_in = true;
                }
            }
            if (!already_in && other.CompareTag("Wall"))
            {
                doors.Add(other.gameObject);
            }
        }
        else {
            ButtonActivation ba = GetComponentInParent<ButtonActivation>();
            ba.doors = doors.ToArray();
        }

    }
   
}
