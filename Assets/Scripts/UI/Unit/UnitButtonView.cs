using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitButtonView : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Image _progressImage;
    [SerializeField] private Button _button;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private ObjectPriceView _priceView;

    public Button BuyUnitButton => _button;

    public UnitProfle Profile { get; private set; }

    public event System.Action<UnitButtonView> Clicked;

    private void OnEnable()
    {
        _button.onClick.AddListener(() => Clicked?.Invoke(this));
    }

    public void Present(UnitProfle profile)
    {
        Profile = profile;
        _icon.sprite = profile.Icon;
        _priceView.Present(profile.Price);
    }

    public void SetProgress(float normalizedProgress)
    {
        _progressImage.fillAmount = 1 - normalizedProgress;

        if (normalizedProgress >= 1)
        {
            _canvasGroup.blocksRaycasts = true;
        }
        else
        {
            _canvasGroup.blocksRaycasts = false;
        }
    }

    public void ResetProgress()
    {
        _progressImage.fillAmount = 0;
        _canvasGroup.blocksRaycasts = true;
    }
}
