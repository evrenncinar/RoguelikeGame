using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "ScriptableObject/EnemySO")]
public class EnemySO : ScriptableObject
{
    public float _spawnTime;
    public float _maxHealth;
    public int _enemyLevel;
    public float _enemySpeed;
    public float _damage;
    public float _attackRange;
    public float _attackDelay;
    public float _destroyTime;
}
