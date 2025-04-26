using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoards : MonoBehaviour
{
    [SerializeField] private List<float> results = new List<float>();

    void Start()
    {
        results.Clear();
        for (int i = 0; i < 5; i++)
        {
            float toAdd = PlayerPrefs.GetFloat("time" + i, 999999);
            results.Add(999999);
        }
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


    }
}
