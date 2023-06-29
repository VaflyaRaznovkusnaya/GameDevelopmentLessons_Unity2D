using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDamage : MonoBehaviour
{
    public sbyte damage = 1;
    public Camera myCamera;
    public GameObject nearTo = null;

    private void Update()
    {
        if (nearTo != null)
        {
            if (!nearTo.CompareTag("Enemy")) gameObject.transform.GetChild(2).gameObject.SetActive(true);
            if (nearTo.CompareTag("Door")){
                //ChangeLevel responseDoor = nearTo.GetComponent<ChangeLevel>();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    nearTo.transform.GetComponent<ChangeLevel>().InputE(gameObject);
                }
                else if (Input.GetKeyDown(KeyCode.Q))
                {
                    nearTo.transform.GetComponent<ChangeLevel>().InputQ(gameObject);
                }
            }
            else if (nearTo.CompareTag("Table"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    nearTo.transform.GetComponent<PutOnItem>().InputE(gameObject.transform.GetComponent<Inventory>());
                }
                else if (Input.GetKeyDown(KeyCode.Q))
                {
                    nearTo.transform.GetComponent<PutOnItem>().InputQ(gameObject.transform.GetComponent<Inventory>());
                }
            }
            else if (nearTo.CompareTag("PickUpItem"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    nearTo.transform.GetComponent<PickUpItem>().InputE(gameObject.transform.GetComponent<Inventory>());
                }
            }
            else if (nearTo.CompareTag("Invins"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    nearTo.transform.GetComponent<PickUpItem>().BecomeInv();
                }
                    
            }
            else if (nearTo.CompareTag("KitchenSup"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    gameObject.transform.GetComponent<Inventory>().MakeSandwich();
                }
            }
            else if (nearTo.CompareTag("ButtonForCrawl"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    gameObject.transform.GetComponent<Inventory>().PushButton();
                }
            }
        }
    }
    
    private void Start()
    {
        myCamera = Camera.main;
        myCamera.enabled = true;
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //health responsehealth = gameObject.GetComponent<health>();
            //responsehealth.TakeDamage(damage);
            gameObject.GetComponent<health>().TakeDamage(damage);
        }
        gameObject.GetComponent<Player>().Collisionfloor();
        //Player boink = gameObject.GetComponent<Player>();
        //boink.Collisionfloor();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        nearTo = collision.gameObject;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (nearTo == null)
        {
            nearTo = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (nearTo != null)
        {
            if (nearTo.CompareTag("KitchenSup") || nearTo.CompareTag("ButtonForCrawl"))
            {
                gameObject.GetComponent<Player>().panelDialog.SetActive(false);
            }
            if (nearTo.CompareTag("Door"))
            {
                if (!myCamera.enabled)
                {
                    nearTo.transform.GetComponent<ChangeLevel>().InputQ(gameObject);
                }
            }
            nearTo = null;
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
        }
        //gameObject.GetComponent<Player>().panelDialog.SetActive(false);
    }

    public void offCamera()
    {
        myCamera.enabled = false;
    }
    public void onCamera()
    {
        myCamera.enabled = true;
    }

   
}
