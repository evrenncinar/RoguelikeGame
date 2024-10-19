using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 _startPosition;
    private float _range;
    private float _damage;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;

    private bool destroyed = false;

    private void Start() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _startPosition = transform.position;
    }

    private void Update() {
        if (destroyed) return;
        float distanceTravelled = Vector3.Distance(_startPosition, transform.position);
        if (distanceTravelled >= _range && !destroyed)
        {
            destroyThisObject();
        }
    }

    private void destroyThisObject()
    {
        destroyed = true;
        _animator.SetTrigger(AllConst.BulletAnimation.Destroy);
        _rigidbody2D.velocity = Vector2.zero;
        Destroy(gameObject,1f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (destroyed) return;
        if(other.CompareTag(AllConst.Tags.Wall))
        {
            destroyThisObject();
        }
        if(other.TryGetComponent(out IDamageable _damageable))
        {
            _damageable.TakeDamage(_damage, transform.position);
            destroyThisObject();
        }
    }
    

    public void SetRange(float range)
    {
        _range = range;
    }

    public void SetDamage(float damage)
    {
        _damage = damage;
    }
}
