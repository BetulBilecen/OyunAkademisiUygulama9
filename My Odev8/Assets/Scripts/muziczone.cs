using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muziczone : MonoBehaviour
{
    public AudioSource _audioSource;
    public float fadeTime;
    private float targetVolume;
    // Start is called before the first frame update
    void Start()
    {
        targetVolume = 0.0f;
        _audioSource.volume = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, (1.0f / fadeTime) * Time.deltaTime);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetVolume = 1.0f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetVolume = 0.0f;
        }
    }
}
