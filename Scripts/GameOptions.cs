using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // Inserir para usar o Text!

public class GameOptions : MonoBehaviour
{
    // Recebe um Text inserido num botão.
    public  Text myTextSoundButtonOptions;

    // Armazena um string para quando o som estiver desligado.
    public  string textSoundButtonOptionOff = "Som desligado";

    // Armazena um string para quando o som estiver ligado.
  public  string textSoundButtonOptionOn = "Som ligado";

    // Armazena o estado atual do som.
    private bool onOffSoundButton = true;

    // Recebe um Slider de volume
    public Slider mySoundSlider;

    public void SetVolume()
    {
        PlayerPrefs.SetFloat("reg_fsound",mySoundSlider.value);
    }

    // Método para trocar o texto do botão
    public void ChangeButton()
    {
        // Se o valor da variavel for falso...
        if (onOffSoundButton)
        {
            // Troca o text pelo digitado pelo usuario.
            myTextSoundButtonOptions.text = textSoundButtonOptionOn;

            PlayerPrefs.SetInt("reg_sound", 1);

            // Inverte o valor booleano.
            onOffSoundButton = false;

            //PlayerPrefs.GetInt("reg_sound") = 1;
        }
        // Se o valor da variavel NÃO for falso...
        else
        {

            myTextSoundButtonOptions.text = textSoundButtonOptionOff;

            PlayerPrefs.SetInt("reg_sound", 0);
            onOffSoundButton = true;
            //PlayerPrefs.GetInt("reg_sound") = 0;
        }
    }

   
    // Pega o texto inserido pelo usuario e atribui ele no texto do botão.
    void Start ()
    {

        PlayerPrefs.SetInt("reg_sound", 0);
        mySoundSlider.value = PlayerPrefs.GetFloat("reg_fsound");
        myTextSoundButtonOptions.text = textSoundButtonOptionOff;

	}
}
