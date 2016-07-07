using UnityEngine;
using System.Collections;

public class Check_Collision : MonoBehaviour
{
    public GameObject square;

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Square")
        {
            square = col.gameObject;
        }
    }
}
