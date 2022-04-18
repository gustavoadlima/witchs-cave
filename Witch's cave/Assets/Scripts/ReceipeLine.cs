using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ReceipeLine : MonoBehaviour
{
    [SerializeField] List<GameObject> receipes;
    [SerializeField] List<int> timeToSpawn;
    [SerializeField] GameObject receipesLine;
    int timeCounter = 0;
    int index;

    List<GameObject> activeLine = new List<GameObject>();

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter = Mathf.RoundToInt(Time.time);
        if (index < receipes.Count)
        {
            if (timeCounter == timeToSpawn[index])
            {
                var newReceipe = GameObject.Instantiate(receipes[index]);
                newReceipe.transform.SetParent(receipesLine.transform);
                newReceipe.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                AddToControlLine(newReceipe);
                index++;
            }
        }
    }

    public void CheckIfItIsOnActiveLine(GameObject objectToCheck)
    {
        foreach (var name in activeLine) {
            if (name.GetComponent<Receipes>().GetNameOfReceipe().Equals(objectToCheck.GetComponent<Item>().itemName))
            {
                RemoveToControlLine(name);
                name.GetComponent<Receipes>().FinishOrder();
                return;
            }
        }
    }

    public void AddToControlLine(GameObject activeReceipe)
    {
        activeLine.Add(activeReceipe);
    }

    public void RemoveToControlLine(GameObject nonActiveReceipe)
    {
        activeLine.Remove(nonActiveReceipe);
    }

    public float MaxTimeOfLevel()
    {
        float lastItem = timeToSpawn.Last();
        float maxTimeLastItem = receipes.Last().gameObject.GetComponent<Receipes>().timeUntilCancel;
        return lastItem + maxTimeLastItem + 2;
    }

    
}
