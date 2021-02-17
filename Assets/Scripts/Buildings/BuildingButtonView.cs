using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingButtonView : MonoBehaviour
{
    [SerializeField] private ObjectPriceView _priceView;
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _name;

    public void Present(BuildingProfile profile)
    {
        _image.sprite = profile.Icon;
        _name.text = profile.Name;
        _priceView.Present(profile.Price);
    }
}
