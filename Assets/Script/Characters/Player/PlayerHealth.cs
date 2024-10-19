using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _maxHealth;
    [SerializeField] private PlayerAnimation _playerAnimation;

    public static event System.Action<float,float,float,Vector2> DamageAndHeal;
    
    private void Awake() {
        _playerAnimation = GetComponent<PlayerAnimation>();
    }
    void Start()
    {
        _currentHealth = _maxHealth;
    }


    public void TakeDamage(float damage,Vector2 _hitPoint)
    {
        _currentHealth -= damage;
        _playerAnimation.SetTrigger(AllConst.PlayerAnimation.Damage);
        DamageAndHeal?.Invoke(damage, _currentHealth, _maxHealth, _hitPoint);
    }
}
