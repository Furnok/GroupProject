using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Trap : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private RSE_PlayerTakeDamage playerTakeDamage;

    [Header("References")]
    [SerializeField] private GameObject spikes;
    [SerializeField] private Collider spikeCollider;

    [Header("Parameters")]
    [SerializeField] private float delayTrap;
    [SerializeField] private float openingTime;
    [SerializeField] private Vector3 spikePosOpen;

    private void Start()
    {
        spikeCollider.enabled = false;

        StartCoroutine(Trap(delayTrap, openingTime));
    }

    private IEnumerator Trap(float delay, float time)
    {
        yield return new WaitForSeconds(time);

        ShowSpike();

        yield return new WaitForSeconds(time);

        OpenTrap();

        yield return new WaitForSeconds(time);

        CloseTrap();

        yield return new WaitForSeconds(delay);

        StartCoroutine(Trap(delay, time));
    }

    /// <summary>
    /// Show the Spike
    /// </summary>
    private void ShowSpike()
    {
        spikes.SetActive(true);
    }

    /// <summary>
    /// Spike go Up
    /// </summary>
    private void OpenTrap()
    {
        spikeCollider.enabled = true;

        spikes.transform.position += spikePosOpen;
    }

    /// <summary>
    /// Spike go Down
    /// </summary>
    private void CloseTrap()
    {
        spikeCollider.enabled = false;

        spikes.transform.position -= spikePosOpen;

        spikes.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTakeDamage?.Fire.Invoke();
        }
    }
}
