using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    //REFERENCES 
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Idle() 
    {
        anim.SetFloat("Speed", 0);
    }

    private void Walk()
    {
        anim.SetFloat("Speed", 0.5f);
    }

    private void Run()
    {
        anim.SetFloat("Speed", 1);
    }

}
