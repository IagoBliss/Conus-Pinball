using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePersistence : MonoBehaviour
{
    // Método para recuperar os registros do "GameData".
     public static GameData LoadData()
    {
        // Recupera o registro do Score.
        int tScore = PlayerPrefs.GetInt("reg_score");
        // Recupera o registro do Name.
        string tName = PlayerPrefs.GetString("reg_name");
        // Recupera o registro do Balls.
        int tBalls = PlayerPrefs.GetInt("reg_balls");
        // Recupera o registro do Time.
        float tTime = PlayerPrefs.GetFloat("reg_time");
        // Recupera  o registro do Sound
        int tSound = PlayerPrefs.GetInt("reg_sound");

        int tMil = PlayerPrefs.GetInt("reg_achmil");

        int tInicio = PlayerPrefs.GetInt("reg_achinicio");

        int tInst = PlayerPrefs.GetInt("reg_achInst");

        int tCtrl = PlayerPrefs.GetInt("reg_achctrl");



        // Objeto "tGameData" recebe os registros recuperados.
        GameData tGameData = new GameData()
        {
            Score = tScore,
            Name = tName,
            Balls = tBalls,
            Time = tTime,
            Sound = tSound,
            achInst = tInst,
            achCtrl = tCtrl,
            achInicio = tInicio,
            achMil = tMil
        };

        return tGameData;
    }

    // Método que grava os registros recebidos.
    public static void SaveData (int tempScore)
    {
        // Armazena o Score no registro
        PlayerPrefs.SetInt("reg_score", tempScore);

        // Armazena o Name no registro
        PlayerPrefs.SetString("reg_name", "");

        // Armazena o Balls no registro
        PlayerPrefs.SetInt("reg_balls", 0);

        // Armazena o Time no registro
        PlayerPrefs.SetFloat("reg_time",0);

        PlayerPrefs.SetInt("reg_sound", 1); // <--------

        PlayerPrefs.SetInt("reg_achinicio", 0);

        PlayerPrefs.SetInt("reg_achmil", 0);

        PlayerPrefs.SetInt("reg_achInst", 0);

        PlayerPrefs.SetInt("reg_achctrl", 0);





    }

    // Método para deletar os dados do registro
    public static void DeleteAll()
    {
        Debug.LogError("Deletou os dados do registro");
        PlayerPrefs.DeleteAll();
    }
	
}
