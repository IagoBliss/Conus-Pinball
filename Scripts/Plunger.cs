using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Importar essa biblioteca.

public class Plunger : MonoBehaviour
{
    // Força do pistão.
    private float plungerPower;

    // O valor minimo da força do pistão.
    private float minPower = 0f;

    // O valor máximo da força do pistão.
    [Range(10f,1000f)]
    public float maxPower = 100f;

    // O valor a ser incrementado no plunger.
    [Range(10f, 100f)]
    public float plungerIncrements = 50f;

    // Indica que a bola está pronta para voltar ao jogo.
    public bool isBallReady;

    // Lista do tipo RigidBody que recebe as bolas que serão repostas em jogo.
    List<Rigidbody> ballList;

    // Receberá o slider UI.
    public Slider powerSliderCanvas; 

	void Start ()
    {
        // Definido a lista como do tipo RigidBody
        ballList = new List<Rigidbody>();

        // Define o valor minimo do Slider.
        powerSliderCanvas.minValue = minPower;

        // Define o valor máximo do Slider.
        powerSliderCanvas.maxValue = maxPower;
	}
	
	void Update ()
    {
        // Se a bola estiver preparada para disparar...
        if (isBallReady)
        {
            // Ativa e exibe o meu Slider.
            powerSliderCanvas.gameObject.SetActive(true);
        }
        else
        {
            // Desativa e esconde o meu Slider.
            powerSliderCanvas.gameObject.SetActive(false);
        }

        // Valor do meu slider recebe o valor da força do pistão.
        powerSliderCanvas.value = plungerPower;

        // Verificar a quantidade de gameobjects nas minha BallList...
        if(ballList.Count > 0)
        {
            // Indicar que a bola está pronta para voltar ao jogo.
            isBallReady = true;

            // Se for pressionado a barra de espaços ou o botão X do GamePad...
            if (Input.GetKey(KeyCode.Space) || Input.GetButton("Fire3"))
            {
                // ...E se a força do pistão for menor ou igual a força máxima...
                if (plungerPower <= maxPower)
                {
                    // Força do pistão recebe um incremento de 50 a cada deltatime.
                    //plungerPower += 50f * Time.deltaTime; //REMOVIDO!
                    plungerPower += plungerIncrements * Time.deltaTime;
                }
            }

            // Se a barra de espaço ou o botão X do GamePad for solta(o)...
            if (Input.GetKeyUp(KeyCode.Space) || Input.GetButtonUp("Jump"))
            {
                Debug.Log("soltou...");
                // Percorrer a quantidade de elementos na minha BallList.
                foreach(Rigidbody myRB in ballList)
                {
                    // Aplicar a força ao gameobject da lista.
                    myRB.AddForce(plungerPower * Vector3.back);
                }
            }
        }
        // senão...
        else
        {
           // Debug.Log("caiu aqui...");
            // Indicar que a bola NÃO está pronta para voltar ao jogo.
            isBallReady = false;

            // Zerar a forçar armazenada no pistão.
            plungerPower = minPower;
        }
    }

    // Ao entrar na área de colisão...
    private void OnTriggerEnter(Collider myCollider)
    {
        // Comparar se o gameobject tem uma Tag...
        if (myCollider.gameObject.CompareTag("myBall"))
        {
            // Adiciona o meu gameobject a minha ballList!
            ballList.Add(myCollider.gameObject.GetComponent<Rigidbody>());
        }
    }

    // Ao sair da área de colisão...
    private void OnTriggerExit(Collider myCollider)
    {
        // Comparar se o gameobject tem uma Tag...
        if (myCollider.gameObject.CompareTag("myBall"))
        {
            // Remover o meu gameobject da minha ballList!
            ballList.Remove(myCollider.gameObject.GetComponent<Rigidbody>());
        }

        // Força do pistão é zerada.
        plungerPower = minPower;
    }
}
