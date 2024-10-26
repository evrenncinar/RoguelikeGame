using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class SkeletonEnemy : BaseEnemy
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private BulletSO _boneBulletSO;

    private int _boneCount;

    protected override void Start()
    {
        base.Start();
        _boneCount = _boneBulletSO._bulletCount;
        _enemyHealt = GetComponent<EnemyHealt>();
    }

    public override void Attack()
    {
        // attack kodları
        InstantiateBone().Forget();
    }


    protected override void Update() 
    {
        base.Update();
    }

    public override void MoveTowardsPlayer()
    {
        base.MoveTowardsPlayer();
    }

    private async UniTaskVoid InstantiateBone()
    {
        while (_boneCount > 0)
        {
            if(_enemyHealt.GetHealth() > 0)
            {
                _enemyAnimation.SetTrigger(AllConst.EnemyAnimation.Attack);
                Vector3 direction = (base._playerTarget.position - _firePoint.position).normalized;

                //Kemiği spawnla ve kuvvet ver
                GameObject newBone = Instantiate(_boneBulletSO._bulletPrefab, _firePoint.position, Quaternion.identity);
                Rigidbody2D rb = newBone.GetComponent<Rigidbody2D>();
                rb.velocity = direction * _boneBulletSO._speed;

                EnemyBulletScript _skeletonBulletScript = newBone.GetComponent<EnemyBulletScript>();
                _skeletonBulletScript.SetDamage(_boneBulletSO._damage);
                _skeletonBulletScript.SetRange(_boneBulletSO._range);

                //Skeleton Geri Sekmesi ekle
                Vector3 recoilPosition = transform.position - direction * _boneBulletSO._recoilForce;
                transform.DOMove(recoilPosition,0.2f); 

                _boneCount--;
                await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
            }
            else
            {
                base.ChangeState(new EnemyIdleState(this, _enemyAnimation));
                break;
            }
        }
        base.ChangeState(new EnemyChaseState(this, _enemyAnimation));
        _boneCount = _boneBulletSO._bulletCount;
    }

    
}
