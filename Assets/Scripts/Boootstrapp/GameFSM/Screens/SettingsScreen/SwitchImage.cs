using UnityEngine;
using UnityEngine.UI;

public class SwitchImage : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _spriteActive;
    [SerializeField] private Sprite _spriteDisable;

    private bool _value;
    public Button Button => _button;
    public bool Result => _value;

    private void OnEnable() => _button.onClick.AddListener(SwitchValue);

    public void SetValue(bool value)
    {
        _value = value;
        SetImage(_value);
    }


    public void SwitchValue()
    {
        var result = !_value;
        _value = result;
        SetImage(_value);
    }

    private void SetImage(bool value)
    {
        if (value)
            _image.sprite = _spriteActive;
        else
            _image.sprite = _spriteDisable;
    }

    private void OnDisable() => _button.onClick.RemoveListener(SwitchValue);
}