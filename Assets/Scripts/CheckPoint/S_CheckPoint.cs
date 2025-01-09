using UnityEngine;

public class S_CheckPoint : MonoBehaviour
{
    [SerializeField] private RSO_RespawnPoint rSO_RespawnPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rSO_RespawnPoint.RespawnPoint = transform.position;
        }
    }
}
