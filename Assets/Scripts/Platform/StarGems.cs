using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGems : MonoBehaviour
{
    [SerializeField] float resetTime = 3f;
    [SerializeField] AudioClip pickUpSound;
    [SerializeField] ParticleSystem pickupVFX;

    AudioSource audioSource;

    new Collider collider;

    MeshRenderer meshRenderer;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        collider = GetComponent<Collider>();

        meshRenderer = GetComponentInChildren<MeshRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.CanAirJump = true;

            meshRenderer.enabled = false;
            collider.enabled = false;

            SoundEffectPlayer.audioSource.PlayOneShot(pickUpSound);
            //audioSource.PlayOneShot(pickUpSound);
            Instantiate(pickupVFX, transform.position, Quaternion.identity);
            Invoke("Reset", resetTime);
        }
    }

    void Reset()
    {
        meshRenderer.enabled = true;
        collider.enabled = true;
    }
}
