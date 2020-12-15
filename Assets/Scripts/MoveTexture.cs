using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTexture : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 v = new Vector2(0, 0);
    public float speedX = 2;
    public float speedY = 2;
    Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        v.x += speedX * Time.deltaTime;
        v.y += speedY * Time.deltaTime;

        rend.material.SetTextureOffset("_MainTex", v);

    }
}
