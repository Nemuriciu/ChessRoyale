using UnityEngine;
using System.Collections;
using System;

public class SquareGUI : MonoBehaviour
{
    public GameObject[][] grid;
    public GameObject Parent;
    public GameObject Black_Square;
    public GameObject White_Square;
    public float square_size;

    private float x = 0.75f;
    private float y = 3.005f;
    private float z = -14.3f;

    void Start()
    {
        grid = new GameObject[8][];

        for (int i = 0; i < grid.Length; i++)
        {
            grid[i] = new GameObject[8];
        }

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid.Length; j++)
            {
                GameObject temp;

                if ((i % 2 == 0 && j % 2 == 0) || (i % 2 != 0 && j % 2 != 0))
                    temp = (GameObject)Instantiate(Black_Square, new Vector3(i * square_size + x, y, j * square_size + z), Quaternion.identity);
                else
                    temp = (GameObject)Instantiate(White_Square, new Vector3(i * square_size + x, y, j * square_size + z), Quaternion.identity);

                grid[i][j] = temp;
                grid[i][j].transform.parent = Parent.transform;
                grid[i][j].AddComponent<BoxCollider>();
                grid[i][j].tag = "Square";
            }
        }
    }

    void Update()
    {
        
    }
}
