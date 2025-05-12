
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Commentator : MonoBehaviour
{
    [SerializeField] private TMP_Text commentText;
    [SerializeField] private float messageDuration = 2f;

    private List<string> randomComments = new List<string>()
    {
        "GO GO GO!",
        "Nice try!",
        "Amazing!",
        "Fantastic!",
        "The best!",
        "OMG!!!!!!!"
    };

    private void Start()
    {
        StartCoroutine(RandomCommentsLoop());
    }

    private IEnumerator RandomCommentsLoop()
    {
        while (true)
        {
            float delay = Random.Range(5f, 10f);
            yield return new WaitForSeconds(delay);

            string msg = randomComments[Random.Range(0, randomComments.Count)];
            StartCoroutine(ShowMessage(msg));
        }
    }

    private IEnumerator ShowMessage(string message)
    {
        commentText.text = message;
        commentText.alpha = 1;

        yield return new WaitForSeconds(messageDuration);

        commentText.alpha = 0;
    }
}
