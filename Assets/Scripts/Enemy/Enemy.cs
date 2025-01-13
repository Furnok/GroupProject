using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("Output Data")]
    [SerializeField] private RSO_PlayerPos playerPos;
    [SerializeField] private RSO_PlayerSize playerSize;
    [SerializeField] private RSE_PlayerTakeDamage playerTakeDamage;
    [SerializeField] private RSE_PlayerRespawn playerRespawn;

    [Header("References")]
    [SerializeField] private NavMeshAgent agent;

    [Header("Parameters")]
    [SerializeField] private float speed;
    [SerializeField] private float life;
    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;

    private SpawnEntity spawnEntity;

    private void OnEnable()
    {
        playerRespawn.Fire += ResetEnemy;
    }

    private void OnDisable()
    {
        playerRespawn.Fire -= ResetEnemy;
    }

    private void Update()
    {
        Vector3 targetPos = playerPos.Value;

        agent.destination = new Vector3(targetPos.x - playerSize.Value, targetPos.y - playerSize.Value, targetPos.z - playerSize.Value);
    }

    public void Spawner(SpawnEntity spawn)
    {
        spawnEntity = spawn;
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
            spawnEntity?.EntityDead();

            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Enemy Reset
    /// </summary>
    private void ResetEnemy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTakeDamage?.Fire.Invoke(damage);
        }
    }
}
