using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class health : MonoBehaviour
{
    public sbyte Health = 3; // !!! на небольшие куски здоровья
    public Animator myAnimator;
    public void TakeDamage(sbyte damage)
    {
        if (GameManager.HaveSandwich)
        {
            GameManager.IsEnemyStunned = true;
            GameManager.isInvisn = true;
            myAnimator.SetBool("IsStunned", true);
            gameObject.GetComponent<Player>().panelHealthAndItems.transform.GetChild(6).gameObject.SetActive(false);
            GameManager.HaveSandwich = false;
        }
        else if (!GameManager.IsEnemyStunned)
        {
            GameManager.CanPlayerMove = false;
            Health -= damage;
            Player hearts = gameObject.GetComponent<Player>();

            if (Health == 2)
            {
                hearts.panelHealthAndItems.transform.GetChild(2).gameObject.SetActive(false);
            }
            else if (Health == 1)
            {
                hearts.panelHealthAndItems.transform.GetChild(1).gameObject.SetActive(false);
            }
            else if (Health <= 0)
            {
                hearts.panelHealthAndItems.transform.GetChild(0).gameObject.SetActive(false);
                SceneManager.LoadScene("GameOver");
            }

            gameObject.transform.position = new Vector3(-84.9f, -32.89f, gameObject.transform.position.z);
            GameManager.CanPlayerMove = true;
        }
    }
}
public class GameManager : MonoBehaviour
{
    public static bool CanPlayerMove = true;
    public static bool HaveSandwich = false;
    public static bool CheckTables = false;
    public static bool IsEnemyStunned = false;
    public static bool IsCrawlDoorOpen = false;
    public static bool isInvisn = false;
}
