using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour
{
    public List<Transform> players;
    private int currentScore;
    public Text scoreHolder;
    public GameObject uiDestroy;
    private bool waitFinished = false;
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (players[0].position.x < 20.5f)
        {
            for (int i = 1; i < players.Count; i++)
            {
                if (players[0].position.x < players[i].position.x)
                    currentScore += 1;
            }
            scoreHolder.text = currentScore.ToString();
            currentScore = 1;
        }
        else if (!waitFinished)
            StartCoroutine(WaitFor(3f));

    }

    IEnumerator WaitFor(float seconds) //Oyun içi sayaç coroutine ile sayaç başlattım
    {
        float elapsedTime = 0;
        waitFinished = true;
        while (elapsedTime < seconds)
        {
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();

        }
        Destroy(uiDestroy.gameObject);
    }
}
