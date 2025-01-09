using UnityEngine;

public class S_Laser : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private RSE_EventChannel eventTriggerLaser;
    [Header("References")]
    [SerializeField] private Collider laserCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hit Laser");
            eventTriggerLaser.RaiseEvent();
        }
    }
}
