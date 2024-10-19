public abstract class EnemyStateBase 
{
    protected BaseEnemy _enemy;
    protected EnemyAnimation _enemyAnimation;

    public EnemyStateBase(BaseEnemy enemy, EnemyAnimation enemyAnimation)
    {
        this._enemy = enemy;
        this._enemyAnimation = enemyAnimation;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}
