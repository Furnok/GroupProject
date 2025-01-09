using UnityEngine;

public class S_CheckPoint : MonoBehaviour
{
    [Header("Output Data")]
    [SerializeField] private RSO_RespawnPoint respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            respawnPoint.Value = transform.position;
        }
    }
}
