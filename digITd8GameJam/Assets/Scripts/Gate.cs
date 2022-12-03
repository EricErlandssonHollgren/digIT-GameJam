using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private Animator _animator;

    private void Awake() 
    {
        _animator = GetComponent<Animator>();
    }

    [ContextMenu("Open")]
    public void Open()
    {
        _animator.SetTrigger("Open");
    }
}
