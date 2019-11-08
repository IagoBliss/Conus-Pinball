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
    public static GameObject achCtrl;
    public static GameObject achInicio;
    public static GameObject achMil;
    public AudioSource achSound;
    public Animator achPopUp;
    /*public bool achInst = false;
    public bool achCtrl = false;
    public bool achInicio = false;
    public bool achMil = false;*/




    void Start()
    {
        achMil = MilPanel;
        achCtrl = CtrlPanel;
        achInicio = InicioPanel;
    }

   
    void Update()
    {

        // SE achInst for verdadeiro...
        if (PlayerPrefs.GetInt("reg_achInst") == 1)
        {
            // Chama o método InstAch.
            InstAch();
        }

       
    }
    public void InstAch()
    {
        achSound.Play();

        achPopUp.SetBool("AchInst", true);
        achTitle.SetActive(true);
        achDesc.SetActive(true);
        JogInPanel.SetActive(true);

     }

    public void ButtonInst()
    {
        // Transforma achInst em verdadeiro.
        PlayerPrefs.SetInt("reg_achInst", 1);
    }
}
