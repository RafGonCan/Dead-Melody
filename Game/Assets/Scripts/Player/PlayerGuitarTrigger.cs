using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerGuitarTrigger : MonoBehaviour
{
    private ParticleSystem rippleEffectPS;

    private int comboValue = 0;

    public int ComboValue => comboValue;
    
    private bool keyA = false;
    private bool keyS = false;
    private bool keyD = false;



    public void Start()
    {
        if (rippleEffectPS == null)
        {
            Debug.LogWarning("Ripple Effect Particle System is not assigned in the inspector.");
        }
    }
    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {

            keyA = true;


        }
        else if (Input.GetKeyUp(KeyCode.A))
        {

            keyA = false;


        }
        if (Input.GetKeyDown(KeyCode.S))
        {

            keyS = true;


        }
        else if (Input.GetKeyUp(KeyCode.S))
        {

            keyS = false;


        }
        if (Input.GetKeyDown(KeyCode.D))
        {

            keyD = true;


        }
        else if (Input.GetKeyUp(KeyCode.D))
        {

            keyD = false;


        }

        if (keyA)
        {

            Debug.Log("Combo Value 1 Key A pressed");
            comboValue = 1;

        }
        if (keyS)
        {

            Debug.Log("Combo Value 2 Key S pressed");
            comboValue = 2;

        }
        if (keyD)
        {

            Debug.Log("Combo Value 3 Key D pressed");
            comboValue = 3;

        }
        if (keyA && keyS && keyD)
        {
            Debug.Log("Combo Value 4 Key A, S and D pressed");
            comboValue = 4;

        }
        else if (keyA && keyS)
        {
            Debug.Log("Combo Value 5 Key A and S pressed");
            comboValue = 5;

        }
        else if (keyA && keyD)
        {
            Debug.Log("Combo Value 6 Key A and D pressed");
            comboValue = 6;

        }
        else if (keyS && keyD)
        {
            Debug.Log("Combo Value 7 Key S and D pressed");
            comboValue = 7;

        }

    }

    private void RippleEffect()
    {
        rippleEffectPS.Play();

        return;
    }
}
