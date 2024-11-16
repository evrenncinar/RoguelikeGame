using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ZombieBulletScript : MonoBehaviour
{
    private float _damage;
    private Rigidbody2D _rigidbody2D;
    private bool destroyed = false;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Invoke(nameof(DestroyThis),8f);
    }

    private void DestroyThis()
    {
        if(!destroyed)
        {
            destroyThisObject();
        }
        else
            return;
    }

    private void destroyThisObject()
    {
        destroyed = true;
        this.gameObject.transform.DOScale(0,0.2f).SetEase(Ease.Linear);
        _rigidbody2D.velocity = Vector2.zero;
        Destroy(gameObject,1f);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.TryGetComponent(out PlayerHealth _playerHealt))
        {
            _playerHealt.TakeDamage(_damage, transform.position);
            destroyThisObject();
        }
    }
    public void SetDamage(float damage)
    {
        _damage = damage;
    }
}
