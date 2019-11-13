using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxManager : MonoBehaviour
{
    // Recebendo um material para usar como SkyBox.
    // Lembrete: Arrays possuem indices iniciando em  {0,1,2,3...}
    // Portanto, no objeto abaixo iniciamos o Array com o tamanho de 1 indice, o qual é o indice 0.
    public Material[] mySkyBox = new Material[2];

    // Atribuindo um tempo de espera para trocar o SkyBox.
    [Range(0f, 10f)]
    public float WaitingTime;

    //public AudioSource lastBall;

    //public static AudioSource myLastBall;

    void Awake()
    {   // Atribuiumponente  RenderSettings.skybox
        // O primeiro indice do Array SkyBox.
        RenderSettings.skybox = mySkyBox[0];

        //lastBall = myLastBall;
    }



    IEnumerator ChangeSky()
    {
        // Retorna a essa interface após sua construçãodefinida pelo tempo.
        yield return new WaitForSeconds(WaitingTime);

        // Recebe o segundo SkyBox do Array.
        RenderSettings.skybox = mySkyBox[1];
    }

    void Update()
    {
        if(GameController.myBalls == 1)
        {
            // Inicia uma corrotina e chama a interface Enumerator.
            StartCoroutine(ChangeSky());

            /*GameController.myAudioSource.enabled = false;
            myLastBall.enabled = true;
            myLastBall.Play();*/
        }
    }
}
