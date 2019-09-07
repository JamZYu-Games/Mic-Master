using UnityEngine;
using System.Collections;

public class Carsound : MonoBehaviour
{

    public AudioClip me;
    public int carwait = 10;
    bool keepPlaying = true;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play(0);
    }
}