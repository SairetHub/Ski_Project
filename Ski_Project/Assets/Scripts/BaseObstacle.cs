using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObstacle : MonoBehaviour
{
    public string obstacleName;
    void OnCollisionEnter()
    {
        OnHit();
    }
    
    internal virtual void OnHit()
    {
        GameEvents.CallTakeDamage();
        Debug.Log("Obstacle was hit");
    }
}
