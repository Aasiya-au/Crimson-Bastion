using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public AudioClip collectSound;
    public AudioSource audioSource;
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player")) {
            audioSource.PlayOneShot(collectSound);
            Destroy(gameObject);
        }
    }
}