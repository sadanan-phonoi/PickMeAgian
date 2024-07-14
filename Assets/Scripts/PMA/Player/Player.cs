using System.Collections.Generic;
using PMA.Event;
using PMA.Game;
using UnityEngine;

namespace PMA.Player
{
    public class Player : MonoBehaviour
    {
        public static Player Instance { get; set; }
    
        [SerializeField] private int score, turn; 
        [SerializeField] private GameStageSO gameStage; 
        [SerializeField] private List<CardInfo> currentCardInfo = new List<CardInfo>();   
        public int Score => score;
        public int Turn => turn; 
        public GameStageSO GameStage => gameStage; 
        public List<CardInfo> CurrentCardInfo => currentCardInfo;
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            Instance = this;
            GameReset();
        } 
        public void Init(GameStageSO stageSo,List<CardInfo> cardInfo)
        {
            this.gameStage = stageSo;
            this.currentCardInfo = cardInfo;
        } 
        public void GameReset()
        {
            gameStage = null; 
            currentCardInfo.Clear();
            score = 0;
            turn = 0;
            GameEvent.OnTurnIncrease?.Invoke(turn);
            GameEvent.OnScoreChanged?.Invoke(score);
        }
        public void IncreaseTurn()
        {
            turn++;
            GameEvent.OnTurnIncrease?.Invoke(turn);
        }
        public void IncreaseScore(int value)
        {
            score += value;
            GameEvent.OnScoreChanged?.Invoke(score);
        }
        public void SetCardSelected(CardInfo cardInfo)
        {
            if (currentCardInfo.Contains(cardInfo))
            {
                var cardList = currentCardInfo.FindAll(x=>x.CardSo.CardId == cardInfo.CardSo.CardId);
                foreach (var card in cardList)
                {
                    card.SelectCard();
                }
            }
        }
        public bool IsCardSelectedAll()
        {
            foreach (var cardInfo in currentCardInfo)
            {
                if (!cardInfo.IsCardSelected)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
