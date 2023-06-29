using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool[] myinventory = new bool[3];
    public int howmushItook = 0;
    public GameObject panelDialog;
    private bool waspicked = false;
    public Text dialog;
    private string pickUpline = "Я не смогу унести больше 1 предмета!";

    //
    void Start()
    {
        myinventory[0] = false; // Жёлтая бабочка
        myinventory[1] = false; // Синяя бабочка
        myinventory[2] = false; // Оранжевая бабочка
    }
    private void Update()
    {
        if (waspicked && Input.GetKey(KeyCode.R))
        {
            waspicked = false;
            panelDialog.SetActive(false);
        }
    }
    public void PushButton()
    {
        if (GameManager.IsCrawlDoorOpen)
        {
            panelDialog.SetActive(true);
            dialog.text = "Не получается выключить, надеюсь, что это к лучшему";
            waspicked = true;
        }
        else
        {
            panelDialog.SetActive(true);
            dialog.text = "После нажатия на кнопку на лампе, где-то далеко раздались звуки падающих вещей";
            waspicked = true;
            GameManager.IsCrawlDoorOpen = true;
        }
    }
    public void MakeSandwich()
    {
        if (GameManager.HaveSandwich)
        {
            panelDialog.SetActive(true);
            dialog.text = "У меня уже есть сэндвич, не стоит терять время зря";
            waspicked = true;
        }
        else
        {
            gameObject.GetComponent<Player>().panelHealthAndItems.transform.GetChild(6).gameObject.SetActive(true);
            panelDialog.SetActive(true);
            dialog.text = "Я сделал сэндвич! Думаю, взрослому хватит секунд 4 чтоб его съесть.";
            waspicked = true;
            GameManager.HaveSandwich = true;
        }
    }
    public bool SetThisItem(int i, bool doIhave)
    {
        Player invent = gameObject.GetComponent<Player>();
        if (doIhave)
        {
            if (howmushItook == 0)
            {
                myinventory[i] = doIhave;
                if (i == 0)
                {
                    invent.panelHealthAndItems.transform.GetChild(4).gameObject.SetActive(true);
                }
                else if (i == 1)
                {
                    invent.panelHealthAndItems.transform.GetChild(3).gameObject.SetActive(true);
                }
                else if (i == 2)
                {
                    invent.panelHealthAndItems.transform.GetChild(5).gameObject.SetActive(true);
                }
                howmushItook++;
                return true;
            }
            else
            {
                panelDialog.SetActive(true);
                dialog.text = pickUpline;
                waspicked = true;
                return false;
            }
        }
        else
        {
            myinventory[i] = doIhave;
            if (i == 0)
            {
                invent.panelHealthAndItems.transform.GetChild(4).gameObject.SetActive(false);
            }
            else if (i == 1)
            {
                invent.panelHealthAndItems.transform.GetChild(3).gameObject.SetActive(false);
            }
            else if (i == 2)
            {
                invent.panelHealthAndItems.transform.GetChild(5).gameObject.SetActive(false);
            }
            if (howmushItook > 0)
                howmushItook--;
            return true;
        }
        
    }
    public int WhatIsCurInventory()
    {
        if (howmushItook == 0)
        {
            return 0;
        }
        else if (myinventory[0])
        {
            return 1;
        }
        else if (myinventory[1])
        {
            return 2;
        }
        else if (myinventory[2])
        {
            return 3;
        }
        else
        {
            return 5;
        }
        
    } 
}
