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


    public void GuitarPlayA()
    {
        RippleEffect();
        return;
    }
    public void GuitarPlayS()
    {
        RippleEffect();
        return;
    }
    public void GuitarPlayD()
    {
        RippleEffect();
        return;
    }
}
