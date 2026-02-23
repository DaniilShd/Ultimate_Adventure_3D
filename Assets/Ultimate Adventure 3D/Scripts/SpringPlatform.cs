using SimpleFPS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SpringPlatform : MonoBehaviour
{
    [SerializeField] private int jumpForce;
    private new AudioSource audio;

    private float previusJumpForce;

    private void Start()
    {
        audio = GetComponent<AudioSource>();    
    }

    private void OnTriggerEnter(Collider other)
    {
        FirstPersonController fps = other.GetComponent<FirstPersonController>();

        if (fps != null)
        {
            previusJumpForce = fps.m_JumpSpeed;

            fps.m_JumpSpeed += jumpForce;
            fps.m_Jump = true;

            audio.Play();   
        }
    } 

    private void OnTriggerExit(Collider other)
    {
        FirstPersonController fps = other.GetComponent<FirstPersonController>();

        if (fps != null)
        {
            fps.m_JumpSpeed = previusJumpForce;
        }
    }
}
