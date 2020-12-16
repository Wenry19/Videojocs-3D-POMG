using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixRotation : MonoBehaviour
{
    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.parent.transform.rotation.x * -1.0f, transform.parent.transform.rotation.y * -1.0f, transform.parent.transform.rotation.z * -1.0f);
    }
}
