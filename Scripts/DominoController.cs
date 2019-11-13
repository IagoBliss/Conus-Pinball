using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoController : MonoBehaviour
{

    // Este Array receberá os dominos de um determinado grupo.
    // Inicialmente estará recebendo 3 dominos.
    public DominoHandler[] dominos = new DominoHandler[3];

 // Atributo de contador de dominos acionados.
    int Count = 0;

    // Armazena a pontuação para quando o jogador acertar TODOS os dominos do grupo.
    [Range(0, 250)]
    public int bonusPoint = 30;
    // Definir o tempo de recuperação dos dominos.
    [Range(1f,10f)]
    public float waitingTime = 3.0f;

    // Flag que armazena temporariamente a possibilidade de resetar o grupo de dominos.
    public static  bool goReset = false;

    public bool Flag = false;

    void Update ()
    {
        // Reseta o valor do contador a cada Update.
        Count = 0;

        if (!Flag)
        {
          for (int indice = 0; indice < dominos.Length; indice++)
        {
            // Percorre todos os indices do Array dominos e compara o atributo "Ativador" do componente <DominoHandler>.
            if (dominos[indice].gameObject.GetComponent<DominoHandler>().ativador)
            {
                Debug.Log("Count = " + Count);
                Count++;  // Incrementa mais 1 ao count
            }
        }
        }
       

        // Se o acumulado no contador for igual o tamanho do Array "dominos"...
        if (Count == dominos.Length && !Flag)
        {
            Flag = true;
            Debug.Log("Todos foram vistos");

            //  Reseta a posição dos dominos depois de um determinado tempo.
            StartCoroutine(WaitingTime());
         
        }

        // Se minha Flag estiver ativa...
        if (goReset)
        {
            // Chama o método "ResetGroup".
            ResetGroup();
            // E desativa a flag "goReset".
            goReset = false;
        }
    }
    // Método para ser chamado em uma corrotina.
    IEnumerator WaitingTime()
    {
        // Retorna uma construção paralela a execução do programa.
        yield return new WaitForSeconds(5f);

       
        Debug.Log("WaitingTime()");

       
        // Chama o método  para resetar o grupo de dominos.
        ResetGroup(); 
    }

    // Resetar o grupo de dominos.
    public  void ResetGroup()
    {
        // Para(indice começando em zero);
        // Se o indice for menor que o tamanho do meu Array incrementa mais 1 ao valor do indice.
        Debug.Log("Reset");
        for (int indice = 0; indice < dominos.Length; indice++)
        {
            GameController.myPoints += bonusPoint;
            // Percorre todos os indices do Array dominos e acessa o método "ResetPositions" do componente <DominoHandler>.
            dominos[indice].gameObject.GetComponent<DominoHandler>().ResetPosition();

            Flag = false;
        }
    }
}
