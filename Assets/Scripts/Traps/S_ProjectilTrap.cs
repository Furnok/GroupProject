using System.Collections;
using UnityEngine;

public class S_ProjectilTrap : MonoBehaviour
{
    [SerializeField] private RSE_EventChannel eventLauchProjectile;
    [SerializeField] private GameObject projectilePrefabs;
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private float fireRate;

    void Start()
    {
        StartCoroutine(LaunchProjectile(fireRate));
    }

    IEnumerator LaunchProjectile(float delay)
    {
        Instantiate(projectilePrefabs, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        eventLauchProjectile.RaiseEvent();
        yield return new WaitForSeconds(delay);
        StartCoroutine(LaunchProjectile(delay));
    }
}
