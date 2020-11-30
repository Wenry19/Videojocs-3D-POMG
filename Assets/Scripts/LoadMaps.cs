using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class LoadMaps : MonoBehaviour
{
    Vector3 map_pos;
    public TextAsset map;
    public GameObject Wall;
    public GameObject colliderInferior, colliderSuperior, colliderIzquierdo, colliderDerecho;
    // Start is called before the first frame update
    void generarCollidersInferiores(int[,] matrix)
    {
        bool lineStarted = false;
        int startLine = 0;
        for (int i = 0; i < 11; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                if (i + 1 < 11 && matrix[i, j] == 1 && matrix[i + 1, j] == 0)
                {
                    if (!lineStarted)
                    {
                        lineStarted = true;
                        startLine = j;
                    }
                }
                else
                {
                    if (lineStarted)
                    {
                        lineStarted = false;
                        int size = j - startLine;
                        float mid = (startLine + ((size - 1) / 2.0f));
                        GameObject obj = (GameObject)Instantiate(colliderInferior, new Vector3(-9.5f + mid + map_pos.x, 5.0f - i + map_pos.y, 0.0f), Quaternion.identity);
                        obj.transform.localScale = new Vector3(size, 1, 1);
                        obj.transform.parent = transform;

                    }
                }
            }
        }
    }
    void generarCollidersSuperiores(int[,] matrix)
    {
        bool lineStarted = false;
        int startLine = 0;
        for (int i = 1; i < 11; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                if (matrix[i, j] == 1 && matrix[i - 1, j] == 0)
                {
                    if (!lineStarted)
                    {
                        lineStarted = true;
                        startLine = j;
                    }
                }
                else
                {
                    if (lineStarted)
                    {
                        lineStarted = false;
                        int size = j - startLine;
                        float mid = (startLine + ((size - 1) / 2.0f));
                        GameObject obj = (GameObject)Instantiate(colliderSuperior, new Vector3(-9.5f + mid + map_pos.x, 5.0f - i + map_pos.y, 0.0f), Quaternion.identity);
                        obj.transform.localScale = new Vector3(size, 1, 1);
                        obj.transform.parent = transform;

                    }
                }
            }
        }
    }
    void generarCollidersDerechos(int[,] matrix)
    {
        bool lineStarted = false;
        int startLine = 0;
        for (int j = 0; j < 19; j++)
        {
            for (int i = 0; i < 11; i++)
            {
                if (matrix[i, j] == 1 && matrix[i, j + 1] == 0)
                {
                    if (!lineStarted)
                    {
                        lineStarted = true;
                        startLine = i;
                    }
                }
                else
                {
                    if (lineStarted)
                    {
                        lineStarted = false;
                        int size = i - startLine;
                        float mid = (startLine + ((size - 1) / 2.0f));
                        GameObject obj = (GameObject)Instantiate(colliderDerecho, new Vector3(-9.5f + j + map_pos.x, 5.0f - mid + map_pos.y, 0.0f), Quaternion.identity);
                        obj.transform.localScale = new Vector3(1, size, 1);
                        obj.transform.parent = transform;

                    }
                }
            }
        }
    }
    void generarCollidersIzquierdos(int[,] matrix)
    {
        bool lineStarted = false;
        int startLine = 0;
        for (int j = 1; j < 20; j++)
        {
            for (int i = 0; i < 11; i++)
            {
                if (matrix[i, j] == 1 && matrix[i, j - 1] == 0)
                {
                    if (!lineStarted)
                    {
                        lineStarted = true;
                        startLine = i;
                    }
                }
                else
                {
                    if (lineStarted)
                    {
                        lineStarted = false;
                        int size = i - startLine;
                        float mid = (startLine + ((size - 1) / 2.0f));
                        GameObject obj = (GameObject)Instantiate(colliderIzquierdo, new Vector3(-9.5f + j + map_pos.x, 5.0f - mid + map_pos.y, 0.0f), Quaternion.identity);
                        obj.transform.localScale = new Vector3(1, size, 1);
                        obj.transform.parent = transform;
                    }
                }
            }
        }
    }

    void Start()
    {
        map_pos = transform.position;
        string tiles = map.text;
        string[] lines = Regex.Split(tiles, "\n");
        int[,] matrix = new int[11, 20];

        for (int i = 0; i < 11; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                if (lines[i][j] == '1')
                {
                    GameObject obj = (GameObject)Instantiate(Wall, new Vector3(-9.5f + j + map_pos.x, 5.0f - i + map_pos.y, 0.0f), transform.rotation);
                    obj.transform.parent = transform;
                    matrix[i, j] = 1;
                }
                else
                {
                    matrix[i, j] = 0;
                }
            }
        }

        generarCollidersInferiores(matrix);
        generarCollidersSuperiores(matrix);
        generarCollidersDerechos(matrix);
        generarCollidersIzquierdos(matrix);
        
    }
    // Update is called once per frame
    void Update()
    {

    }
}
