using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTimer : MonoBehaviour
{
    private float raceTime = 0;
    private bool raceRunning = false;
    [SerializeField] private LeaderBoards leaderBoard;

    private void Update()
    {
        if(raceRunning)
            raceTime += Time.deltaTime;
    }
    private void OnEnable()
    {
        GameEvents.RaceStart += StartRace;
        GameEvents.RaceFinish += FinishRace;
        GameEvents.RacePenalty += PenaltyRace;
    }
    
    private void OnDisable()
    {
        GameEvents.RaceStart -= StartRace;
        GameEvents.RaceFinish -= FinishRace;
        GameEvents.RacePenalty -= PenaltyRace;
    }

    private void StartRace()
    {
        raceTime = 0;
        raceRunning = true;
        Debug.Log("Race started");
    }
    private void PenaltyRace()
    {
        raceTime += 2;
        Debug.Log("Player recieved penalty");
    }
    
    private void FinishRace()
    {
        raceRunning = false;
        GameData.Instance.racesCompleted++;
        leaderBoard.AddResult(raceTime);
        Debug.Log("Race ended" + raceTime);
        Debug.Log("Race complited" + GameData.Instance.racesCompleted);
    }

    
    


}
