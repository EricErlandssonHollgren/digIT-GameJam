using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public float speed;
    public int startingPoint;
    public Transform[] points;

    private GameObject target;
    private Vector3 offset;

    private int i; // index of the array
    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[startingPoint].position; // start position
        target = null;
    }

    // Update is called once per frame
    void Update()
    {

        if(Vector2.Distance(transform.position, points[i].position) < 0.02f) {
            i++;
            if (i == points.Length) {
                i = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        target = collision.gameObject;
        offset = target.transform.position - transform.position;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        target = null;
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            target.transform.position = transform.position + offset;
        }
    }
}
