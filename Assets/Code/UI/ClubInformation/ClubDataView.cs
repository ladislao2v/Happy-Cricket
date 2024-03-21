using Code.Services.ClubService;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.ClubInformation
{
    public class ClubDataView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _nameText;
        
        public void Construct(IClubData clubData)
        {
            _image.sprite = clubData.Logo;
            _nameText.text = clubData.Name;
        }
    }
}