using DG.Tweening;
using TMPro;
using UnityEngine;

public class EnemyUI : MonoBehaviour
{
    [SerializeField] private GameObject _damageTextPrefab;

    public void ShowDamageText(float _damage, Vector2 _hitPoint)
    {
        GameObject damageTextInstance = Instantiate(_damageTextPrefab, _hitPoint, Quaternion.identity);
        TextMeshPro textMesh = damageTextInstance.GetComponent<TextMeshPro>();
        textMesh.text = _damage.ToString();
        damageTextInstance.transform.DOMoveY(_hitPoint.y + 0.5f, 1f);
        textMesh.DOFade(0f, 1f).OnComplete(() => Destroy(damageTextInstance));
    }
}
