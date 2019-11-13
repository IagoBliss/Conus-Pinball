using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAch : MonoBehaviour
{
    public static bool achCollision;

    public GameObject collision2;

    public static int collision2Static;
    
    void Start()
    {
       
    }

    
    void Update()
    {
        if(collision2Static == 0)
        {
            collision2.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider myCollider)
    {
        if (myCollider.gameObject.CompareTag("myBall"))
        {
            achCollision = true;
            collision2.SetActive(true);
            collision2Static = 1;
        }
        
    }
}
