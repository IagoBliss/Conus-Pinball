using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    // Anexar esse script numa câmera.


    // Recebe um game object que será meu alvo
    public GameObject myTarget;      
                               
	void Update ()
    {
        // Alterar a posição de direcionamento do pai desse script.
        transform.LookAt(myTarget.transform);
	}
}
