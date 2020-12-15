using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTrail : MonoBehaviour
{
    float timer = 1.0f;
    bool can_kill = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        can_kill = timer <= 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && can_kill) {
            GameManager.Instance.playSound("Explosion");
            other.gameObject.transform.parent.GetChild(2).GetComponent<AvisarColision>().callAnimacionMuerte();
        }
    }
}
