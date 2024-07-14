using System.Collections.Generic;
using System.Linq; 
using UnityEngine;

namespace PMA.Card
{
    [CreateAssetMenu(fileName = "New CardSettingSO", menuName = "ScriptableObjects/CardSettingSO")]
    public class CardSettingSO : ScriptableObject
    {
        [SerializeField] private Sprite backCard;
        [SerializeField] private CardSO[] card; 
        public int CardValue => card.Length*2;
        public Sprite BackCard => backCard;
        public List<CardSO> GetCard => card.ToList(); 
        public void OnValidate()
        {
            foreach (var c in card)
            {
                if(c.CardId == 0)
                    Debug.LogError("Card Id Not Set");
            }
        }
    }
}
