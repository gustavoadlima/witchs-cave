using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTxt;
    [SerializeField] public int maxScore;
    [SerializeField] Slider sliderScore;
    public int scoreNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        sliderScore.maxValue = 100;
        sliderScore.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int pointsToSum)
    {
        scoreNum += pointsToSum;
        updateScoreTxt();
        sliderScore.value = (scoreNum * 100) / maxScore;
        scoreTxt.gameObject.GetComponent<Animation>().Play("ScoreTxt");
    }

    public void updateScoreTxt()
    {
        scoreTxt.text = scoreNum.ToString();
    }

}
