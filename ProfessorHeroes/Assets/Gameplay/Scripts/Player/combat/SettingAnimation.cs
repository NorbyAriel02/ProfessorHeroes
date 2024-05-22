using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingAnimation : MonoBehaviour
{
    public Animator animator;
    public float speed = 6;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("AttackSpeed", speed);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
            animator.SetFloat("AttackSpeed", speed);
    }
}
