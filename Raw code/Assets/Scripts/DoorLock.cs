using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorLock : MonoBehaviour
{
    private sbyte count1 = 0;
    private sbyte count2 = 0;
    private sbyte count3 = 0;
    public GameObject DoorPanel;

    void Start()
    {
        DoorPanel.SetActive(false);
        // 0 - apple, 1 - banana, 2 -chocolate, 3 - coffe, 4 - grape, 5 - milk, 6 - orange, 7 - soy, 8 - strawberry
        //DoorPanel.transform.GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false); // банан 1
        for (int j = 0; j<3; j++)
        {
            for (int i = 1; i < 9; i++)
            {
                DoorPanel.transform.GetChild(0).GetChild(j).GetChild(i).gameObject.SetActive(false); // закрыли всЄ, кроме €блок
            }
        }
    }

    public void ButtonOne()
    {
        if (count1 == 8)
        {
            DoorPanel.transform.GetChild(0).GetChild(0).GetChild(count1).gameObject.SetActive(false);
            count1 = 0;
            DoorPanel.transform.GetChild(0).GetChild(0).GetChild(count1).gameObject.SetActive(true);
        }
        else
        {
            DoorPanel.transform.GetChild(0).GetChild(0).GetChild(count1).gameObject.SetActive(false);
            DoorPanel.transform.GetChild(0).GetChild(0).GetChild(count1 + 1).gameObject.SetActive(true);
            count1++;
        }
    }
    public void ButtonTwo()
    {
        if (count2 == 8)
        {
            DoorPanel.transform.GetChild(0).GetChild(1).GetChild(count2).gameObject.SetActive(false);
            count2 = 0;
            DoorPanel.transform.GetChild(0).GetChild(1).GetChild(count2).gameObject.SetActive(true);
        }
        else
        {
            DoorPanel.transform.GetChild(0).GetChild(1).GetChild(count2).gameObject.SetActive(false);
            DoorPanel.transform.GetChild(0).GetChild(1).GetChild(count2 + 1).gameObject.SetActive(true);
            count2++;
        }
    }
    public void ButtonThree()
    {
        if (count3 == 8)
        {
            DoorPanel.transform.GetChild(0).GetChild(2).GetChild(count3).gameObject.SetActive(false);
            count3 = 0;
            DoorPanel.transform.GetChild(0).GetChild(2).GetChild(count3).gameObject.SetActive(true);
        }
        else
        {
            DoorPanel.transform.GetChild(0).GetChild(2).GetChild(count3).gameObject.SetActive(false);
            DoorPanel.transform.GetChild(0).GetChild(2).GetChild(count3 + 1).gameObject.SetActive(true);
            count3++;
        }
    }

    public void Exit()
    {
        GameManager.CanPlayerMove = true;
        DoorPanel.SetActive(false);
    }

    public void Confirm()
    {
        // coffee banana banana
        if (DoorPanel.transform.GetChild(0).GetChild(0).GetChild(3).gameObject.activeInHierarchy &&
            DoorPanel.transform.GetChild(0).GetChild(1).GetChild(1).gameObject.activeInHierarchy  &&
            DoorPanel.transform.GetChild(0).GetChild(2).GetChild(1).gameObject.activeInHierarchy)
        {
            SceneManager.LoadScene("Final");
        }
        else
        {
            DoorPanel.transform.GetChild(0).GetChild(8).gameObject.SetActive(true);
        }
    }
}
