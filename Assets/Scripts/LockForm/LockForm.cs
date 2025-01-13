using UnityEngine;

public class LockForm : MonoBehaviour
{
    private bool isLockForm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<CaracterController>().FormLock(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<CaracterController>().FormLock(false);
        }
    }
}
