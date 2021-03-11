using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ScreamingJamesBehaviour : MonoBehaviour
{
    [SerializeField] private SoundEffect screamEffect;
    private AudioSource myAudioSource;

    private void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        InvokeRepeating("PlayEffect", 0f, 1f);
    }


    private void PlayEffect()
    {
        Debug.Log("Playing sound");
        screamEffect.PlayEffect(myAudioSource);
    }

}
