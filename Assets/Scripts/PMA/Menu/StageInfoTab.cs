using PMA.Game;
using TMPro;
using UnityEngine;

namespace PMA.Menu
{
    public class StageInfoTab : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        
        public void Init(ScoreRule scoreRule)
        {
            text.text = scoreRule.RuleName;
        }
    }
}
