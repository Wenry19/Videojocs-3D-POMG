﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    Rigidbody rb;
    Material m;
    bool animationPlayer = false;
    Color current_color;

    PlayerMoves pm;
    // Start is called before the first frame update
    void Start()
    {
        m = GetComponent<Renderer>().material;
        current_color = m.color;
        pm = GetComponent<PlayerMoves>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (pm.notOnRopes())
            {
                StartCoroutine("jumpAnimation");
            }
        }
    }

    IEnumerator jumpAnimation()
    {
        animationPlayer = true;
        int count = 0;
        int aux = 0;


        if (pm.isUp() && pm.isRight()) aux = 1;
        else if (!pm.isUp() && !pm.isRight()) aux = 1;
        else if (pm.isUp()  && !pm.isRight()) aux = -1;
        else if (!pm.isUp() && pm.isRight()) aux = -1;

        while (count < 4 && animationPlayer)
        {
            transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, count * 10.0f * aux);
            count += 1;

            yield return new WaitForSeconds(0.01f);
        }
        while (count >= 0 && animationPlayer)
        {
            transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, count * 10.0f * aux);
            count -= 1;

            yield return new WaitForSeconds(0.01f);
        }
        transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

        yield return null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        animationPlayer = false;
        

    }
    public void callCollisionAnimation()
    {
        StartCoroutine("collisionAnimation");
        StartCoroutine("collisionAnimation");
    }
    public IEnumerator collisionAnimation()
    {
        m.color = new Color(1.0f, 0.0f, 0.0f);
        transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        animationPlayer = false;
        int count = 0;
        float shrink = 0.05f;

        while (count < 4 && !animationPlayer)
        {
            transform.localScale -= new Vector3(shrink, shrink, shrink);
            count += 1;

            yield return new WaitForSeconds(0.05f);
        }
        while (count >= 0 && !animationPlayer)
        {
            transform.localScale += new Vector3(shrink, shrink, shrink);
            count -= 1;

            yield return new WaitForSeconds(0.001f);
        }
        transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        m.color = current_color;

        yield return null;
    }
}
