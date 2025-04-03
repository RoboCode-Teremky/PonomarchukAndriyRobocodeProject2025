using UnityEngine;
using UnityEngine.Splines;

public class Enemy : MonoBehaviour
{
    [SerializeField] int hp = 3;
    SplineAnimate splineAnimate;
    Animator animator;
    SpriteRenderer spriteRenderer;
    public Coins coins;
    [SerializeField] public int reward = 1;
    [SerializeField] public int damage = 1;
    void Start()
    {
        splineAnimate = GetComponent<SplineAnimate>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 tangent = splineAnimate.Container.EvaluateTangent(splineAnimate.ElapsedTime / splineAnimate.Duration);
        if (tangent.x > 0.1f) spriteRenderer.flipX = true;
        else spriteRenderer.flipX = false;
        animator.SetFloat("X", tangent.x);
        animator.SetFloat("Y", tangent.y);
    }

    // Ворог отримує пошкодження. Перевіряємо, чи він вижив?
    public bool TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0) {
            splineAnimate.Pause();
            animator.SetTrigger("Death");
            coins.Addcoins(reward);
            Destroy(gameObject, 1.0f);
            return false;
        }
        return true;
    }
}