using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.DataModels;
using PlayFab.ProfilesModels;
using PlayFab.Json;
public class Achievements : MonoBehaviour
{
    //public GameObject achPanel;
    public GameObject JogInPanel;
    public GameObject CtrlPanel;
    public GameObject InicioPanel;
    public GameObject MilPanel;
    public GameObject achTitle;
    public GameObject achDesc;
    public static int achCtrl;
    public static  int achInicio;
    public static int achMil;
    public AudioSource achSound;
    public Animator achPopUp;
    /*public bool achInst = false;
    public bool achCtrl = false;
    public bool achInicio = false;
    public bool achMil = false;*/




    void Start()
    {
     
    }

   
    void Update()
    {

        if(achCtrl == 1)
        {
            CtrlPanel.SetActive(true);
        }
        if(achInicio == 1)
        {
            InicioPanel.SetActive(true);
        }
        if(achMil == 1)
        {
            MilPanel.SetActive(true);
        }

        // SE achInst for verdadeiro...
        if (PlayerPrefs.GetInt("reg_achInst") == 1)
        {
            // Chama o método InstAch.
            InstAch();
        }

        if (PlayerPrefs.GetInt("reg_achMil") == 1)
        {
            MilPanel.SetActive(true);
        }

        if (PlayerPrefs.GetInt("reg_achInicio") == 1)
        {
           InicioPanel.SetActive(true);
        }

        if (PlayerPrefs.GetInt("reg_achCtrl") == 1)
        {
            CtrlPanel.SetActive(true);
        }


    }
    public void InstAch()
    {

        achTitle.SetActive(true);
        achDesc.SetActive(true);
        JogInPanel.SetActive(true);

     }

    public void ButtonInst()
    {
        // Transforma achInst em verdadeiro.
        PlayerPrefs.SetInt("reg_achInst", 1);
        achPopUp.SetBool("AchInst", true);
        achSound.Play();
    }
}
