using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject objectToSpawn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CreateItem()
    {
        var obj = GameObject.Instantiate(objectToSpawn);
        obj.transform.position = transform.position + new Vector3(0,0,0);
        return true;
    }


}
