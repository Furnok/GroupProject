using UnityEngine;

public class S_CheckPoint : MonoBehaviour
{
    [Header("Output Data")]
    [SerializeField] private RSO_RespawnPoint respawnPoint;

    [Header("Parameters")]
    [SerializeField] private Vector3 offset;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            respawnPoint.Value = transform.position + offset;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Vector3 respawnPosition = transform.position + offset;

        Gizmos.DrawSphere(respawnPosition, 0.2f);
    }
}
