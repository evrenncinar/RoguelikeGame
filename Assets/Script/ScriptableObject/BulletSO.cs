
using UnityEngine;

[CreateAssetMenu(fileName = "BulletSO", menuName = "ScriptableObject/BulletSO")]
public class BulletSO : ScriptableObject
{
    public GameObject _bulletPrefab;
    public Sprite _bulletSprite;
    public string _bulletName;
    public float _speed;
    public float _damage;
    public int _bulletCount;
    public float _range;
    public float _fireRate;
    public float _recoilForce;
}