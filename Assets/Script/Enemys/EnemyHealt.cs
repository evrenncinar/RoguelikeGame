using UnityEngine;

public class EnemyHealt : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemySO _enemySO;
    [SerializeField] private float _currentHealth;
    [SerializeField] private EnemyUI _enemyUI;
    [SerializeField] private EnemyAnimation _enemyAnimation;

    private void Start()
    {
        _currentHealth = _enemySO._maxHealth;
        _enemyUI = GetComponent<EnemyUI>();
        _enemyAnimation = GetComponent<EnemyAnimation>();
    }
    
    public void Die()
    {
       _enemyAnimation.SetTrigger(AllConst.EnemyAnimation.Dead);
       Destroy(this.gameObject,_enemySO._destroyTime);
    }

    public void TakeDamage(float _damage, Vector2 _hitPoint)
    {
        _currentHealth -= _damage;
        if(_currentHealth <= 0)
        {
            Die();
        }
        else{
            _enemyAnimation.SetTrigger(AllConst.EnemyAnimation.Damage);
        }
        _enemyUI.ShowDamageText(_damage, _hitPoint);
    }

    public float GetHealth()
    {
        return _currentHealth;
    }
}
