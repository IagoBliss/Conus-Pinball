using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoHandler : MonoBehaviour
{
    // Atributo para armazenar o quanto eu quero que seja deslocado na posição vertical o meu dado.
    [Range(-10, 10)] // Delimito o quanto eu vou poder deslocar.
    public float yPosicao = -0.49f;

    // Armazena o x,y,z inicial e final.
    Vector3 posicaoInicial, posicaoFinal;

    // 
    public bool ativador;

    //public static bool ativador2;

    public static bool resetSingle;

    private BoxCollider myBoxCollider;

    // Armazena a pontuação especifica deste domino.
    [Range(1, 100)]
    public int addPoints = 10;

    void Start ()
    {
        // Inicializa acesso aos atributos box collider
        myBoxCollider = GetComponent<BoxCollider>();

        // Armazenando a  posição inicial do domino.
        posicaoInicial = transform.position;
        // Armazenando a  posição final do domino.
        posicaoFinal = new Vector3(transform.position.x,  // Posição atual em x do domino.
            yPosicao,  // Posição determinada y para o domino.
            transform.position.z); // Posição atual em z do domino.


        Debug.Log(gameObject.name);

      
	}
	                                       
	void Update ()
    {
        // Se o meu ativador for verdadeiro...
        if (ativador)
        {
            // O domino recebe a posição final
            transform.position = posicaoFinal;

            myBoxCollider.enabled = false;
        }
        else // Caso contrario...
        {
            // O domino recebe a posição inicial.
            transform.position = posicaoInicial;

            myBoxCollider.enabled = true;
        }

       /* if (resetSingle)
        {
            // O domino recebe a posição final
            transform.position = posicaoFinal;

            
        }
        else // Caso contrario...
        {
            // O domino recebe a posição inicial.
            transform.position = posicaoInicial;

           
        }*/
        //transform.position = new Vector3(transform.position.x, yPosicao, transform.position.z);
    }

    // Quando algum gameObject colidir com o objeto que está com esse script...
    private void OnCollisionEnter(Collision myCollision)
    {
        // E esse gameObject possuir a tag "myBall"...
        if (myCollision.gameObject.CompareTag("myBall"))
        {
            // Torna verdadeiro o ativador do domino, indicando queo mesmo recebeu uma colisão.
           ativador = true;
           
            //ativador2 = true;
            // Acesso o atributo myPoints do script GameController e adiciono o valor de addPoints
            GameController.myPoints += addPoints;
        }
        
    }

    // Os dominos voltam a sua posição inicial quando: 
    // - Todos os dominos de um determinado grupo foram derrubados;
    // - Quando o jogador perder uma esfera ou reiniciar a partida.

    public void ResetPosition()
    {
        Debug.Log("ResetPositions()");

        // Ativador fica falso
        ativador = false;


    }

    /*public static void ResetSingle()
    {
        // Ativador fica falso
        resetSingle = false; 

    }*/
}
