using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ativa a execução do script no editor da Unity.
[ExecuteInEditMode]
public class FollowMe : MonoBehaviour
{
    public GameObject myGameObject;

    // Recebe a distancia entre os dois GameObjects.
    // No eixo X
    [Header("Distancias entre posições:")]
    [Range(0f,100f)]
    public float xDistance = 0f;
    // No eixo Y
    [Range(0f, 100f)]
    public float yDistance = 0f;
    // No eixo Z
    [Range(0f, 100f)]
    public float zDistance = 0f;

    // Recebe a transform.position com as distancias.
    // Lembrete: Vector 3 é um Array de 3 posiçoes que recebe x,y e z.
    Vector3 followPosition;

    [Header("Angulos de rotação por eixo:")]
    [Range(-110f,100f)]
    public float xRotation = 0f, yRotation = 0f, zRotation = 0f;

    // Recebe o transform.rotation com graus de rotação.
    Vector3 followRotation;

    void Start ()
    {
		
	}
	
	
	void Update ()
    {
        // Recebe a posição "x" do objeto com esse script. 
        followPosition.x = xDistance + transform.position.x;
        // Recebe a posição "y" do objeto com esse script. 
        followPosition.y = yDistance + transform.position.y;
        // Recebe a posição "z" do objeto com esse script. 
        followPosition.z = zDistance + transform.position.z;

        followRotation.x = xRotation + transform.rotation.x;

        followRotation.y = yRotation + transform.rotation.y;

        followRotation.z = zRotation + transform.rotation.z;

        // Atribuindo a posição do myGameObject ao Vector 3 followPosition.
        myGameObject.transform.position = followPosition;

        // myGameObject recebe a posição de quem estiver com esse script.
        //myGameObject.transform.position = transform.position;

        // Atribuindo ao rotation (que é um Quaternion) um valor em Vector3. mas é preciso fazer um "cast".
        myGameObject.transform.rotation = Quaternion.Euler(followRotation);
    }
}
