using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receipes : MonoBehaviour
{
    [SerializeField] float timeUntilCancel;
    [SerializeField] float pointsWhenComplete;
    [SerializeField] string nameOfReceipe;
    GameObject receipeLineObject;
    ReceipeLine receipeLine;
    // Start is called before the first frame update
    void Start()
    {
        receipeLineObject = GameObject.FindGameObjectWithTag("ReceipeLine");
        receipeLine = receipeLineObject.GetComponent<ReceipeLine>();
    }

    // Update is called once per frame
    void Update()
    {
        CountTime();
    }

    public void FinishOrder()
    {
        //UpdateScore(pointsWhenComplete);
        Debug.Log("Destroyed");
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
