using DG.Tweening;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    public EnemySO _enemySO;
    public EnemyAnimation _enemyAnimation;
    protected Transform _playerTarget;
    protected EnemyStateBase _currentState;

    private float _attackCoolDown;
    private bool facingRight = true;
    protected EnemyHealt _enemyHealt;
    [SerializeField] private float _flipSpeed = 0.2f;

    protected virtual void Start()
    {
        _enemyAnimation = GetComponent<EnemyAnimation>();
        _playerTarget = GameObject.FindAnyObjectByType<PlayerMovement>().transform;
        ChangeState(new EnemySpawnState(this, _enemyAnimation));
    }

    public void ChangeState(EnemyStateBase newState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }
        _currentState = newState;
        _currentState.Enter();
    }

    protected virtual void Update()
    {
        if(_attackCoolDown > 0)
        {
            _attackCoolDown -= Time.deltaTime;
        }
        if(_enemyHealt.GetHealth() <= 0)
        {
            ChangeState(new EnemyIdleState(this, _enemyAnimation));
        }
        _currentState.Update();
    }

    public abstract void Attack();

    public bool IsPlayerInAttackRange()
    {
        if(_attackCoolDown <= 0)
        {
            return Vector2.Distance(transform.position, _playerTarget.position) < _enemySO._attackRange;
        }
        else
        {
            return false;
        }
    }

    public void setAttackCoolDown()
    {
        _attackCoolDown = this._enemySO._attackDelay;
    }

    public virtual void MoveTowardsPlayer()
    {
        Vector2 direction = (_playerTarget.position - transform.position).normalized;
        if (direction.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (direction.x < 0 && facingRight)
        {
            Flip();
        }
        transform.position += (Vector3)direction * _enemySO._enemySpeed * Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        if(_enemySO == null){return;}
        //range göster
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _enemySO._attackRange); 
    }

    void Flip()
    {
        facingRight = !facingRight;
        if(facingRight == true)
            transform.DOScaleX(1f,_flipSpeed);
        else
            transform.DOScaleX(-1f,_flipSpeed);
    }

}
