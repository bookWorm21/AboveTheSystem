using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingButtonView : MonoBehaviour
{
    [SerializeField] private BuildPriceView _priceView;
    [SerializeField] private BuildingProfile _profile;
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _name;

    private void Start()
    {
        Present();
    }

    public void Present()
    {
        _image.sprite = _profile.Icon;
        _name.text = _profile.Name;
        _priceView.Present(_profile.Price);
    }
}
