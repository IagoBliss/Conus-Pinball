using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchInGame : MonoBehaviour
{
    public Animator achCtrlPopUp;
    public Animator achInicioPopUp;
    public Animator achMilPopUp;
    public AudioSource achSound;



    void Start()
    {
        
    }


    void Update()
    {
        if(CountCtrl.contRightCtrl == 100 || CountCtrl.contLeftCtrl == 100)
        {
            PlayerPrefs.SetInt("reg_achCtrl", 1);
            achCtrlPopUp.SetBool("AnimationBool", true);
            achSound.Play();

        }

        if(CollisionAch.achCollision == true && CollisionInicio.collisionInicio == true)
        {
            PlayerPrefs.SetInt("reg_achInicio", 1);
            achInicioPopUp.SetBool("AnimationBool", true);
            achSound.Play();
        }

        if(GameController.myBalls == 0 && GameController.myPoints >= 2000)
        {
            PlayerPrefs.SetInt("reg_achMil", 1);
            achMilPopUp.SetBool("AnimationBool", true);
            achSound.Play();
        }
    }
}
