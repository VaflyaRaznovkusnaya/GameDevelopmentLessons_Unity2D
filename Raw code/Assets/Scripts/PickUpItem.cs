using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PickUpItem : MonoBehaviour
{
    public GameObject panelDialog;
    public Text dialog;
    public string pickUpline = "Я подобрал ";
    public int myIDinInventory = 0;
    private bool waspicked = false;

    private void Start()
    {
        panelDialog.SetActive(false);
    }
    public void InputE(Inventory playerInventory)
    {
        bool so = playerInventory.SetThisItem(myIDinInventory, true);

        if (so)
        {
            panelDialog.SetActive(true);
            dialog.text = pickUpline;
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            waspicked = true;
        }
    }
    public void BecomeInv()
    {
        GameManager.isInvisn = true;
        panelDialog.SetActive(true);
        dialog.text = pickUpline;
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        waspicked = true;
    }

    private void FixedUpdate()
    {
        if (waspicked && Input.GetKey(KeyCode.R))
        {
            waspicked = false;
            panelDialog.SetActive(false);
            Destroy(this.gameObject);
        }

    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (waspicked)
        {
            panelDialog.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
