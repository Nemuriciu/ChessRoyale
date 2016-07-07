using UnityEngine;
using System.Collections;

public class Behavior : MonoBehaviour
{
    public GameObject[] chess_pieces;
    private GameObject obj;
    private SquareGUI grid_script;
    private Check_Collision[] col_scripts;

    private GameObject[] current_selected;

    void Start()
    {
        obj = GameObject.Find("Game_Board");
        grid_script = obj.GetComponent<SquareGUI>();

        col_scripts = new Check_Collision[chess_pieces.Length];
        current_selected = new GameObject[64];

        for (int i = 0; i < chess_pieces.Length; i++)
        {
            col_scripts[i] = chess_pieces[i].GetComponent<Check_Collision>();
        }
        
    }

    void Update()
    { 
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                //Debug.Log(hit.transform.gameObject.tag);

                switch (hit.transform.gameObject.tag)
                {
                    case "Pawn":
                        GetPawnMoves(hit.transform.gameObject);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    void GetPawnMoves(GameObject obj)
    {
        for (int i = 0; i < chess_pieces.Length; i++)
        {
            if(current_selected.Length != 0)
                foreach (GameObject item in current_selected)
                {

                }
                    //GetComponent<Renderer>().material = 

            if(chess_pieces[i].Equals(obj))
            {
                GameObject temp = col_scripts[i].square;

                for (int j = 0; j < 8; j++)
                    for (int k = 0; k < 8; k++)
                        if (grid_script.grid[i][j].Equals(temp))
                        {
                            grid_script.grid[i][j + 1].GetComponent<Renderer>().material.color = Color.green;
                        }
            }
        }
    }
}
