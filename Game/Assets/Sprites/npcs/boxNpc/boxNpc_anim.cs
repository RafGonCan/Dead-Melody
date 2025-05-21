using UnityEngine;

public class boxNpc_anim : MonoBehaviour
{
    public Animator anim;
    private bool isLifting = false;

    void Start()
    {
        anim = GetComponent<Animator>(); 
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isLifting)
            {
                anim.SetTrigger("boxonfloor");
            }
            else
            {
                anim.SetTrigger("liftbox");
            }

            isLifting = !isLifting;
        }
    }
}
