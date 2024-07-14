using System.Collections.Generic;
using System.Linq; 
using UnityEngine;

namespace PMA.Card
{
    [CreateAssetMenu(fileName = "New CardSettingSO", menuName = "ScriptableObjects/CardSettingSO")]
    public class CardSettingSO : ScriptableObject
    {
        [SerializeField] private Sprite backCard;
        [SerializeField] private Sprite [] cardImage;
        [SerializeField] private List<Card> card; 
        public int CardValue => card.Count;
        public Sprite BackCard => backCard;
        public List<Card> GetCard => card.ToList(); 
        
#if UNITY_EDITOR
        public void OnValidate()
        { 
            card = new List<Card>();
            for (int i = 0; i < cardImage.Length; i++)
            {
                card.Add(new Card(i+1,cardImage[i]));
            }  
        }
#endif
    }
}
