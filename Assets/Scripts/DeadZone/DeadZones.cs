using UnityEngine;

public class DeadZones : MonoBehaviour
{
    [Header("Output Data")]
    [SerializeField] private RSE_PlayerTakeDamage playerTakeDamage;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerTakeDamage?.Fire.Invoke();
        }
    }
}
