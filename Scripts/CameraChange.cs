using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{

    // APENAS DUAS CAMERAS PARA TESTE!!!

    public Camera CameraAtiva;

    public Camera CameraInativa1;

    public Camera CameraInativa2;

    public Camera CameraInativa3;

    public Camera CameraInativa4;

    void Start ()
    {
      
	}
	
    void OnTriggerEnter(Collider myCollider)
    {
        if (myCollider.CompareTag("myBall"))
        {
          CameraAtiva.enabled = true;

          CameraInativa1.enabled = false;

            CameraInativa2.enabled = false;

            CameraInativa3.enabled = false;

            CameraInativa4.enabled = false;
        }
        
    }




















	void Update ()
    {
		
	}
}
