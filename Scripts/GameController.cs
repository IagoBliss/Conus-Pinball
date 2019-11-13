using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Inserido para usar "Text"!

public class GameController : MonoBehaviour
{
    // Armazenar a pontuação do jogador.
    // static permite que eu acesse esse atributo de outra classe.
    public static int myPoints;

    // Armazena o campo de texto responsável pelos meus pontos.
    public Text myTextPoints;

    // Armazena a quantidade de bolas/vidas do jogador.
    public static int myBalls;

    public int numberOfBalls;

    // Armazena o campo de texto responsável pelas bolas disponiveis.
    public Text myTextBalls;

    // Armazena o campo de texto antes do inicio.
    private string textPoints, textBalls;

    // Armazena o que será exibido
    public GameObject PanelPause;

    // Armazena o estado pausado do jogo
    private bool myPause = false;

    // Armazena a pontuação para mostrar no final
    public Text myTextScore;

    public static Text myPlayername;

    //public InputField myInputField;

    public static  AudioSource myAudioSource;

    public static AudioSource myfinalSound;

    public AudioSource myAS1;

    public AudioSource myAS2;

    private float tfsound;

    //public int testePontos;

    //amanha.
    public static void FinalSound()
    {
        Debug.Log("FinalSound");
            myAudioSource.enabled = false;
        //SkyBoxManager.myLastBall.enabled = false;
            myfinalSound.enabled = true;
            myfinalSound.Play();

     }

    void Awake()
    {
        myAudioSource  = myAS1;
        myfinalSound = myAS2;
        Debug.Log(PlayerPrefs.GetInt("reg_sound"));
        tfsound = PlayerPrefs.GetFloat("reg_fsound");

  

        if (PlayerPrefs.GetInt("reg_sound") == 0)
        {
            Debug.Log("Audio desabilitado");
            myAudioSource.volume = 0 * tfsound;
        }
        else
        {

            Debug.Log("Audio habilitado");
            myAudioSource.volume = 1 * tfsound;
        } 
    }



    void Start ()
    {
        Time.timeScale = 1;
        // Zera o atributo pontos
        myPoints = 0;
        // Recebe o campo text do "myTextPoints".
        textPoints = myTextPoints.text;
        
        // Recebe o campo text do "myTextBalls".
        textBalls = myTextBalls.text;

        myBalls = numberOfBalls;

        //myPlayername.text = myInputField.text;

        //myPoints = testePontos;

        
    }
	
	void Update ()
    {

        //myPoints = testePontos;

        /*if( myPoints > PlayFabController.player.StatValue)
        {
            PlayFabController.player.StatValue = myPoints;
        }*/

        // Campo Text Points recebe o valor de points.
        myTextPoints.text = textPoints + myPoints.ToString();

        // Campo Text Balls recebe o valor de balls.
        myTextBalls.text = textBalls + " = " + myBalls.ToString();

        myTextScore.text = "Sua Pontuação foi "+ myPoints.ToString();


        // Quando o Input "Cancel" for pressionado...
        if (Input.GetButtonDown("Cancel"))
        {
            //... e se myPause for falso...
            if (!myPause)
            {
                // Ativa o painel myPause
                PanelPause.SetActive(true);
                Time.timeScale = 0;

                if(PlayerPrefs.GetInt("reg_sound") == 1)
                {
                    myAudioSource.volume = (1 * tfsound) / 2;
                }
              
            }
            //... e se myPause for verdadeiro...
            else
            {
                // Desativa o painel do pause
                PanelPause.SetActive(false);
                Time.timeScale = 1;

                if (PlayerPrefs.GetInt("reg_sound") == 1)
                {
                    myAudioSource.volume = 1 * tfsound;
                }
                   
            }
            // Inverte o myPause
            myPause = !myPause;
        }

        // Quando o Input "Submit" for pressionado e "myPause" for vaerdadeiro.
        if (Input.GetButtonDown("Submit") && myPause)
        {
            
              // Carrega a cena do menu.
              SceneManager.LoadScene(1);
            
        }
    }
}
