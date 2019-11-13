using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSensor : MonoBehaviour

{    
    // Definir qual o numero do sensor para a câmera.
    public int sensorNumber;

    // Método sensor de área.
     private void OnTriggerEnter(Collider myCollider)
    {
        if (myCollider.CompareTag("myBall"))
        {
            // Atribui o valor do sensor para o controlador de câmeras.
            SwitchCameras.camNum = sensorNumber;
        }
    }
}
