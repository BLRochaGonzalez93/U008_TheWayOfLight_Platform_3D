using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.VFX;

public class BossState : MonoBehaviour
{
    [Header("General")]
    [SerializeField] int routine;
    [SerializeField] float timer;
    [SerializeField] float timeRoutine;
    [SerializeField] Animator anim;
    [SerializeField] Quaternion angle;
    [SerializeField] float grade;
    [SerializeField] GameObject target;
    [SerializeField] bool isAttacking;
    [SerializeField] bool meleeRange;
    [SerializeField] bool rangeRange;
    [SerializeField] GameObject[] hits;
    [SerializeField] int hitSelect;
    [SerializeField] int speed;

    [Header("Flamethrower")]
    [SerializeField] GameObject vfxFlame;
    [SerializeField] GameObject fireBallPrefab;
    [SerializeField] GameObject mouth;
    [SerializeField] GameObject fireRotatorPoint;

    [Header("Fire Ball")]
    [SerializeField] GameObject fireBallPrefab2;

    [SerializeField] GameObject tailShock;

    [Header("Phase State")]
    [SerializeField] float minHP;
    [SerializeField] float maxHP;
    [SerializeField] Image lifeBar;
    [SerializeField] bool isDeath;
    [SerializeField] Vector3 lookDirection;

    public enum State { Idle, Walk, Run, Jump, Attack_Claws, Attack_Tail, Attack_Horns, Attack_Range_FireBall, Attack_Range_Flamethrower, Attack_Range_TailShock, Hurt, Rugid, Death }
    public State state;

    void Start()
    {
        anim = GetComponent<Animator>();
        state = State.Idle;
        tailShock = GameObject.FindGameObjectWithTag("TailShock");
    }

    void Update()
    {
        lookDirection = target.transform.position - transform.position;
        lookDirection.y = 0;
        var rotation = Quaternion.LookRotation(lookDirection);
        mouth.transform.LookAt(target.transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);

        lifeBar.fillAmount = minHP / maxHP;
        minHP = gameObject.GetComponent<DestroyObjects>().NumHits();
        if (minHP > 0)
        {
            timer += Time.deltaTime;
            if (routine >= 5 && routine <= 7)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            
            if (timer >= timeRoutine)
            {
                timer = 0;
                CheckDistance();
                BossBehavior();
            }
        }
        else
        {
            if (!isDeath)
            {
                anim.SetTrigger("Death");
                isDeath = true;
                gameObject.GetComponent<BossState>().enabled = false;
            }
        }
    }

    private void CheckDistance()
    {
        if (Vector3.Distance(transform.position, target.transform.position) < 10 && !isAttacking)
        {
            routine = Random.Range(0, 4);
        }
        else if (Vector3.Distance(transform.position, target.transform.position) > 10 && !isAttacking)
        {
            routine = Random.Range(4, 11);
        }
    }

    public void BossBehavior()
    {
        switch (routine)
        {
            case 0: // Attack_Claws
                anim.SetFloat("Motion", 0f);
                anim.SetBool("Attack", true);
                anim.Play("Boss_Claws");
                state = State.Attack_Claws;
                isAttacking = true;
                speed = 0;
                hitSelect = 0;
                break;
            case 1: // Attack_Tail
                anim.SetFloat("Motion", 0f);
                anim.SetBool("Attack", true);
                anim.Play("Boss_TailAttack");
                state = State.Attack_Tail;
                isAttacking = true;
                hitSelect = 1;
                speed = 0;
                break;
            case 2: // Attack_Horns
                anim.SetFloat("Motion", 0f);
                anim.SetBool("Attack", true);
                anim.Play("Boss_Horned");
                state = State.Attack_Horns;
                isAttacking = true;
                speed = 0;
                hitSelect = 2;
                break;
            case 3: // Rugid
                anim.SetFloat("Motion", 0f);
                anim.SetBool("Attack", true);
                anim.Play("Boss_Rugid");
                state = State.Rugid;
                isAttacking = true;
                speed = 0;
                hitSelect = 4;
                break;
            case 4: // Idle
                anim.SetFloat("Motion", 0f);
                anim.SetBool("Attack", false);
                timer += 1 * Time.deltaTime;
                state = State.Idle;
                speed = 0;
                isAttacking = false;
                break;
            case 5: // Walk
                anim.SetFloat("Motion", 0.5f);
                anim.SetBool("Attack", false);
                state = State.Walk;
                speed = 12;
                isAttacking = false;
                break;
            case 6: // Run
                anim.SetFloat("Motion", 1f);
                anim.SetBool("Attack", false);
                state = State.Run;
                speed = 20;
                isAttacking = false;
                break;
            case 7: // Jump
                anim.SetFloat("Motion", 0f);
                anim.Play("Boss_Jump");
                state = State.Jump;
                speed = 0;
                isAttacking = true;
                speed = 0;
                hitSelect = 3;
                break;
            case 8: // Attack_Range_FireBall:
                anim.SetFloat("Motion", 0f);
                anim.SetBool("Attack", true);
                anim.Play("Boss_FireBall");
                state = State.Attack_Range_FireBall;
                speed = 0;
                isAttacking = true;
                break;
            case 9: // Attack_Range_Flamethrower:
                anim.SetFloat("Motion", 0f);
                anim.SetBool("Attack", true);
                anim.Play("Boss_Flamethrower");
                state = State.Attack_Range_Flamethrower;
                speed = 0;
                isAttacking = true;
                break;
            case 10: // Attack_Range_TailShock:
                anim.SetFloat("Motion", 0f);
                anim.SetBool("Attack", true);
                anim.Play("Boss_TailShock");
                state = State.Attack_Range_TailShock;
                speed = 0;
                isAttacking = true;
                break;
            default:
                break;
        }
    }

    public void StartJump()
    {
        speed = 50;
    }

    public void FinishJump()
    {
        speed = 0;
    }

    public void FinalAnim()
    {
        anim.SetBool("Attack", false);
        isAttacking = false;
    }

    public void ColliderWeaponTrue()
    {
        hits[hitSelect].GetComponent<SphereCollider>().enabled = true;
    }
    public void ColliderWeaponFalse()
    {
        hits[hitSelect].GetComponent<SphereCollider>().enabled = false;
    }

    public void FlamethrowerSkill()
    {
        Instantiate(fireBallPrefab, fireRotatorPoint.transform.position, fireRotatorPoint.transform.rotation);
    }

    public void FireBallSkill()
    {
        Instantiate(fireBallPrefab2, fireRotatorPoint.transform.position, fireRotatorPoint.transform.rotation);
    }

    public void TailShockAttack()
    {
        tailShock.GetComponent<RocksFallDown>().FallDown();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpecialAttack")){
            gameObject.GetComponent<DestroyObjects>().GetHits();
        }
    }
}
