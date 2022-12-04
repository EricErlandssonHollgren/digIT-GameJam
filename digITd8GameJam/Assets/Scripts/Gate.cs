using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private Animator _animatr;

    private void Awake() 
    {
        _animatr = GetComponent<Animator>();
    }

    [ContextMenu("Open")]
    public void Open()
    {
        _animatr.SetTrigger("Open");
    }
}
