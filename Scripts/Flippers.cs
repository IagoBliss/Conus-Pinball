using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flippers : MonoBehaviour
{
    // Posição incial dos flippers
    private float restPosition = 0f;

    // Posição máxima dos flippers quando estão pressionados.
    public float pressedPosition = 45f;

    // Define a aplicação de força dos flippers.
    [Range(1000f, 200000f)] // 1.000 ~ 20.000.
    public float hitStrength = 5000f;

    // Resistencia dos amortecedores dos flippers.
    [Range(100f, 200f)] // 100 ~ 200.
    public float flipperDamper = 100f;

    // Recebe o nome do Input responsável pelo acionamento do flipper.
    public string inputName;

    // Recebe o componente Hinge Joint (Dobradiça)
    private HingeJoint myHingeJoint;

    // Recebe o nome do Input responsável pelo acionamento do flipper, através de um GamePad. "xboxGamePadRight" OU "xboxGamePadRight"
    //public string myAxisName;

    void Start()
    {
        // Recebe acesso aos atributos do componente Hinge Joint.
        myHingeJoint = GetComponent<HingeJoint>();

        // Utiliza a mola do Hinge Joint.
        myHingeJoint.useSpring = true;
    }

    void Update()
    {
        JointSpring myJointSpring = new JointSpring
        {
            // Mola recebe forca de acerto.
            spring = hitStrength,

            // Amortecedor recebe a resistência do flipperdamper.
            damper = flipperDamper
        };

        // Se o valor do eixo for igual a 1...
        if (Input.GetAxis(inputName) == 1)
        {
            // Articulação da mola recebe o angulo de ataque.
            myJointSpring.targetPosition = pressedPosition;
    
        }
        else // Se o valor do eixo for diferente de 1...
        {
            // Articulação da mola recebe o angulo de descanço.
            myJointSpring.targetPosition = restPosition;
        }

        // Mola da minha dobradiça passar o valor da articulação.
        myHingeJoint.spring = myJointSpring;

        // Habiltar e definir os limites.
        myHingeJoint.useLimits = true;
    }
}
