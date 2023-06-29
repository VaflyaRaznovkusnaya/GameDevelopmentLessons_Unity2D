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
    private string pickUpline = "� �� ����� ������ ������ 1 ��������!";

    //
    void Start()
    {
        myinventory[0] = false; // Ƹ���� �������
        myinventory[1] = false; // ����� �������
        myinventory[2] = false; // ��������� �������
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
            dialog.text = "�� ���������� ���������, �������, ��� ��� � �������";
            waspicked = true;
        }
        else
        {
            panelDialog.SetActive(true);
            dialog.text = "����� ������� �� ������ �� �����, ���-�� ������ ��������� ����� �������� �����";
            waspicked = true;
            GameManager.IsCrawlDoorOpen = true;
        }
    }
    public void MakeSandwich()
    {
        if (GameManager.HaveSandwich)
        {
            panelDialog.SetActive(true);
            dialog.text = "� ���� ��� ���� �������, �� ����� ������ ����� ���";
            waspicked = true;
        }
        else
        {
            gameObject.GetComponent<Player>().panelHealthAndItems.transform.GetChild(6).gameObject.SetActive(true);
            panelDialog.SetActive(true);
            dialog.text = "� ������ �������! �����, ��������� ������ ������ 4 ���� ��� ������.";
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
