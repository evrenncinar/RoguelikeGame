using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class BatEnemy : BaseEnemy
{
    [SerializeField] private Transform firePoints;
    [SerializeField] private BulletSO _bulletSO;



    public override void Attack()
    {
        AttackBat().Forget();
    }

    private async UniTaskVoid AttackBat()
    {
        
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }
}
