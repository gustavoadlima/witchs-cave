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
    // Start is called before the first frame update
    void Start()
    {
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
        Debug.Log(unlockNextLevel);
        PlayerPrefs.SetInt("levelAt", unlockNextLevel);
        SceneManager.LoadScene("WorldMap");
    }

}
