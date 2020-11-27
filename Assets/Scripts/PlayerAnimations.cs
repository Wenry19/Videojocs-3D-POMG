using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("jumpAnimation");
        }
    }

    IEnumerator jumpAnimation()
    {
        int count = 0;
        int aux = 0;
        float speedY = rb.velocity.y;
        float speedX = rb.velocity.x;

        if (speedY > 0 && speedX > 0) aux = -1;
        else if (speedY < 0 && speedX < 0) aux = -1;
        else if (speedY > 0 && speedX < 0) aux = 1;
        else if (speedY < 0 && speedX > 0) aux = 1;

        while (count < 4) {
            transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, count * 10.0f * aux);
            count += 1;

            yield return new WaitForSeconds(0.01f);
        }
        while (count >= 0) {
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
        
    }
}
