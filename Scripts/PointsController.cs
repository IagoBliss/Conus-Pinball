using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    // Recebe os pontos que serão adicionados
    [Range(1f, 100f)]
    public int addPoints;

    void Start()
    {
        // Inicializa os pontos a serem adicionados.
        //addPoints = 1;
    }

    // Se a bola colidir com este gameobject...
    void OnCollisionEnter(Collision myCollision)
    {
        // Adiciona os pontos definidos na minha pontuação.
        GameController.myPoints += addPoints;
    }

}
