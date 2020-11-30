using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class LoadMaps : MonoBehaviour
{
    Vector3 map_pos;
    public TextAsset map;
    public GameObject Wall;
    public GameObject Door;
    public GameObject InvisibleDoor;
    public GameObject colliderInferior, colliderSuperior, colliderIzquierdo, colliderDerecho;
    GameObject parentOfWalls;
    GameObject parentOfColliders;
    // Start is called before the first frame update
    void generarCollidersInferiores(int[,] matrix, int index)
    {
        bool lineStarted = false;
        int startLine = 0;
        for (int i = 0; i < 11; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                if ((i == 10 && matrix[i, j] == index) || (i + 1 < 11 && matrix[i, j] == index && matrix[i + 1, j] != index)) // Si es la ultima fila de abajo o una posicion realmente valida.
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
                        if (index == 2) obj.transform.tag = "Door";
                        if (index == 3) obj.transform.tag = "InviDoor";
                        obj.transform.localScale = new Vector3(size, 1, 1);
                        obj.transform.parent = parentOfColliders.transform;

                    }
                }
            }
            if (lineStarted)
            {
                lineStarted = false;
                int size = 20 - startLine;
                float mid = (startLine + ((size - 1) / 2.0f));
                GameObject obj = (GameObject)Instantiate(colliderInferior, new Vector3(-9.5f + mid + map_pos.x, 5.0f - i + map_pos.y, 0.0f), Quaternion.identity);
                if (index != 1) obj.transform.tag = "Door";
                obj.transform.localScale = new Vector3(size, 1, 1);
                obj.transform.parent = parentOfColliders.transform;
            }
        }
    }
    void generarCollidersSuperiores(int[,] matrix, int index)
    {
        bool lineStarted = false;
        int startLine = 0;
        for (int i = 0; i < 11; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                if ((i == 0 && matrix[i, j] == index) || matrix[i, j] == index && (matrix[i - 1, j] != index))
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
                        if (index == 2) obj.transform.tag = "Door";
                        if (index == 3) obj.transform.tag = "InviDoor";
                        obj.transform.localScale = new Vector3(size, 1, 1);
                        obj.transform.parent = parentOfColliders.transform;

                    }
                }
            }
            if (lineStarted)
            {
                lineStarted = false;
                int size = 20 - startLine;
                float mid = (startLine + ((size - 1) / 2.0f));
                GameObject obj = (GameObject)Instantiate(colliderSuperior, new Vector3(-9.5f + mid + map_pos.x, 5.0f - i + map_pos.y, 0.0f), Quaternion.identity);
                if (index == 2) obj.transform.tag = "Door";
                if (index == 3) obj.transform.tag = "InviDoor";
                obj.transform.localScale = new Vector3(size, 1, 1);
                obj.transform.parent = parentOfColliders.transform;
            }
        }
    }
    void generarCollidersDerechos(int[,] matrix, int index)
    {
        bool lineStarted = false;
        int startLine = 0;
        for (int j = 0; j < 20; j++)
        {
            for (int i = 0; i < 11; i++)
            {
                if ((j == 19 && matrix[i, j] == index) || matrix[i, j] == index && matrix[i, j + 1] != index) //(i == 0 && matrix[i, j] == index) || matrix[i, j] == index && (matrix[i - 1, j] != index)
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
                        if (index == 2) obj.transform.tag = "Door";
                        if (index == 3) obj.transform.tag = "InviDoor"; obj.transform.localScale = new Vector3(1, size, 1);
                        obj.transform.parent = parentOfColliders.transform;

                    }
                }
            }
            if (lineStarted)
            {
                lineStarted = false;
                int size = 11 - startLine;
                float mid = (startLine + ((size - 1) / 2.0f));
                GameObject obj = (GameObject)Instantiate(colliderDerecho, new Vector3(-9.5f + j + map_pos.x, 5.0f - mid + map_pos.y, 0.0f), Quaternion.identity);
                if (index == 2) obj.transform.tag = "Door";
                if (index == 3) obj.transform.tag = "InviDoor"; obj.transform.localScale = new Vector3(1, size, 1);
                obj.transform.parent = parentOfColliders.transform;
            }
        }
    }
    void generarCollidersIzquierdos(int[,] matrix, int index)
    {
        bool lineStarted = false;
        int startLine = 0;
        for (int j = 0; j < 20; j++)
        {
            for (int i = 0; i < 11; i++)
            {
                if ((j == 0 && matrix[i, j] == index) || matrix[i, j] == index && matrix[i, j - 1] != index)
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
                        if (index == 2) obj.transform.tag = "Door";
                        if (index == 3) obj.transform.tag = "InviDoor";
                        obj.transform.localScale = new Vector3(1, size, 1);
                        obj.transform.parent = parentOfColliders.transform;
                    }
                }
            }
            if (lineStarted)
            {
                lineStarted = false;
                int size = 11 - startLine;
                float mid = (startLine + ((size - 1) / 2.0f));
                GameObject obj = (GameObject)Instantiate(colliderIzquierdo, new Vector3(-9.5f + j + map_pos.x, 5.0f - mid + map_pos.y, 0.0f), Quaternion.identity);
                if (index == 2) obj.transform.tag = "Door";
                if (index == 3) obj.transform.tag = "InviDoor";
                obj.transform.localScale = new Vector3(1, size, 1);
                obj.transform.parent = parentOfColliders.transform;
            }

        }
    }

    void Start()
    {
        parentOfWalls = new GameObject("ParentOfWalls");
        parentOfWalls.transform.position = transform.position;
        parentOfWalls.transform.parent = gameObject.transform;

        parentOfColliders = new GameObject("ParentOfColliders");
        parentOfColliders.transform.position = transform.position;
        parentOfColliders.transform.parent = gameObject.transform;


        map_pos = transform.position;
        string tiles = map.text;
        string[] lines = Regex.Split(tiles, "\n");
        int[,] matrix = new int[11, 20];

        for (int i = 0; i < 11; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                if (lines[i][j] == '1') // Pared
                {
                    GameObject obj = (GameObject)Instantiate(Wall, new Vector3(-9.5f + j + map_pos.x, 5.0f - i + map_pos.y, 0.0f), transform.rotation);
                    obj.transform.parent = parentOfWalls.transform;
                    matrix[i, j] = 1;
                }
                else if (lines[i][j] == '2') // Puerta inicialmente visible
                {
                    GameObject obj = (GameObject)Instantiate(Door, new Vector3(-9.5f + j + map_pos.x, 5.0f - i + map_pos.y, 0.0f), transform.rotation);
                    obj.transform.parent = parentOfWalls.transform;
                    matrix[i, j] = (int)System.Char.GetNumericValue(lines[i][j]);
                }
                else if (lines[i][j] == '3') // Puerta inicialmente invisible
                {
                    GameObject obj = (GameObject)Instantiate(InvisibleDoor, new Vector3(-9.5f + j + map_pos.x, 5.0f - i + map_pos.y, 0.0f), transform.rotation);
                    obj.transform.parent = parentOfWalls.transform;
                    matrix[i, j] = (int)System.Char.GetNumericValue(lines[i][j]);
                }
                else
                {
                    matrix[i, j] = 0;
                }
            }
        }

        generarCollidersInferiores(matrix, 1);
        generarCollidersSuperiores(matrix, 1);
        generarCollidersDerechos(matrix, 1);
        generarCollidersIzquierdos(matrix, 1);

        generarCollidersInferiores(matrix, 2);
        generarCollidersSuperiores(matrix, 2);
        generarCollidersDerechos(matrix, 2);
        generarCollidersIzquierdos(matrix, 2);

        generarCollidersInferiores(matrix, 3);
        generarCollidersSuperiores(matrix, 3);
        generarCollidersDerechos(matrix, 3);
        generarCollidersIzquierdos(matrix, 3);

    }
    // Update is called once per frame
    void Update()
    {

    }
}
