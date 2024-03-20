using TMPro;
using UnityEngine;

namespace Code.UI
{
    public class WalletView : MonoBehaviour, IWalletView
    {
        [SerializeField] private TextMeshProUGUI _text;
            
        public void OnMoneyChanged(int value)
        {
            _text.text = $"{value}";
        }
    }
}