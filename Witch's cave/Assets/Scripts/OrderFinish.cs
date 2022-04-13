using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderFinish : MonoBehaviour
{
    [SerializeField] LayerMask itemsLayer;
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
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer.Equals(6))
        {
            receipeLine.CheckIfItIsOnActiveLine(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }

}
