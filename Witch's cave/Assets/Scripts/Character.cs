using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    public bool isHoldingSomething = false;
    public GameObject objectThatIsHolding;

    Vector2 movement;


    [SerializeField] Transform holdSpot;
    [SerializeField] LayerMask pickUpLayer;
    [SerializeField] LayerMask createLayer;
    public Vector3 Direction { get; set; }
    private GameObject itemHolding;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        if(movement.sqrMagnitude > .1f)
        {
            Direction = movement.normalized;
        }

        //aqui come�a o script de pegar objeto
        if (Input.GetKeyDown(KeyCode.E))
        {
            CreateItem();

        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            AttachItem();

        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement *moveSpeed * Time.fixedDeltaTime); 
    }

    private void AttachItem()
    {
        if (itemHolding)
        {
            itemHolding.transform.position = transform.position + Direction;
            itemHolding.transform.parent = null;
            if (itemHolding.GetComponent<Rigidbody2D>())
            {
                itemHolding.GetComponent<Rigidbody2D>().simulated = true;
                itemHolding = null;
                SetIsHoldingSomething(false);
                SetObjectThatIsHolding(null);
            }
        }
        else
        {
            Collider2D pickUpItem = Physics2D.OverlapCircle(transform.position + Direction, 1f, pickUpLayer);
            if (pickUpItem)
            {

                itemHolding = pickUpItem.gameObject;
                itemHolding.transform.position = holdSpot.position;
                itemHolding.transform.parent = transform;
                if (itemHolding.GetComponent<Rigidbody2D>())
                {
                    itemHolding.GetComponent<Rigidbody2D>().simulated = false;
                    SetIsHoldingSomething(true);
                    SetObjectThatIsHolding(itemHolding);
                }
            }
        }
    }

    private void CreateItem()
    {
        Collider2D createItem = Physics2D.OverlapCircle(transform.position + Direction, 1f, createLayer);
        if (createItem)
        {
            createItem.GetComponent<SpawnItem>().createItem();
        }
        
    }

    public void SetIsHoldingSomething(bool value)
    {
        isHoldingSomething = value;
    }

    public bool GetIsHoldingSomething()
    {
        return isHoldingSomething;
    }

    public void SetObjectThatIsHolding(GameObject objectHolding)
    {
        objectThatIsHolding = objectHolding;
    }

    public GameObject GetObjectThatIsHolding()
    {
        return objectThatIsHolding;
    }

  

}
