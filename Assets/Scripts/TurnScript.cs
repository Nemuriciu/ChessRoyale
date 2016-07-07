using UnityEngine;
using System.Collections;

public class TurnScript : MonoBehaviour {

    public string current_color;
    public bool current_turn;
    
	void Start ()
    {
        current_color = "White";
        current_turn = true;
	}
	
	void Update ()
    {
        switch (current_turn)
        {
            case true:
                current_color = "White";
                break;
            case false:
                current_color = "Black";
                break;
        }
	}
}
