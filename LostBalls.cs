using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostBalls : MonoBehaviour
{

    public GameObject PanelGameOver;

    // Grava a maior pontuação
   /*public int MaxScore(int recorded, int current)
    {
        // Receberá a nova pontuação maxima
        int newRecord = 0;

        // Se a pontuação atual for maior que a pontuação armazenada...
        if(current > recorded)
        {
            newRecord = current;
        }

        return newRecord;
    }*/

        // Sensor da bola perdida
	public void OnTriggerEnter(Collider myCollider)
    {
       
        // Se o Collider possuir a tag "myBall"...
        if (myCollider.gameObject.CompareTag("myBall"))
        {

            Debug.Log("Perdeu uma bola");
            // Decrementa a quantidade de bolas.
            GameController.myBalls--;
            //DominoHandler.resetSingle = false;
            // Se a quantidade de bolas for menor ou igual a zero...
            if (GameController.myBalls <= 0)
            {
                Destroy(myCollider.gameObject);
                PanelGameOver.SetActive(true);
                UpdatePoints.SetStats();
                GameController.FinalSound();
                //Time.timeScale = 0;
                // Atualizar o registro de pontuação;

         


                //GamePersistence.SaveData( MaxScore(PlayerPrefs.GetInt("reg_score"), GameController.myPoints));
                if (GameController.myPoints > PlayerPrefs.GetInt("reg_score"))
                {
                    //Debug.Log("entrou...");
                    GamePersistence.SaveData(GameTest.myGameData.Score);
                    GamePersistence.SaveData(GameController.myPoints);
                }
                else
                {
                    //Debug.Log("Registro" + PlayerPrefs.GetInt("reg_score"));
                    //Debug.Log("Score atual " + GameTest.myGameData.Score);
                }

                DominoController.goReset = true;

                //DominoHandler.ResetSingle();
            }
        }
    }
   
}
