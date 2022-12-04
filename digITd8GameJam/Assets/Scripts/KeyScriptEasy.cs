using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScriptEasy : MonoBehaviour
{
    public GameObject Door;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);
            Door.gameObject.SetActive(false);
        }
    }
}
