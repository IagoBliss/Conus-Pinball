using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionInicio : MonoBehaviour
{
    public static bool collisionInicio;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider myCollider)
    {
        if (myCollider.gameObject.CompareTag("myBall"))
        { 
            collisionInicio = true;
        }

    }
}
