using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionOpenGate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private string _colliderScript;

    [SerializeField]
    private UnityEvent _collisionEntered;

    [SerializeField]
    private UnityEvent _collisionExit;

    [SerializeField]
    private UnityEvent _triggerEntered;

    [SerializeField]
    private UnityEvent _triggerExit;





    private void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.GetComponent(_colliderScript))
        {
            _collisionEntered?.Invoke();
        }

    }

    void OnCollisionExit2D(Collision2D col) {
        if(col.gameObject.GetComponent(_colliderScript))
        {
            _collisionExit?.Invoke();
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent(_colliderScript))
        {
            _collisionEntered?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.GetComponent(_colliderScript))
        {
            _collisionExit?.Invoke();
        }
    }
}
