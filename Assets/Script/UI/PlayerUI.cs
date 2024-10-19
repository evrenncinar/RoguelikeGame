using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private GameObject _damageTextPrefab;

    private void OnEnable() 
    {
        PlayerHealth.DamageAndHeal += ShowDamageAndHeal;
    }

    private void OnDisable() {
        PlayerHealth.DamageAndHeal -= ShowDamageAndHeal;
    }
    private void ShowDamageAndHeal(float _damageAmount, float _healAmount,float _maxHealth, Vector2 _hitPoint)
    {
        GameObject damageTextInstance = Instantiate(_damageTextPrefab, _hitPoint, Quaternion.identity);
        TextMeshPro textMesh = damageTextInstance.GetComponent<TextMeshPro>();
        textMesh.text = _damageAmount.ToString();
        damageTextInstance.transform.DOMoveY(_hitPoint.y + 0.5f, 1f);
        textMesh.DOFade(0f, 1f).OnComplete(() => Destroy(damageTextInstance));
    }
}
