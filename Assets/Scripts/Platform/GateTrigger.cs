using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    [SerializeField] AudioClip pickUpAudio;
    [SerializeField] ParticleSystem pickupEffect;

    [SerializeField] VoidEventChannel gateTriggerEventChanels;


    private void OnTriggerEnter(Collider other)
    {

        gateTriggerEventChanels.BoardCast();

        SoundEffectPlayer.audioSource.PlayOneShot(pickUpAudio);
        Instantiate(pickupEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
