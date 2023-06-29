using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PutOnItem : MonoBehaviour
{
    public GameObject panelDialog;
    public bool[] myinventory = new bool[3];
    public Text dialog;
    public string pickUpline = "";
    private bool wasput = false;
    private bool Isempt = true;

    // transform.GetChild(0).gameObject.SetActive(false);

    private void Start()
    {
        panelDialog.SetActive(false);
        myinventory[0] = false; // Ƹ���� �������
        myinventory[1] = false; // ����� �������
        myinventory[2] = false; // ��������� �������
    }
    public void InputE(Inventory playerInventory)
    {
        // �������
        if (!Isempt)
        {
        // ��������
        int inventory_bag = playerInventory.WhatIsCurInventory();

            if (inventory_bag == 0)
            {
                if (myinventory[0])
                {
                    Debug.Log("����� ����� �������");
                    pickUpline = "� �������� ����� ��� ������ �������";
                    transform.GetChild(0).gameObject.SetActive(false);
                    Debug.Log("����� ����� �������");
                    myinventory[0] = false;
                    playerInventory.SetThisItem(0, true);
                }
                else if (myinventory[1])
                {
                    pickUpline = "� �������� ������� ��� ���� �������";
                    transform.GetChild(1).gameObject.SetActive(false);
                    myinventory[1] = false;
                    playerInventory.SetThisItem(1, true);
                }
                else if (myinventory[2])
                {
                    pickUpline = "� �������� ��������� ��� ����� �������";
                    transform.GetChild(2).gameObject.SetActive(false);
                    myinventory[2] = false;
                    playerInventory.SetThisItem(2, true);
                }
                else
                {
                    pickUpline = "�� �� �������, ������!";
                }
                // �������� ��� �����
                panelDialog.SetActive(true);
                dialog.text = pickUpline;
                wasput = true;
                Isempt = true;

            }
            else
            {
                pickUpline = "� �� ����� ������ ����� ���� �� ���!";
                panelDialog.SetActive(true);
                dialog.text = pickUpline;
                wasput = true;
            }
        }
        else
        {
            pickUpline = "��� ������ ���������!";
            panelDialog.SetActive(true);
            dialog.text = pickUpline;
            wasput = true;
        }
    }
    public void InputQ(Inventory playerInventory)
    {
        if (Isempt)
        {
            // ��������
            int inventory_bag = playerInventory.WhatIsCurInventory();

            if (inventory_bag == 0)
            {
                pickUpline = "��� ������ ���� ������";
                panelDialog.SetActive(true);
                dialog.text = pickUpline;
                wasput = true;

            }
            else if (inventory_bag == 1)// �����
            {
                pickUpline = "� ������� ����� � ����� ��� ������ ��������";
                panelDialog.SetActive(true);
                dialog.text = pickUpline;
                wasput = true;
                transform.GetChild(0).gameObject.SetActive(true);
                Isempt = false;
                playerInventory.SetThisItem(0, false);
                myinventory[0] = true;
                //GameManager.CheckTables = true;

            }
            else if (inventory_bag == 2) //�������
            {
                pickUpline = "� ������� ����� � ������� ��� ���� ��������";
                panelDialog.SetActive(true);
                dialog.text = pickUpline;
                wasput = true;
                transform.GetChild(1).gameObject.SetActive(true);
                Isempt = false;
                myinventory[1] = true;
                playerInventory.SetThisItem(1, false);
                //GameManager.CheckTables = true;
            }
            else if (inventory_bag == 3) //���������
            {
                pickUpline = "� ������� ����� � ��������� ��� ����� ��������";
                panelDialog.SetActive(true);
                dialog.text = pickUpline;
                wasput = true;
                transform.GetChild(2).gameObject.SetActive(true);
                Isempt = false;
                myinventory[2] = true;
                playerInventory.SetThisItem(2, false);
                //GameManager.CheckTables = true;
            }
            else
            {
                pickUpline = "�� �� �������, ������";
                panelDialog.SetActive(true);
                dialog.text = pickUpline;
                wasput = true;
            }
        }
        else
        {
            pickUpline = "� �� ���� ������ �������� �� ������, ��� ��� ���-�� �����!";
            panelDialog.SetActive(true);
            dialog.text = pickUpline;
            wasput = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (wasput)
        {
            panelDialog.SetActive(false);
            GameManager.CheckTables = true;
        }

    }
    private void FixedUpdate()
    {
        if (wasput && Input.GetKey(KeyCode.R))
        {
            wasput = false;
            panelDialog.SetActive(false);
            GameManager.CheckTables = true;
        }
    }
}
