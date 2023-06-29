using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    public string Destination = "";
    public string Alt_Destination = "";
    public float x, y;
    public bool ifportable;
    public bool peek_up;
    public Camera camera_down, camera_up;
    public GameObject DoorPanel;

    private void Start()
    {
        camera_down.enabled = false;
        camera_up.enabled = false;
    }
    
    public void InputE(GameObject nearTo)
    {
        if (ifportable)
        {
            GameManager.CanPlayerMove = false;
            DoorPanel.SetActive(true);
            //GoToLevel();
        }
        else
        {
            nearTo.transform.position = new Vector3(x, y, nearTo.transform.position.z);
        }
    }
    public void InputQ(GameObject nearTo)
    {
        Camera maincam = nearTo.GetComponent<collisionDamage>().myCamera;

        if (!ifportable)
        {
            if (maincam.enabled)
            {
                if (peek_up)
                {
                    //myCamera.enabled = false;
                    camera_down.enabled = false;
                    camera_up.enabled = true;
                    maincam.enabled = false;
                }
                else
                {
                    //myCamera.enabled = false;
                    camera_up.enabled = false;
                    camera_down.enabled = true;
                    maincam.enabled = false;
                }
            }
            else if (!maincam.enabled)
            {

                camera_down.enabled = false;
                camera_up.enabled = false;
                //myCamera.enabled = true;
                maincam.enabled = true;
            }
        }
    }
    /*public void GoToLevel()
    {
        if (ifportable)
        {
            SceneManager.LoadScene("Final");         
        }
        
    }*/

}
