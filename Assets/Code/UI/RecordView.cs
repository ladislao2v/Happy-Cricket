using Code.Services.ScoreService;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.UI
{
    public class RecordView : Overlay
    {
        [SerializeField] private TextMeshProUGUI _recordText;

        public void Render(int record)
        {
            _recordText.text = record.ToString();
        }
    }
}