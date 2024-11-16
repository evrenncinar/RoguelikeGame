
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;
using DG.Tweening;

public class ZombieEnemy : BaseEnemy
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private BulletSO _boneBulletSO;


    public override void Attack()
    {
        InstantiateBullet().Forget();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    private async UniTaskVoid InstantiateBullet()
    {
        if(_enemyHealt.GetHealth() > 0)
        {
            _enemyAnimation.SetTrigger(AllConst.EnemyAnimation.Attack);
            Vector3 direction = (base._playerTarget.position - _firePoint.position).normalized;

            //Kemiği spawnla ve kuvvet ver
            GameObject newZombieBullet = Instantiate(_boneBulletSO._bulletPrefab, _firePoint.position, Quaternion.identity);
            Rigidbody2D rb = newZombieBullet.GetComponent<Rigidbody2D>();
            rb.velocity = direction * _boneBulletSO._speed;

            ZombieBulletScript _zombieBulletScript = newZombieBullet.GetComponent<ZombieBulletScript>();
            _zombieBulletScript.SetDamage(_boneBulletSO._damage);

            Vector3 recoilPosition = transform.position - direction * _boneBulletSO._recoilForce;
            transform.DOMove(recoilPosition,0.2f); 
            await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
            base.ChangeState(new EnemyChaseState(this, _enemyAnimation));
        }
        

    }
}
