using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip playerHurtSound;
    [SerializeField] private AudioClip penaltySound;
    
    private void OnEnable()
    {
        GameEvents.TakeDamage += PlayHurtSound;
        GameEvents.RacePenalty += PlayPenaltySound;
    }
    
    private void OnDisable()
    {
        GameEvents.TakeDamage -= PlayHurtSound;
        GameEvents.RacePenalty -= PlayPenaltySound;
    }

    private void PlayHurtSound()
    {
        source.PlayOneShot(playerHurtSound);
    }
    
    private void PlayPenaltySound()
    {
        source.PlayOneShot(penaltySound);
    }
}
