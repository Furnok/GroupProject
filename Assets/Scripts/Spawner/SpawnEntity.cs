using UnityEngine;

public class SpawnEntity : MonoBehaviour
{
    private bool isActive;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isActive)
        {
            isActive = true;
        }
    }
}
