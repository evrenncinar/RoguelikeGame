
public class EnemyChaseState : EnemyStateBase
{
    public EnemyChaseState(BaseEnemy _enemy, EnemyAnimation _enemyAnimation) : base(_enemy, _enemyAnimation) { }

    public override void Enter()
    {
        _enemyAnimation.SetBool(AllConst.EnemyAnimation.ChaseBool, true);
    }

    public override void Update()
    {
        _enemy.MoveTowardsPlayer();
        if (_enemy.IsPlayerInAttackRange())
        {
            _enemy.ChangeState(new EnemyAttackState(_enemy, _enemyAnimation));
        }
    }

    public override void Exit()
    {
        _enemyAnimation.SetBool(AllConst.EnemyAnimation.ChaseBool, false);
    }
}
