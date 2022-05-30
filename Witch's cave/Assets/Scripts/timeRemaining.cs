using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class timeRemaining : MonoBehaviour
{
    [SerializeField] GameObject line;
    [SerializeField] TextMeshProUGUI timeRemainigTxt;
    int timeCounter = 0;
    int maxTime = 0;
    int timeToDisplay = 0;
    public int unlockNextLevel;
    public int minScoreToWin = 0;
    [SerializeField] GameObject score;

    [SerializeField] GameObject FinishedCanvas;
    [SerializeField] GameObject CongratsUI;
    [SerializeField] GameObject GameOverUI;
    [SerializeField] string levelNamePref;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        unlockNextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        timeCounter = 0;
        maxTime = 0;
        timeToDisplay = 0;
        maxTime = ((int)line.GetComponent<ReceipeLine>().MaxTimeOfLevel());
    }

    // Update is called once per frame
    void Update()
    {
        timeRemainigTxt.text = timeToDisplay.ToString();
        timeCounter = Mathf.RoundToInt(Time.timeSinceLevelLoad);
        timeToDisplay = maxTime - timeCounter;
        if(timeToDisplay < 0)
        {
            endLevel();
        }
    }

    void endLevel()
    {
        FinishedCanvas.SetActive(true);
        Time.timeScale = 0f;
        if (score.GetComponent<Score>().scoreNum >= minScoreToWin)
        {
            finished();
            var stars = (score.GetComponent<Score>().scoreNum*100)/ score.GetComponent<Score>().maxScore;
            if (stars >= 50 && stars < 69)
            {
                if (PlayerPrefs.GetInt(levelNamePref, 0) < 1)
                {
                    PlayerPrefs.SetInt(levelNamePref, 1);
                }
            }
            if (stars >= 70 && stars < 89)
            {
                if (PlayerPrefs.GetInt(levelNamePref, 0) < 2)
                {
                    PlayerPrefs.SetInt(levelNamePref, 2);
                }
            }
            if (stars >= 90)
            {
                PlayerPrefs.SetInt(levelNamePref, 3); 
            }
            PlayerPrefs.SetInt("levelAt", unlockNextLevel);
        }
        else
        {
            gameover();
        }
    }

    void finished()
    {
        CongratsUI.SetActive(true);
    }

    void gameover()
    {
        GameOverUI.SetActive(true);
    }

    public void BackToMainScreen()
    {
        SceneManager.LoadScene("WorldMap");
    }

    public void ReplayScreen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
