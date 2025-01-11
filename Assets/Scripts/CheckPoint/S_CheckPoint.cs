using UnityEngine;

public class S_CheckPoint : MonoBehaviour
{
    [Header("Output Data")]
    [SerializeField] private RSO_RespawnPoint respawnPoint;
    [SerializeField] private RSE_ResetFlag resetFlag;

    [Header("References")]
    [SerializeField] private MeshRenderer flag;

    [SerializeField] private Material red;
    [SerializeField] private Material green;

    [Header("Parameters")]
    [SerializeField] private Vector3 offset;

    private void OnEnable()
    {
        resetFlag.Fire += ResetFlag;
    }

    private void OnDisable()
    {
        resetFlag.Fire -= ResetFlag;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            resetFlag.Fire?.Invoke();

            flag.material = green;
            respawnPoint.Value = transform.position + offset;
        }
    }

    /// <summary>
    /// Reset Flag Color
    /// </summary>
    private void ResetFlag()
    {
        flag.material = red;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Vector3 respawnPosition = transform.position + offset;

        Gizmos.DrawSphere(respawnPosition, 0.2f);
    }
}
