using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Fight : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private PlayerInput input;
    public int consecutiveAttacks;
    [SerializeField] private bool canAttack;
    [SerializeField] private Image cooldown;
    [SerializeField] private float timerSpecialAttack = 15;
    [SerializeField] private GameObject specialAttackRespawner;
    [SerializeField] private GameObject prefabWave;


    void Start()
    {
        animator = GetComponent<Animator>();
        input = GetComponent<PlayerInput>();
        consecutiveAttacks = 0;
        canAttack = true;
    }

    void Update()
    {
        timerSpecialAttack += Time.deltaTime;
        cooldown.fillAmount = timerSpecialAttack / 20;
        if (input.actions["Hit"].WasPressedThisFrame())
        {
            StartCombo();
        }
        animator.SetBool("SpecialHit", false);

        if (input.actions["SpecialHit"].WasPressedThisFrame() && animator.GetCurrentAnimatorStateInfo(0).IsName("Motion") && timerSpecialAttack >= 20)
        {
            StartSpecialAttack();
            timerSpecialAttack = 0;
        }
    }
    public void SpecialAttackWave()
    {
        Instantiate(prefabWave, specialAttackRespawner.transform.position, specialAttackRespawner.transform.rotation);
        prefabWave.SetActive(true);
    }

    private void StartSpecialAttack()
    {
        animator.SetBool("SpecialHit", true);
    }

    void StartCombo()
    {
        if ((animator.GetCurrentAnimatorStateInfo(0).IsName("Motion") && consecutiveAttacks == 0) || (animator.GetCurrentAnimatorStateInfo(0).IsName("Knight_Jump") && consecutiveAttacks == 0))
        {
            canAttack = true;
        }
        if (canAttack)
        {
            consecutiveAttacks++;
        }
        if (consecutiveAttacks == 1)
        {
            animator.SetInteger("Hit", 1);
        }
    }

    public void CheckCombo()
    {
        canAttack = false;

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Knight_Attack1") && consecutiveAttacks == 1)
        {
            animator.SetInteger("Hit", 0);
            canAttack = true;
            consecutiveAttacks = 0;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Knight_Attack1") && consecutiveAttacks >= 2)
        {
            animator.SetInteger("Hit", 2);
            canAttack = true;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Knight_Attack2") && consecutiveAttacks == 2)
        {
            animator.SetInteger("Hit", 0);
            canAttack = true;
            consecutiveAttacks = 0;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Knight_Attack2") && consecutiveAttacks >= 3)
        {
            animator.SetInteger("Hit", 3);
            canAttack = true;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Knight_Attack3"))
        {
            animator.SetInteger("Hit", 0);
            canAttack = true;
            consecutiveAttacks = 0;
        }
    }

}
