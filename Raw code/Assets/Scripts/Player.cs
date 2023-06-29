using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 4.1f;
    public GameObject panelDialog;
    public GameObject panelHealthAndItems;
    public float panic_time = 5;
    public float inv_time = 10;
    public Rigidbody2D rigitbody;
    bool nowwait = true;
    private Vector2 direction;
    public Animator myAnimator;
    public SpriteRenderer mysprite;

    private void Start()
    {
        panelDialog.SetActive(false);
        panelHealthAndItems.transform.GetChild(3).gameObject.SetActive(false); // Голубая бабочка
        panelHealthAndItems.transform.GetChild(4).gameObject.SetActive(false); // Жёлтая бабочка
        panelHealthAndItems.transform.GetChild(5).gameObject.SetActive(false); // Оранжевая бабочка
        panelHealthAndItems.transform.GetChild(6).gameObject.SetActive(false); // Бутер
    }
    void FixedUpdate()
    {
        if (GameManager.CanPlayerMove)
        {
            direction = Vector2.zero;
            if (panic_time >= 5) nowwait = true;
            if (panic_time <= 0) nowwait = false;
            Speeding();

            if (Input.GetKey(KeyCode.A))
            {
                direction.x = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                direction.x = 1;
            }
            if (Input.GetKey(KeyCode.W))
            {
                direction.y = 1;
                myAnimator.SetBool("IsFlying", true);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                direction.y = -0.5f;
                myAnimator.SetBool("IsFlying", true);
            }
            direction = direction.normalized;
            direction *= speed;
            rigitbody.velocity = direction;

            myAnimator.SetFloat("speed", Mathf.Abs(direction.x));

            if (direction.x < 0)
            {
                mysprite.flipX = true;
            }
            else if (direction.x > 0)
            {
                mysprite.flipX = false;
            }
        }
        checkifinv();
    }
    public void Collisionfloor()
    {
        myAnimator.SetBool("IsFlying", false);
    }
    void checkifinv()
    {
        if (GameManager.isInvisn)
            inv_time -= Time.deltaTime;
        if (inv_time <= 0)
        {
            GameManager.isInvisn = false;
            inv_time = 10;
        }
    }
    void Speeding()
    {
        if (Input.GetKey(KeyCode.LeftShift) && panic_time > 0 && nowwait)
        {
            speed = 8.2f;
            panic_time -= Time.deltaTime;
        }
        else
        {
            speed = 4.1f;
            if (panic_time < 5)
                panic_time += Time.deltaTime;
        }
    }
}
