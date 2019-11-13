using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCameras : MonoBehaviour
{
    // Array que recebe minha lista de câmeras.
    public GameObject[] myCameras = new GameObject[0];

    // Recebe o número da câmera.
    [Range(0,10)] // De 0 até 10.
    public int cameraNumber;

    // Atributo estático para receber o número da câmera.
    public static int camNum;
	
	
	void Update ()
    {
        // Atribui a "cameraNumber" o valor do atributo estático.
        cameraNumber = camNum;
        // Se o numero da câmera que estou selecionando for menor que o numero de cãmeras na minha lista...
        if(cameraNumber < myCameras.Length)
        {
           // Chama o método para ativar a câmera e ativa a câmera que possuir o mesmo indice no Array de câmeras.
          ActiveCamera(myCameras[cameraNumber]);
        }
       
	}

    // Método para ativar uma determinada câmera.
    // Precisa receber a câmera que será ativa.
    public void ActiveCamera(GameObject myCamera)
    {
        // Percorre a minha lista de câmeras. 
        for (int i = 0; i < myCameras.Length; i++)

        // Desativar todas as câmeras  da lista.
        myCameras[i].SetActive(false);

         //TurnOffCameras();
        myCamera.SetActive(true);
    }

    public void TurnOffCameras()
    {
        // Percorre a minha lista de câmeras. 
        for (int i = 0; i < myCameras.Length; i++)

        // Desativar todas as câmeras  da lista.
        myCameras[i].SetActive(false);

    }
}
