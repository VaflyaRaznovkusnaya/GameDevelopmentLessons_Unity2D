using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlDoor : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (GameManager.IsCrawlDoorOpen)
        {
            Destroy(this.gameObject);
        }
    }
}
