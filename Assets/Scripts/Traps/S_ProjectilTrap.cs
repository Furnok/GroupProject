using System.Collections;
using UnityEngine;

public class S_ProjectilTrap : MonoBehaviour
{
    [Header("Output Data")]
    [SerializeField] private RSE_ProjectilLaunch projectilLaunch;

    [Header("References")]
    [SerializeField] private GameObject projectilePrefabs;

    [Header("Parameters")]
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private float fireRate;

    private void Start()
    {
        StartCoroutine(LaunchProjectile(fireRate));
    }

    /// <summary>
    /// Launch a Projectil
    /// </summary>
    /// <param name="delay"></param>
    /// <returns></returns>
    private IEnumerator LaunchProjectile(float delay)
    {
        Instantiate(projectilePrefabs, projectileSpawnPoint.position, projectileSpawnPoint.rotation);

        projectilLaunch?.Fire.Invoke();

        yield return new WaitForSeconds(delay);

        StartCoroutine(LaunchProjectile(delay));
    }
}
