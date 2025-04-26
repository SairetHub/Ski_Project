using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private Image overlay;
    [SerializeField] private int nextLevelID;
    // Start is called before the first frame update
    void Start()
    {
        gameOverMenu.SetActive(false);
        overlay.CrossFadeAlpha(0, 1f,true);
    }
    private void OnEnable()
    {
        GameEvents.RaceFinish += ShowGameOverMenu;
    }
    private void OnDisable()
    {
        GameEvents.RaceFinish -= ShowGameOverMenu;
    }

    private void ShowGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }
    public void NextRace()
    {
        StartCoroutine(LoadLevelCoroutine(nextLevelID));
    }
    public void Retry()
    {
        StartCoroutine(LoadLevelCoroutine(
            SceneManager.GetActiveScene().buildIndex));   
    }
    private IEnumerator LoadLevelCoroutine(int levelID)
    {
        overlay.CrossFadeAlpha(1, 1f, true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelID);
    }
    
    public void Quit()
    {
        StartCoroutine(QuitCoroutine());
    }
    private IEnumerator QuitCoroutine()
    {
        overlay.CrossFadeAlpha(1, 1f, true);
        yield return new WaitForSeconds(1);
        Application.Quit();
    }
    
}