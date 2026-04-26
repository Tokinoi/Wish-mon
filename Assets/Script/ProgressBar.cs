using UnityEngine;
using UnityEngine.UI;

public class PercentageBar : MonoBehaviour
{
    [SerializeField] private Image _fillImage = null;
    [SerializeField] private int _maxValue = 100;

    [SerializeField] private int _currentValue = 100;

    public void SetValue(int value)
    {
        _currentValue = Mathf.Clamp(value, 0, _maxValue);
    }
        private void Update()
    {
        if (_fillImage == null) return;

        _fillImage.fillAmount = (float)_currentValue / _maxValue;
        Debug.Log($"Current Value: {_currentValue}, Fill Amount: {_fillImage.fillAmount}");

    }
}