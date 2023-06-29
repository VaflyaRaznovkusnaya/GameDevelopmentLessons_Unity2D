using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArea : MonoBehaviour
{
    private bool IsChase = false;
    private bool IsRunning = false;
    private bool ItoldIt = false;
    public float Chase_time = 3;
    //public Transform player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsChase = true;
            Chase_time = 3;
            IsRunning = false;
            //Debug.Log("’Œ“»“≈ œŒ—À”ÿ¿“‹ œ–Œ √≈–¡ŒÀ¿…‘!?");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (IsChase)
        {
            transform.GetComponent<Rigidbody2D>().gravityScale = 0;
            IsRunning = true;
        }
        
    }

    private void Update()
    {
        //”·ÂÊ‡l
        if (IsRunning && Chase_time > 0)
        {
            Chase_time -= Time.deltaTime;
        }
        if (Chase_time <= 0)
        {
            transform.GetComponent<Rigidbody2D>().gravityScale = 1;
            IsChase = false;
            IsRunning = false;
            ItoldIt = false;
            Chase_time = 3;
            ///Change Goback
            SpiritRotation GoHome = gameObject.GetComponent<SpiritRotation>();
            GoHome.GoBackHome();
        }
        
        if (IsChase && !ItoldIt)
        {
            transform.GetComponent<Rigidbody2D>().gravityScale = 1;
             //Change IsRunning
             ItoldIt = true;
             SpiritRotation GoKillIt = gameObject.GetComponent<SpiritRotation>();
             GoKillIt.StartChase();
            GoKillIt.StopGoingHome();

        }

    }

}
