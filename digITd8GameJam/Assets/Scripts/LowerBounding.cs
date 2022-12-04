using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerBounding : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().removeHP(1000);
        }
    }
}
