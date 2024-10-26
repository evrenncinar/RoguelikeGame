using Cysharp.Threading.Tasks;
using System;
using DG.Tweening;
using UnityEngine;

public class SlimeEnemy : BaseEnemy
{
    [SerializeField] private Transform[] firePoints;
    [SerializeField] private BulletSO _bulletSO;
    [SerializeField] Vector2 areaSizeX = new Vector2(5f, 5f); // Kare boyutu
    [SerializeField] Vector2 areaSizeY = new Vector2(5f, 5f); // Kare boyutu


    [SerializeField] private Vector2 targetPosition;
    public override void Attack()
    {
        SpawnSlimeBullet().Forget();
    }

    private async UniTaskVoid SpawnSlimeBullet()
    {
        _enemyAnimation.SetTrigger(AllConst.EnemyAnimation.Attack);
        await UniTask.Delay(TimeSpan.FromSeconds(0.165f));
        
        foreach (Transform firePoint in firePoints)
        {
            GameObject newBullet = Instantiate(_bulletSO._bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
            rb.velocity = firePoint.rotation * Vector3.up * _bulletSO._speed;
            EnemyBulletScript enemyBulletScript = newBullet.GetComponent<EnemyBulletScript>();
            enemyBulletScript.SetDamage(_bulletSO._damage);
            enemyBulletScript.SetRange(_bulletSO._range);
        }

        await UniTask.Delay(TimeSpan.FromSeconds(1.5f));
        SetNewTargetPosition();
        base.ChangeState(new EnemyChaseState(this, _enemyAnimation));
    }

    protected override void Start()
    {
        SetNewTargetPosition();
        base.Start();
    }
    protected override void Update()
    {
        base.Update(); 
    }
    private void SetNewTargetPosition()
    {
        float randomX = UnityEngine.Random.Range(areaSizeX.x, areaSizeX.y);
        float randomY = UnityEngine.Random.Range(areaSizeY.x, areaSizeY.y);
        targetPosition = new Vector2(randomX, randomY);
    }
    public override void MoveTowardsPlayer()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, _enemySO._enemySpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            base.ChangeState(new EnemyAttackState(this, _enemyAnimation));
        }
        Debug.DrawLine(transform.position, targetPosition, Color.red);
    }
}
