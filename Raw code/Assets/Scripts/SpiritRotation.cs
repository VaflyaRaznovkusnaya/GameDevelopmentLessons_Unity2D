using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritRotation : MonoBehaviour
{
    public GameObject lftBord;
    public GameObject RghtBord;
    public GameObject CentrMark;
    public Rigidbody2D rgdbody;
    private bool IsRunning = false;
    private bool GoBack = false;
    public Transform player;
    public SpriteRenderer mysprite;
    public Animator myAnimator;

    bool DirectionLft; // Хотьба влево - правда, вправо - ложь
    public float spiritspeed = 3;
    public float spiritstunnedtime = 4;
    public float spiritspeedChaising =7;

    public void StartChase()
    {
        IsRunning = true;
    }
    public void StopGoingHome()
    {
        GoBack = false;
    }
    public void GoBackHome()
    {
        GoBack = true;
    }

    private void Update()
    {
        //change sprite
        if (DirectionLft)
        {
            mysprite.flipX = true;
        }
        else
        {
            mysprite.flipX = false;
        }

        if (GameManager.IsEnemyStunned)
        {
            if (spiritstunnedtime <= 0)
            {
                GameManager.IsEnemyStunned = false;
                myAnimator.SetBool("IsStunned", false);
                spiritstunnedtime = 4;
            }
            else{
                spiritstunnedtime -= Time.deltaTime;
            }
        }
        else
        {
            //OnPatrol
            if (DirectionLft && !IsRunning)
            {
                rgdbody.velocity = Vector2.left * spiritspeed;
                if (transform.position.x < lftBord.transform.position.x)
                {
                    DirectionLft = !DirectionLft;
                }
            }
            else if (!DirectionLft && !IsRunning)
            {
                rgdbody.velocity = Vector2.right * spiritspeed;
                if (transform.position.x > RghtBord.transform.position.x)
                {
                    DirectionLft = !DirectionLft;
                }
            }

            // chase or return
            if (IsRunning && !GoBack)
            {
                Vector3 direction = player.position - transform.position;
                if (direction.x < 0)
                {
                    mysprite.flipX = true;
                }
                else
                {
                    mysprite.flipX = false;
                }
                //direction = direction.normalized;
                transform.position = Vector2.MoveTowards(transform.position, player.position, spiritspeedChaising * Time.deltaTime);
                //rgdbody.MovePosition(transform.position + (direction * spiritspeedChaising * Time.deltaTime));
            }
            else if (IsRunning && GoBack)
            {
                Vector3 direction = CentrMark.transform.position - transform.position;
                if (direction.x < 0)
                {
                    mysprite.flipX = true;
                }
                else
                {
                    mysprite.flipX = false;
                }
                //direction = direction.normalized;
                transform.position = Vector2.MoveTowards(transform.position, CentrMark.transform.position, spiritspeed * Time.deltaTime);
                //rgdbody.MovePosition(transform.position + (direction * spiritspeed * Time.deltaTime));
                if (transform.position.x > lftBord.transform.position.x || transform.position.x < RghtBord.transform.position.x)
                {
                    GoBack = false;
                    IsRunning = false;
                }
            }
        }
        
    }
}
