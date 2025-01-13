using System.Collections;
using UnityEngine;

public class S_Projectile : MonoBehaviour
{
    [Header("Output Data")]
    [SerializeField] private RSE_ProjectilLaunch projectilLaunch;
    [SerializeField] private RSE_PlayerTakeDamage playerTakeDamage;

    [Header("References")]
    [SerializeField] private Rigidbody rb;

    [Header("Parameters")]
    [SerializeField] private float destroyDelay;
    [SerializeField] private float lauchForce;
    [SerializeField] private int damage;

    private void OnEnable()
    {
        projectilLaunch.Fire += ProjectileMove;
    }

    private void OnDisable()
    {
        projectilLaunch.Fire -= ProjectileMove;
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
        if (other.CompareTag("Player"))
        {
            playerTakeDamage?.Fire.Invoke(damage);

            Destroy(gameObject);
        }
        else if(other.CompareTag("Wall"))
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
