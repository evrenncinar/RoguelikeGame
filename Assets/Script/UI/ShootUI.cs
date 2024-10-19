using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShootUI : MonoBehaviour
{
    [SerializeField] private Image _coolDownImage;
    [SerializeField] private TextMeshProUGUI _noBulletText;

    private Vector3 _nobulletTextStartPos;
    private bool _canShowNoBulletUI = true;
    
    private void Start() {
        _nobulletTextStartPos = _noBulletText.rectTransform.anchoredPosition;
        _noBulletText.DOFade(0f,0f);
    }

    private void OnEnable() 
    {
        PlayerBulletManager.OnShoot += UpdateShootUI;
        PlayerBulletShooting.NoBulletEvent += InvokeNoBulletUI;
    }

    private void OnDisable() 
    {
        PlayerBulletManager.OnShoot -= UpdateShootUI;    
        PlayerBulletShooting.NoBulletEvent -= InvokeNoBulletUI;
    }
    private void UpdateShootUI(BulletSO _bulletSO, int _currentBulletCount)
    {
        _canShowNoBulletUI = false;
        _coolDownImage.fillAmount = 1f;
        _coolDownImage.DOFillAmount(0f,_bulletSO._fireRate).SetEase(Ease.Linear).onComplete = () => _canShowNoBulletUI = true;
    }

    private void InvokeNoBulletUI()
    {
        if(!_canShowNoBulletUI) return;

        _canShowNoBulletUI = false;

        _noBulletText.DOFade(1f,0f);

        _noBulletText.rectTransform.DOAnchorPos(new Vector2(_nobulletTextStartPos.x,_nobulletTextStartPos.y + 0.5f),0.3f).SetEase(Ease.Linear);

        _noBulletText.DOFade(0f,0.3f).SetEase(Ease.Linear).onComplete = () => 
        {
            _canShowNoBulletUI = true;
            _noBulletText.rectTransform.anchoredPosition = _nobulletTextStartPos;
        };
    }

    
}
