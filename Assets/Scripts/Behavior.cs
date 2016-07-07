using UnityEngine;
using System.Collections;

public class Behavior : MonoBehaviour
{
    public GameObject[] chess_pieces;
    private GameObject obj;
    private SquareGUI grid_script;
    private TurnScript turn_script;
    private Check_Collision[] col_scripts;

    private GameObject[] current_selected;

    void Start()
    {
        obj = GameObject.Find("Game_Board");
        grid_script = obj.GetComponent<SquareGUI>();
        turn_script = obj.GetComponent<TurnScript>();

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
                switch (hit.transform.gameObject.tag)
                {
                    case "Pawn":
                        if(GetPawnMoves(hit.transform.gameObject) > 0)
                            turn_script.current_turn = (turn_script.current_turn) ? false : true;
                        break;
                    default:
                        break;
                }
            }
        }
    }

    int GetPawnMoves(GameObject obj)
    {
        for (int i = 0; i < chess_pieces.Length; i++)
        {
            if(chess_pieces[i].Equals(obj))
            {
                string type = obj.transform.parent.transform.parent.name;            

                /* Invalid moves */
                if(type == "Whites" && turn_script.current_color != "White") return 0;
                else if(type == "Blacks" && turn_script.current_color != "Black") return 0;

                GameObject temp = col_scripts[i].square;
                
                for (int j = 0; j < 8; j++)
                    for (int k = 0; k < 8; k++)
                        if (grid_script.grid[j][k].Equals(temp))
                        {
                            grid_script.grid[j][k].GetComponent<Renderer>().material.color = Color.green;
                            return 1;
                        }                        
            }
        }

        return 0;
    }
}
