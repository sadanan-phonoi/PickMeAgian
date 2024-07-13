using System;
using System.Collections.Generic;
using PMA.Card;
using PMA.Enum;
using PMA.Menu;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace PMA.Game
{
    public class GamePlay : MonoBehaviour
    {
        [SerializeField] private GamePanel gamePanel;
        [SerializeField] private GridLayoutGroup gridLayoutGroup;
        [Space]
        [SerializeField] private Card cardPrefab;
        [SerializeField] private Transform target;
        
        private GameStage _gameStage; 
        private List<Card> _listOfCard = new List<Card>();
        private List<Card> _cardSelected = new List<Card>();
        
        private void Start()
        {
            cardPrefab.gameObject.SetActive(false);
        }  
        private void Disable()
        {
            foreach (var card in _listOfCard)
            {
                Destroy(card);
            }
            _listOfCard.Clear();
        } 
        public void Init(GameStage gameStage)
        { 
            _gameStage = gameStage;
            gamePanel.SetPanel(GameEnum.EGamePanel.GAMEPLAY_PANEL); 
            
            var cardDeck = _gameStage.GetCardDeck();
            Shuffle(cardDeck);
             
            foreach (var cardSO in cardDeck)
            {
                var card = Instantiate(cardPrefab, target);
                card.Init(cardSO, _gameStage.CardSetting.BackCard);
                card.gameObject.SetActive(true);
                card.OnCardClick += OnClickCard;
                _listOfCard.Add(card);
            } 
            gridLayoutGroup.constraintCount = _gameStage.StageSetting.CardValueX; 
            
            Player.Instance.Init(_gameStage, cardDeck);
        }  
        public void Resume()
        {
            _gameStage = Player.Instance.Stage;
            gamePanel.SetPanel(GameEnum.EGamePanel.GAMEPLAY_PANEL); 
            
            var cardDeck =  Player.Instance.CardSO; 
             
            foreach (var cardSO in cardDeck)
            {
                var card = Instantiate(cardPrefab, target);
                card.Init(cardSO, _gameStage.CardSetting.BackCard);
                card.gameObject.SetActive(true);
                card.OnCardClick += OnClickCard;
                _listOfCard.Add(card);
            } 
            gridLayoutGroup.constraintCount = _gameStage.StageSetting.CardValueX; 
            
            Player.Instance.Init(_gameStage, cardDeck);
        }  
        void Shuffle(List<CardSO> deck)
        { 
            Random r = new Random(); 
            for (int n = deck.Count - 1; n > 0; --n)
            {
                int k = r.Next(n + 1);
                var temp = deck[n];
                deck[n] = deck[k];
                deck[k] = temp;
            }
        }
        private void OnClickCard(Card info)
        {
            _cardSelected.Add(info);
            if (_cardSelected.Count >= _gameStage.StageSetting.CardCompareValue)
            {
                List<CardSO> compareCard = new List<CardSO>();
                foreach (var card in _cardSelected) 
                    compareCard.Add(card.CardInfo); 
                
                int score = _gameStage.GetScore(compareCard);
                if (score == 0)
                {
                    foreach (var card in _cardSelected) 
                        card.Disable();
                    _cardSelected.Clear(); 
                }
                else
                {
                    Player.Instance.IncreaseScore(score);
                    Player.Instance.SetCardSelectedId(_cardSelected[0].CardInfo.CardId);
                }
                Player.Instance.IncreaseTurn();
                
                CheckPlayerWin();
            } 
        }
        
        private void CheckPlayerWin()
        {
            if (Player.Instance.GetCardSelectedCount >= _gameStage.StageSetting.TotalCard)
            {
                gamePanel.ShowDialogOk(GameText.WIN, 
                    GameText.YOUR_SCORE + Player.Instance.Score,
                    callback =>
                    {
                        Player.Instance.GameReset();
                        gamePanel.SetPanel(GameEnum.EGamePanel.STAGE_SELECT_PANEL);
                    });
            }
             
        }
    }
}
