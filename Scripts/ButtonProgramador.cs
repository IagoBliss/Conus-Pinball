using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonProgramador : MonoBehaviour
{
    public void RegZero()
    {
        PlayerPrefs.SetInt("reg_achinicio", 0);

        PlayerPrefs.SetInt("reg_achmil", 0);

        PlayerPrefs.SetInt("reg_achInst", 0);

        PlayerPrefs.SetInt("reg_achctrl", 0);

        PlayerPrefs.SetInt("reg_sound", 1); // <--------
    }
}
