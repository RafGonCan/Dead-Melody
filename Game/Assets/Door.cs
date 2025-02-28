using JetBrains.Annotations;
using OkapiKit;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{

    private Animator _animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame

    public void Update()
    {
        
        if(Input.GetKey(KeyCode.C))
        {
             _animator.SetTrigger("Door_Triguer");
        }
       

    }
}
