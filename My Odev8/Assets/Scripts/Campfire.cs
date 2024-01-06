using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : MonoBehaviour
{
    public AudioSource _audioSource;
    public float stopDistance;

    private Transform player;
    private float defaultVolume;

    private void Start()
    {
        defaultVolume = _audioSource.volume;
        player = FindAnyObjectByType<PlayerController>().transform;

    }

    private void Update()
    {
        if (player == null)
            return;


        float _dist = Vector3.Distance(transform.position, player.position);


        if (_dist > stopDistance)
        {
            _audioSource.volume = defaultVolume;
        }
        else
        {
            _audioSource.volume = 0.0f;
        }
    }
}
