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
        public void Init(StageSetting stageSetting)
        {
            text.text = GameText.CARD_MATCHING+stageSetting.CardCompareValue;
        }
    }
}
