using UnityEngine;

public class EnemyAttackState : EnemyStateBase
{
    private float _attackCooldown = 0;

    public EnemyAttackState(BaseEnemy _enemy, EnemyAnimation _enemyAnimation) : base(_enemy, _enemyAnimation) { }

    public override void Enter()
    {

    }

    public override void Update()
    {
        _attackCooldown -= Time.deltaTime;
        if (_attackCooldown <= 0)
        {
            _enemy.Attack(); 
            _enemy.setAttackCoolDown();
            _attackCooldown = _enemy._enemySO._attackDelay;
        }
    }

    public override void Exit()
    {
        
    }
}
