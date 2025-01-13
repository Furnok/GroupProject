using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("Output Data")]
    [SerializeField] private RSO_PlayerPos playerPos;
    [SerializeField] private RSO_PlayerSize playerSize;
    [SerializeField] private RSE_PlayerTakeDamage playerTakeDamage;

    [Header("References")]
    [SerializeField] private NavMeshAgent agent;

    [Header("Parameters")]
    [SerializeField] private float speed;
    [SerializeField] private float life;
    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;

    private void Update()
    {
        Vector3 targetPos = playerPos.Value;

        agent.destination = new Vector3(targetPos.x - playerSize.Value, targetPos.y - playerSize.Value, targetPos.z - playerSize.Value);
    }

    /// <summary>
    /// Take Damage
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
    {
        life = life - damage;

        Dead();
    }

    /// <summary>
    /// Enemy Dead
    /// </summary>
    private void Dead()
    {
        if(life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTakeDamage?.Fire.Invoke(damage);
        }
    }
}
