using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenaltyTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameEvents.CallRacePenalty();
    }
}
