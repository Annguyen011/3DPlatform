using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryGem : MonoBehaviour
{
    [SerializeField] AudioClip pickUpAudio;
    [SerializeField] ParticleSystem pickupEffect;

    private void OnTriggerEnter(Collider other)
    {

        SoundEffectPlayer.audioSource.PlayOneShot(pickUpAudio);
        Instantiate(pickupEffect, transform.position, Quaternion.identity);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Destroy(gameObject);
    }
}
