using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private NavMeshAgent agent;

    [Header("Parameters")]
    [SerializeField] private float speed;
    [SerializeField] private float life;
    [SerializeField] private float attackCooldown;

    /// <summary>
    /// Take Damage
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
    {
        life = life - damage;

        Dead();
    }

    private void Dead()
    {
        if(life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
