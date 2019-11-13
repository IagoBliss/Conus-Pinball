using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionChange : MonoBehaviour
{
    // Recebe o transform do objeto que "spawnará" o objeto "colidido".
    public Transform myDestiny;

    // Quando um gameObject colidir com este gameobject...
    private void OnCollisionEnter(Collision myCollision)
    {
        // Passa o "position" do destino para o colisor.
        myCollision.gameObject.transform.position = myDestiny.position;
    }
}
