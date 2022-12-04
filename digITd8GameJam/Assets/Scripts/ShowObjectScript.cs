using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowObjectScript : MonoBehaviour
{
    public GameObject show;
    public float SecondsToShow;
    private GameObject cam;
    private PlayerCamera p;
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        p = cam.GetComponent<PlayerCamera>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            p.ShowObjectForSeconds(show,SecondsToShow);
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
