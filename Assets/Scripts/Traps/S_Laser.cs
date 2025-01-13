using UnityEngine;

public class S_Laser : MonoBehaviour
{
    [Header("Output Data")]
    [SerializeField] private RSE_PlayerTakeDamage playerTakeDamage;

    [Header("Parameters")]
    [SerializeField] private int damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTakeDamage?.Fire.Invoke(damage);
        }
    }
}
