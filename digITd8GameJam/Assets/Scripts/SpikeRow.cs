using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeRow : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject target = collision.gameObject;
            target.GetComponent<PlayerController>().removeHP(100000);
        }
    }
}
