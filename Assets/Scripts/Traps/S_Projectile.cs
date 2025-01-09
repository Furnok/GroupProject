using System.Collections;
using UnityEngine;

public class S_Projectile : MonoBehaviour
{
    [SerializeField] private RSE_EventChannel eventLauchProjectile;
    [SerializeField] private RSE_EventChannel eventTriggerProjectile;
    [SerializeField] private RSE_PlayerTakeDamage playerTakeDamage;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float destroyDelay;
    [SerializeField] private float lauchForce;


    private void ProjectileMove()
    {
        rb.linearVelocity = transform.forward * lauchForce;
        StartCoroutine(DelayBeforeDestroy(destroyDelay));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hit Projectile");
            eventTriggerProjectile.RaiseEvent();
            playerTakeDamage?.Fire.Invoke();
            Destroy(gameObject);
        }
    }
    IEnumerator DelayBeforeDestroy(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    private void OnEnable()
    {
        eventLauchProjectile.RegisterListener(ProjectileMove);
    }

    private void OnDisable()
    {
        eventLauchProjectile.UnregisterListener(ProjectileMove);
    }
}
