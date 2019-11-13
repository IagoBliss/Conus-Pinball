using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountCtrl : MonoBehaviour
{
    public static int contRightCtrl;

    public static int contLeftCtrl;

    void Start()
    {
        
    }

   
    void Update()
    {
      if(Input.GetKeyDown("left ctrl"))
        {
            contLeftCtrl++;
        }

        if (Input.GetKeyDown("right ctrl"))
        {
            contRightCtrl++;
        }
    }
}
