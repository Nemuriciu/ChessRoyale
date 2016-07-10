using UnityEngine;
using System.Collections;

public class Behavior : MonoBehaviour
{
    public Material Blacks;
    public Material Whites;

    public GameObject[] chess_pieces;
    private GameObject obj;
    private SquareGUI grid_script;
    private TurnScript turn_script;
    private Check_Collision[] col_scripts;
    public GameObject selected_piece;
    public GameObject highlighted;
    public string material;

    //private bool validMove;

    void Start()
    {
        obj = GameObject.Find("Game_Board");
        grid_script = obj.GetComponent<SquareGUI>();
        turn_script = obj.GetComponent<TurnScript>();

        col_scripts = new Check_Collision[chess_pieces.Length];

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
                    case "Untagged":
                        break;

                    default:
                        if (selected_piece)
                        {
                            if (GetPawnMoves(hit.transform.gameObject, true) <= 0)
                            {
                                selected_piece = null;
                                highlighted = null;
                                material = null;

                                MakeMove(hit.transform.gameObject);
                                turn_script.current_turn = (turn_script.current_turn) ? false : true;
                            }
                        }
                        else
                            GetPawnMoves(hit.transform.gameObject, false);
                        break;                    
                }
            }
        }
    }

    int GetPawnMoves(GameObject obj, bool mode)
    {
        /* Delete Highlighted */
        if (mode)
        {
            if (material == "Whites (Instance)")
                highlighted.GetComponent<Renderer>().material = Whites;
            else
                highlighted.GetComponent<Renderer>().material = Blacks;
        }

        for (int i = 0; i < chess_pieces.Length; i++)
        {
            if(chess_pieces[i].Equals(obj))
            {
                string type = obj.transform.parent.transform.parent.name;

                /* Invalid moves */
                if (type == "Whites" && turn_script.current_color != "White") return 0;
                else if (type == "Blacks" && turn_script.current_color != "Black") return 0;

                GameObject temp = col_scripts[i].square;

                for (int j = 0; j < 8; j++)
                    for (int k = 0; k < 8; k++)
                        if (grid_script.grid[j][k].Equals(temp))
                        {
                            selected_piece = obj;
                            highlighted = grid_script.grid[j][k];
                            material = highlighted.GetComponent<Renderer>().material.name;

                            grid_script.grid[j][k].GetComponent<Renderer>().material.color = Color.green;
                            return 1;
                        }
            }
        }

        return 0;
    }

    void MakeMove(GameObject obj)
    {
        Debug.Log("Moving to" + obj.tag);
    }
}
