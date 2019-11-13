using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGetInputField : MonoBehaviour
{
    public static Text myText;
    public InputField myInputField;


    public void UpdateText()
    {
        myText.text = myInputField.text;
    }
	
	
	void Update ()
    {
        // Se a string text do myInputField.text não estiver em caixa alta...
        if (myInputField.text != myInputField.text.ToUpper())
        {
            // Recebe ele mesmo em caixa alta
            myInputField.text = myInputField.text.ToUpper();
        }
	}
}
