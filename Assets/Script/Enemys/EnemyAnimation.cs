using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Start() 
    {
        _animator = GetComponent<Animator>();
    }

    public void SetTrigger(string name)
    {
        _animator.SetTrigger(name);
    }

    public void SetBool(string name, bool value)
    {
        _animator.SetBool(name, value);
    }

}
