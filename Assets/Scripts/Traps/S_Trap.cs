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
    [Header("Values")]
    [SerializeField] private float delayTrap;
    [SerializeField] private float openingTime;
    [SerializeField] private Vector3 spikePosOpen;



    void Start()
    {
        spikeCollider.enabled = false;
        StartCoroutine(Trap(delayTrap, openingTime));
    }

    IEnumerator Trap(float delay, float time)
    {
        yield return new WaitForSeconds(time);
        OpenSpike();
        yield return new WaitForSeconds(time);
        OpenTrap();
        yield return new WaitForSeconds(time);
        CloseTrap();
        yield return new WaitForSeconds(delay);
        StartCoroutine(Trap(delay, time));
    }

    void OpenTrap()
    {
        spikeCollider.enabled = true;
        spikes.transform.position += spikePosOpen;
    }

    void CloseTrap()
    {
        spikeCollider.enabled = false;
        spikes.transform.position -= spikePosOpen;
        spikes.SetActive(false);
    }
    void OpenSpike()
    {
        spikes.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hit Trap");
            playerTakeDamage?.Fire.Invoke();
        }
    }
}
