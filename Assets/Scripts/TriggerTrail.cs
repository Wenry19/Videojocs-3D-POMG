using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTrail : MonoBehaviour
{
    Rigidbody rb_player;
    Vector3 position_player;
    public float offset = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb_player = GetComponentInParent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        position_player = transform.parent.transform.position;
        float posX = 0.0f;
        float posY = 0.0f;
        if (rb_player.velocity.x > 0) posX = position_player.x - offset;
        else if (rb_player.velocity.x < 0) posX = position_player.x + offset;
        if (rb_player.velocity.y > 0) posY = position_player.y - offset;
        else if (rb_player.velocity.y < 0) posY = position_player.y + offset;

        transform.position = new Vector3(posX, posY, 0.0f);

        //Debug.Log(posX);
        //Debug.Log(posY);

    }

    private void OnParticleTrigger()
    {
        //transform.parent.gameObject.SetActive(false);
    }
}
