using UnityEngine;

public class PlayerGuitarTrigger : MonoBehaviour
{
    [SerializeField] private ParticleSystem rippleEffectPS;

    public int comboValue = 0;

    public void Start()
    {
        if (rippleEffectPS == null)
        {
            Debug.LogError("Ripple Effect Particle System is not assigned in the inspector.");
        }
    }
    public void Update()
    {
        Input.GetKeyDown(KeyCode.A);
        Input.GetKeyDown(KeyCode.S);
        Input.GetKeyDown(KeyCode.D);

        if (Input.GetKeyDown(KeyCode.A))
        {

            comboValue = 1 ;
            Debug.Log("Combo Value: " + comboValue);
            RippleEffect();

        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            comboValue = 2;
            Debug.Log("Combo Value: " + comboValue);
            RippleEffect();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            comboValue = 3;
            Debug.Log("Combo Value: " + comboValue);
            RippleEffect();
        }

        if (Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.D))
        {
            comboValue = 4;
            Debug.Log("Combo Value: " + comboValue);
            RippleEffect();
        }

        if (Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.S))
        {
            comboValue = 5;
            Debug.Log("Combo Value: " + comboValue);
            RippleEffect();
        }
        if (Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.D))
        {
            comboValue = 6;
            Debug.Log("Combo Value: " + comboValue);
            RippleEffect();
        }

        if (Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.D))
        {
            comboValue = 7;
            Debug.Log("Combo Value: " + comboValue);
            RippleEffect();
        }

        if (Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.D))
        {
            comboValue = 8;
            Debug.Log("Combo Value: " + comboValue);
            RippleEffect();
        }

    }

    private void RippleEffect()
    {
        rippleEffectPS.Play();

        return;
    }
}
