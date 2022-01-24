using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextKill : MonoBehaviour
{
    public AudioClip starterSound;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = starterSound;
        audioSource.Play();
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
