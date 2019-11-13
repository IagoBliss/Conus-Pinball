using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    // Recebe meu Audio Source.
    public AudioSource myAudioSource;

	void Start ()
    {
        // Recebe acesso a todos os atributos do componente.
        myAudioSource = GetComponent<AudioSource>();
	}

    // Quando a sphere colidir com o gameObject desse script...
    void OnCollisionEnter(Collision myCollision)
    {
        // Executa meu Audio Source apartir do inicio.
        myAudioSource.Play(0);
    }
}
