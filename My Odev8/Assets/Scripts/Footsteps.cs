using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioClip[] footstepClip;
    public AudioSource _audioSource;
    public CharacterController controller;
    public float footstepTheshold;
    public float footstepRate;

    private float lastFootstepTime;

    private void FixedUpdate()
    {
        if (controller.velocity.magnitude > footstepTheshold)
        {
            if (Time.time - lastFootstepTime > footstepRate)
            {
                lastFootstepTime = Time.time;
                _audioSource.PlayOneShot(footstepClip[Random.Range(0, footstepClip.Length)]);
            }
        }
    }
}
