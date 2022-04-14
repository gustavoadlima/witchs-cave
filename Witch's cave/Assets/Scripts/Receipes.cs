using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receipes : MonoBehaviour
{
    [SerializeField] float timeUntilCancel;
    [SerializeField] int pointsWhenComplete;
    [SerializeField] string nameOfReceipe;
    GameObject receipeLineObject;
    ReceipeLine receipeLine;
    Score score;
    // Start is called before the first frame update
    void Start()
    {
        receipeLineObject = GameObject.FindGameObjectWithTag("ReceipeLine");
        receipeLine = receipeLineObject.GetComponent<ReceipeLine>();
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        CountTime();
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
        if(timeUntilCancel <= 0)
        {
            Debug.Log(GetNameOfReceipe());
            CancelOrder();
        }
    }

    public string GetNameOfReceipe()
    {
        return nameOfReceipe;
    }
}
