using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public delegate void GameEvent();
    public static event GameEvent TakeDamage;
    public static event GameEvent RaceStart;
    public static event GameEvent RaceFinish;
    public static event GameEvent RacePenalty;
    
    
    public static void CallTakeDamage()
    {
        if(TakeDamage != null)
            TakeDamage();
    }
    
    public static void CallRaceStart()
    {
        if(RaceStart != null)
            RaceStart();
    }
    public static void CallRaceFinish()
    {
        if(RaceFinish != null)
            RaceFinish();
    }
    public static void CallRacePenalty()
    {
        if(RacePenalty != null)
            RacePenalty();
    }
    

}
