using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;

public class LeaderBoards : MonoBehaviour
{
    [SerializeField] private List<float> results = new List<float>();
    [SerializeField] private List<TMP_Text> leaderboardTexts;

    void Start()
    {
        results.Clear();
        for (int i = 0; i < 5; i++)
        {
            float toAdd = PlayerPrefs.GetFloat("time" + i, 999999);
            results.Add(toAdd);
        }

        UpdateLeaderboardUI();
    }

    public void AddResult(float time)
    {
        results.Add(time);
        results.Sort();
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetFloat("time" + i, results[i]);
        }
        PlayerPrefs.Save();
        UpdateLeaderboardUI();
    }

    private void UpdateLeaderboardUI()
    {
        for (int i = 0; i < leaderboardTexts.Count && i < results.Count; i++)
        {
            leaderboardTexts[i].text = (i + 1) + ". " + results[i].ToString("F2") + "s";
        }
    }
}