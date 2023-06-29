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
        myinventory[0] = false; // Жёлтая бабочка
        myinventory[1] = false; // Синяя бабочка
        myinventory[2] = false; // Оранжевая бабочка
    }
    public void InputE(Inventory playerInventory)
    {
        // поднять
        if (!Isempt)
        {
        // Положить
        int inventory_bag = playerInventory.WhatIsCurInventory();

            if (inventory_bag == 0)
            {
                if (myinventory[0])
                {
                    Debug.Log("Нашли жёлтую бабочку");
                    pickUpline = "Я подобрал жёлтую как солнце бабочку";
                    transform.GetChild(0).gameObject.SetActive(false);
                    Debug.Log("Нашли жёлтую бабочку");
                    myinventory[0] = false;
                    playerInventory.SetThisItem(0, true);
                }
                else if (myinventory[1])
                {
                    pickUpline = "Я подобрал голубую как небо бабочку";
                    transform.GetChild(1).gameObject.SetActive(false);
                    myinventory[1] = false;
                    playerInventory.SetThisItem(1, true);
                }
                else if (myinventory[2])
                {
                    pickUpline = "Я подобрал оранжевую как закат бабочку";
                    transform.GetChild(2).gameObject.SetActive(false);
                    myinventory[2] = false;
                    playerInventory.SetThisItem(2, true);
                }
                else
                {
                    pickUpline = "ты чо наделал, хаккер!";
                }
                // проверка что лежит
                panelDialog.SetActive(true);
                dialog.text = pickUpline;
                wasput = true;
                Isempt = true;

            }
            else
            {
                pickUpline = "Я не унесу больше одной вещи за раз!";
                panelDialog.SetActive(true);
                dialog.text = pickUpline;
                wasput = true;
            }
        }
        else
        {
            pickUpline = "Тут нечего подбирать!";
            panelDialog.SetActive(true);
            dialog.text = pickUpline;
            wasput = true;
        }
    }
    public void InputQ(Inventory playerInventory)
    {
        if (Isempt)
        {
            // Положить
            int inventory_bag = playerInventory.WhatIsCurInventory();

            if (inventory_bag == 0)
            {
                pickUpline = "Мне нечего сюда класть";
                panelDialog.SetActive(true);
                dialog.text = pickUpline;
                wasput = true;

            }
            else if (inventory_bag == 1)// жёлтый
            {
                pickUpline = "Я положил банку с жёлтой как солнце бабочкой";
                panelDialog.SetActive(true);
                dialog.text = pickUpline;
                wasput = true;
                transform.GetChild(0).gameObject.SetActive(true);
                Isempt = false;
                playerInventory.SetThisItem(0, false);
                myinventory[0] = true;
                //GameManager.CheckTables = true;

            }
            else if (inventory_bag == 2) //голубой
            {
                pickUpline = "Я положил банку с голубой как небо бабочкой";
                panelDialog.SetActive(true);
                dialog.text = pickUpline;
                wasput = true;
                transform.GetChild(1).gameObject.SetActive(true);
                Isempt = false;
                myinventory[1] = true;
                playerInventory.SetThisItem(1, false);
                //GameManager.CheckTables = true;
            }
            else if (inventory_bag == 3) //оранжевый
            {
                pickUpline = "Я положил банку с оранжевой как закат бабочкой";
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
                pickUpline = "ТЫ ЧО НАДЕЛАЛ, ХАККЕР";
                panelDialog.SetActive(true);
                dialog.text = pickUpline;
                wasput = true;
            }
        }
        else
        {
            pickUpline = "Я не могу ничего положить на столик, где уже что-то лежит!";
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
