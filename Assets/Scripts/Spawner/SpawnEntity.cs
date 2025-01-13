using UnityEngine;

public class SpawnEntity : MonoBehaviour
{
    [Header("Output Data")]
    [SerializeField] private RSE_PlayerRespawn playerRespawn;

    [Header("References")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Doors doorBack;
    [SerializeField] private Doors doorFront;

    [Header("Parameters")]
    [SerializeField] private int numberEntity;

    private bool isActive;
    private int numberEnemy;

    private void OnEnable()
    {
        playerRespawn.Fire += ResetSpawn;
    }

    private void OnDisable()
    {
        playerRespawn.Fire -= ResetSpawn;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isActive)
        {
            isActive = true;

            for(int i = 0; i < numberEntity; i++)
            {
                GameObject Entity = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                Entity.GetComponent<Enemy>().Spawner(this);

            }

            doorBack.CloseDoor();

            numberEnemy = numberEntity;
        }
    }

    /// <summary>
    /// A Entity Die
    /// </summary>
    public void EntityDead()
    {
        numberEnemy--;

        if(numberEnemy <= 0)
        {
            doorFront.OpenDoor();
            doorBack.OpenDoor();
        }
    }

    /// <summary>
    /// Spawn Reset
    /// </summary>
    private void ResetSpawn()
    {
        isActive = false;

        doorBack.OpenDoor();
    }
}
