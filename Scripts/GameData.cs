using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{

    // Propriedade para receber o score.
   public int Score { get; set; }

    // Propriedade para receber o nome.
    public string Name { get; set; }

    // Propriedade para receber o numero de bolas.
    public int Balls { get; set; }


    // Propriedade para receber o tempo da partida
    public float Time { get; set; }

    // Propriedade para receber se o som está ativo
    public int Sound { get; set; }

    public int achInst { get; set; }

    public int achCtrl { get; set; }

    public int achMil { get; set; }

    public int achInicio { get; set; }



}
