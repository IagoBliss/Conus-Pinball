using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTest : MonoBehaviour
{
    // Propriedade e acessadores do tipo "GameData"
     public static GameData myGameData { get; set; }

    // Recebe o valor do registro.
    public Text myText;

    public Text maxScore;

    //public int bestScore;


    // Método para gravar os registros no sistema
    public void SingleUpdate()
    {
        // Acessa o método "SaveData" da classe
        GamePersistence.SaveData(GameController.myPoints);
    }

    // Método para deletar os registros no sistema
    public void DeleteData()
    {
        // Acessa o método "DeleteAll" da classe
        GamePersistence.DeleteAll();
    }

    //Método para recuperar os registros do sistema
    public void OnlyLoad()
    {
        // Acessa o método "LoadData" da classe
        GamePersistence.LoadData();

        myText.text = myGameData.Name;
    }

    void Start()
    {
        myGameData = GamePersistence.LoadData();

        //bestScore = myGameData.Score;

        //bestScore = PlayerPrefs.GetInt("reg_score");

        //maxScore.text = myGameData.Score.ToString();
        //Debug.Log(myGameData.Name);

        //myGameData.Name = "Alexa Bliss";

        //SingleUpdate();

        //Debug.Log(myGameData.Name);


    }



    void Update()
    {

    }

}
