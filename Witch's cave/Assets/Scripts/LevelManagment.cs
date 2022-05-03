using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManagment : MonoBehaviour
{
    public Button[] lvlBtn;
    // Start is called before the first frame update
    void Start()
    {
        int levelIndex = PlayerPrefs.GetInt("levelAt", 2);
        for (int i=0; i< lvlBtn.Length; i++)
        {
            if(i+2 > levelIndex)
            {
                lvlBtn[i].interactable = false;
            }
        }
    }

}
