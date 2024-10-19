using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealtBulletUI : MonoBehaviour
{
    [SerializeField] private Image _bulletImage;
    [SerializeField] private Image _bulletCountImage;
    [SerializeField] private Image _healtImage;
    [SerializeField] private TMP_Text _healtText;
    [SerializeField] private TMP_Text _bulletCountText;
    [SerializeField] private TMP_Text _bulletNameText;
    [SerializeField] private Image _damageEffectImage;

    private void OnEnable() 
    {
        PlayerBulletManager.OnShoot += UpdateShootUI;
        PlayerBulletManager.CollectBulletEvent += UpdateCollectUI;
        PlayerHealth.DamageAndHeal += ShowDamageAndHeal;
    }

    private void OnDisable() 
    {
        PlayerBulletManager.OnShoot -= UpdateShootUI;    
        PlayerBulletManager.CollectBulletEvent -= UpdateCollectUI;
        PlayerHealth.DamageAndHeal -= ShowDamageAndHeal;
    }

    private void UpdateShootUI(BulletSO _bulletSO, int _currentBulletCount)
    {
        if(_currentBulletCount > 0)
        {
            _bulletCountText.text = _currentBulletCount.ToString();
            _bulletCountImage.DOFillAmount((float)_currentBulletCount / _bulletSO._bulletCount, 0.5f).SetEase(Ease.Linear);
        }
        else{
            _bulletCountText.DOFade(0f,0.1f).SetEase(Ease.Linear).onComplete = () => _bulletCountText.text = "";
            //
            _bulletNameText.DOFade(0f,0.1f).SetEase(Ease.Linear).onComplete = () => _bulletNameText.text = "";
            //
            _bulletCountImage.DOFillAmount(0f,0.5f).SetEase(Ease.Linear);
            //
            _bulletImage.DOFade(0f,0.1f).SetEase(Ease.Linear).onComplete = () => _bulletImage.gameObject.SetActive(false);
        }
    }

    private void UpdateCollectUI(BulletSO _bullletSO)
    {
        _bulletNameText.text = _bullletSO._bulletName;
        _bulletNameText.DOFade(1f,0.1f).SetEase(Ease.Linear);
        //
        _bulletCountText.text = _bullletSO._bulletCount.ToString();
        _bulletCountText.DOFade(1f,0.1f).SetEase(Ease.Linear);
        //
        _bulletCountImage.DOFillAmount(1f,0.5f).SetEase(Ease.Linear);
        //
        _bulletImage.gameObject.SetActive(true);
        _bulletImage.sprite = _bullletSO._bulletSprite;
        _bulletImage.DOFade(1f,0.1f).SetEase(Ease.Linear);
    }

    private void ShowDamageAndHeal(float _damageAmount, float _healAmount,float _maxHealth, Vector2 _hitPoint)
    {
        _damageEffectImage.DOFade(0.2f,0.1f).SetEase(Ease.Linear).onComplete = () => _damageEffectImage.DOFade(0f,0.1f).SetEase(Ease.Linear);
        _healtImage.DOFillAmount((float)_healAmount / _maxHealth , 0.5f).SetEase(Ease.Linear);
        _healtText.text = _healAmount.ToString();
    }

}
