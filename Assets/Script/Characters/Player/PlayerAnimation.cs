using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private Animator _animator;
    private bool OnGamePaused = false;
    void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (OnGamePaused) return;
        _animator.SetBool("IsMoving", _playerMovement.IsMove());
    }

    public void SetTrigger(string name)
    {
        _animator.SetTrigger(name);
    }

    //-------------------------------------------------------------------------------------
    private void OnEnable()
    {
        GameController.OnGamePaused += Stop;
        GameController.OnGameResumed += Resume;
    }
    private void OnDisable() {
        GameController.OnGamePaused -= Stop;
        GameController.OnGameResumed -= Resume;
    }

    public void Stop(){
        _animator.enabled = false;
        OnGamePaused = true;
    }

    public void Resume(){
        _animator.enabled = true;
        OnGamePaused = false;
    }
}
