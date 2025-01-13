using System.Collections;
using UnityEngine;

public class Projectils : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody rb;

    [Header("Parameters")]
    [SerializeField] private int damage;
    [SerializeField] private float destroyDelay;
    [SerializeField] private float lauchForce;

    private void Start()
    {
        ProjectileMove();
    }

    /// <summary>
    /// Projectile Movement
    /// </summary>
    private void ProjectileMove()
    {
        rb.linearVelocity = transform.forward * lauchForce;

        StartCoroutine(DelayBeforeDestroy(destroyDelay));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(damage);

            Destroy(gameObject);
        }
        else if (!other.CompareTag("Invisible"))
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Delay of Life
    /// </summary>
    /// <param name="delay"></param>
    /// <returns></returns>
    private IEnumerator DelayBeforeDestroy(float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(gameObject);
    }
}
