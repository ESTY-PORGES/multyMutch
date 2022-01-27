using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] sounds;

    [SerializeField] private GameManager gameManager;
    private void Start()
    {
        audioSource.clip = sounds[2];
        audioSource.Play();
    }

    private void Correct()
    {
        audioSource.clip = sounds[0];
        audioSource.Play();
    }
}
