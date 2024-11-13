using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioEffect", menuName = "Effects/AudioEffect")]
public class AudioEffect : Effect
{
    [SerializeField] private AudioClip audioClip;

    public override void ApplyEffect()
    {
        GameObject audioEffectGameObject = new GameObject(audioClip.name + " Audio Clip");
        audioEffectGameObject.AddComponent<AudioSource>();
        AudioSource audioSource = audioEffectGameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.PlayOneShot(audioClip);
    }
}
