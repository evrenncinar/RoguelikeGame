using UnityEngine;

public interface IDamageable
{
    public void TakeDamage(float _damage, Vector2 _hitPoint);
    public void Die();
}
