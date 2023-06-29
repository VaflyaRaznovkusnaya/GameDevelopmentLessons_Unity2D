using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TablePuzzle : MonoBehaviour
{
    private bool TableSolved = false;
    private int cur_pos = 0;
    public GameObject panelDialog;
    public Text dialog;
    public string[] message = new string[6];
    // Update is called once per frame
    private void Start()
    {
        message[0] = "После расстортировки банок, с потолка упала бумажка";
        message[1] = "'Прочти внимательно и будет тебе отгадка'";
        message[2] = "'Первый малый тебе знаком, в нём бодрости избыток'";
        message[3] = "'Второй фрукт не простой. Он как огурец, но сладкий'";
        message[4] = "'Превого раз и второго два. Вот и все дела!'";
        message[5] = "Это всё, что было на ней написано";
    }
    void Update()
    {
        if (GameManager.CheckTables)
        {
            if (gameObject.transform.GetChild(0).GetChild(0).gameObject.activeInHierarchy &&
                gameObject.transform.GetChild(1).GetChild(1).gameObject.activeInHierarchy &&
                gameObject.transform.GetChild(2).GetChild(2).gameObject.activeInHierarchy)
            {
                TableSolved = true;
                GameManager.CanPlayerMove = false;
                panelDialog.SetActive(true);
                cur_pos = 0;
                dialog.text = message[cur_pos];
                GameManager.CheckTables = false;
                //open dialog
            }
            else
            {
                GameManager.CheckTables = false;
            }
        }
        if (TableSolved)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                //panelDialog.SetActive(true);
                if (cur_pos < 5)
                {
                    //panelDialog.SetActive(true);
                    cur_pos += 1;
                    dialog.text = message[cur_pos];
                    //Debug.Log("PERFORMED");
                }
                else
                {
                    TableSolved = false;
                    GameManager.CanPlayerMove = true;
                    panelDialog.SetActive(false);
                    //Debug.Log("END_PERFORMED");
                }
            }
        }
    }
}
