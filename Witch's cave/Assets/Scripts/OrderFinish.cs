using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OrderFinish : MonoBehaviour
{
    [SerializeField] LayerMask itemsLayer;
    GameObject receipeLineObject;
    ReceipeLine receipeLine;
    [SerializeField] GameObject winnigSound;
    [SerializeField] AudioClip cashSound;
    [SerializeField] AudioClip cancelSound;
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

    public void PlayCashSound()
    {
            winnigSound.GetComponent<AudioSource>().PlayOneShot(cashSound);
    }
    public void PlayCancelSound()
    {
        winnigSound.GetComponent<AudioSource>().PlayOneShot(cancelSound);
    }

}
