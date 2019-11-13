using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameQuit : MonoBehaviour
{
    public void Quit()
    {
        // Se estiver executando dentro do editor do Unity...
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else // Termina a execução da aplicação *.exe.
        Application.Quit();
    #endif
    }
}
