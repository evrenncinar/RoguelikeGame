using UnityEngine;

public class EnemySpawnState : EnemyStateBase
{
    private float _spawnTimer;
    public EnemySpawnState(BaseEnemy _enemy, EnemyAnimation _enemyAnimation) : base(_enemy, _enemyAnimation) { }

    public override void Enter()
    {
        _spawnTimer = _enemy._enemySO._spawnTime;
        _enemyAnimation.SetTrigger(AllConst.EnemyAnimation.Spawn);
    }
    

    public override void Exit()
    {

    }

    public override void Update()
    {
        _spawnTimer -= Time.deltaTime;
        if (_spawnTimer <= 0)
        {
            _enemy.ChangeState(new EnemyChaseState(_enemy, _enemyAnimation));
        }
    }
}
