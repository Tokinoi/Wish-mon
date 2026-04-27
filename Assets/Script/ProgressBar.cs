using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image _fillImage = null;
    [SerializeField] private int _maxValue = 100;
    private int _currentValue = 100;

    public void SetValue(int value)
    {
        _currentValue = Mathf.Clamp(value, 0, _maxValue);
        if (_fillImage != null)
            _fillImage.fillAmount = (float)_currentValue / _maxValue;
    }

    public void SetMax(int maxValue)
    {
        _maxValue = maxValue;
        SetValue(_currentValue);
    }
}