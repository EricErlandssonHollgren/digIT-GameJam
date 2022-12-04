using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hints : MonoBehaviour
{
    public GameObject[] hints;
    public int currenthint;
    public Canvas UI; 
    void Start()
    {
        currenthint = 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            var dia = Instantiate(hints[currenthint], new Vector3(0, 50, 0), Quaternion.identity);
            dia.transform.SetParent(UI.transform);
            StartCoroutine(showforsec(dia));
            currenthint++; 
        }
    }
    IEnumerator showforsec(GameObject rmove)
    {
        yield return new WaitForSeconds(20);
        Destroy(rmove);
    }
}
