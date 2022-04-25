using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class Receipes : MonoBehaviour
{
    [SerializeField] public float timeUntilCancel;
    [SerializeField] int pointsWhenComplete;
    [SerializeField] string nameOfReceipe;
    [SerializeField] Slider timeSlider;
    [SerializeField] Animation animationFinished;
    GameObject receipeLineObject;
    ReceipeLine receipeLine;
    Score score;
    // Start is called before the first frame update
    void Start()
    {
        receipeLineObject = GameObject.FindGameObjectWithTag("ReceipeLine");
        receipeLine = receipeLineObject.GetComponent<ReceipeLine>();
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        timeSlider.maxValue = timeUntilCancel;
    }

    // Update is called once per frame
    void Update()
    {
        CountTime();
        UpdateTimeSlider();
    }

    public void FinishOrder()
    {
        score.UpdateScore(pointsWhenComplete);
        Destroy(this.gameObject);
    }

    public void CancelOrder()
    {
        receipeLine.RemoveToControlLine(this.gameObject);     
        Destroy(this.gameObject);
    }

    public void CountTime()
    {
        timeUntilCancel -= Time.deltaTime;
        if (timeUntilCancel <= 0.3)
        {
            gameObject.GetComponent<Animation>().Play("SlideOut");
        }
        if (timeUntilCancel <= 0)
        {
            CancelOrder();
        }
    }

    public string GetNameOfReceipe()
    {
        return nameOfReceipe;
    }

    public float GetMaxTime()
    {
        return timeUntilCancel;
    }

    public void UpdateTimeSlider()
    {
        timeSlider.value += Time.deltaTime;
    }
}
