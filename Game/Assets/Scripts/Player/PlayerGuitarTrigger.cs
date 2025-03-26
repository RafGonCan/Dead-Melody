using UnityEngine;

public class PlayerGuitarTrigger : MonoBehaviour
{
    [SerializeField] private ParticleSystem rippleEffectPS;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) { GuitarPlayA(); }
        if (Input.GetKeyDown(KeyCode.S)) { GuitarPlayS(); }
        if (Input.GetKeyDown(KeyCode.D)) { GuitarPlayD(); }
    }

    private void RippleEffect()
    {
        rippleEffectPS.Play();

        return;
    }


    private void GuitarPlayA()
    {
        RippleEffect();
        return;
    }
    private void GuitarPlayS()
    {
        RippleEffect();
        return;
    }
    private void GuitarPlayD()
    {
        RippleEffect();
        return;
    }
}
