using UnityEngine;

public class SwordController : MonoBehaviour
{
    public float attackCooldown = 0.5f;
    public float sheatheTime = 5.0f;

    private Animator animator;
    private bool isAttacking = false;
    private float lastAttackTime = 0.0f;
    private bool swordDrawn = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Time.time - lastAttackTime > sheatheTime)
        {
            swordDrawn = false;
            animator.SetBool("SwordDrawn", swordDrawn);
        }

        if (Input.GetMouseButtonDown(0) && !isAttacking && Time.time - lastAttackTime > attackCooldown)
        {
            if (!swordDrawn)
            {
                swordDrawn = true;
                animator.SetBool("SwordDrawn", swordDrawn);
                int attackType = Random.Range(1, 4); // Escolhe um dos três movimentos de ataque aleatoriamente
                animator.SetBool("Attack" + attackType, true);
            }
            else
            {
                isAttacking = true;
                lastAttackTime = Time.time;
                int attackType = Random.Range(1, 4); // Escolhe um dos três movimentos de ataque aleatoriamente
                animator.SetBool("Attack" + attackType, true);
            }
        }

        else
        {
            isAttacking = false;
            animator.SetBool("Attack1", false);
            animator.SetBool("Attack2", false);
            animator.SetBool("Attack3", false);
        }

    }
}