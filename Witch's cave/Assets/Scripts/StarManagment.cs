using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManagment : MonoBehaviour
{
    [SerializeField] GameObject StarsLine;
    [SerializeField] GameObject StarIcon;
    [SerializeField] string NameOfPref;
    // Start is called before the first frame update
    void Start()
    {
        int howManyStars = PlayerPrefs.GetInt(NameOfPref,0);
        for (int i = 0; i < howManyStars; i++)
        {
            var stars = GameObject.Instantiate(StarIcon);
            stars.transform.SetParent(StarsLine.transform);
            stars.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
