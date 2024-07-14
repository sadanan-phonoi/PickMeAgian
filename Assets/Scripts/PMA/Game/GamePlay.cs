using System.Collections.Generic;
using Core.UI_Manager;
using PMA.Card;
using PMA.Enum;
using PMA.Event;
using PMA.Menu;
using PMA.Player;
using TMPro;
using UnityEngine; 

namespace PMA.Game
{
    public class GamePlay : MonoBehaviour
    {
        [SerializeField] private GamePanel gamePanel;
        [SerializeField] private TextMeshProUGUI turnText;
        [SerializeField] private TextMeshProUGUI scoreText;
        [Space]
        [SerializeField] private FlexibleGridLayout layout;
        [Space]
        [SerializeField] private Card cardPrefab;
        [SerializeField] private Transform target;
        
        private GameStageSO _gameStageSo; 
        private readonly List<Card> _listOfCard = new List<Card>();
        private readonly List<Card> _cardSelected = new List<Card>(); 
        
        private void Start()
        {
            cardPrefab.gameObject.SetActive(false);
            
            SubscribeOnScoreChanged(0);
            SubscribeOnTurnIncrease(0);
            GameEvent.OnScoreChanged += SubscribeOnScoreChanged;
            GameEvent.OnTurnIncrease += SubscribeOnTurnIncrease;
        } 
        private void Disable()
        {
            foreach (var card in _listOfCard)
            {
                Destroy(card.gameObject);
            }
            _listOfCard.Clear();
            _cardSelected.Clear();
        }
        #region Event 
        private void SubscribeOnScoreChanged(int score)
        {
            scoreText.text = GameText.SCORE + score;
        } 
        private void SubscribeOnTurnIncrease(int turn)
        {
            turnText.text = GameText.TURN + turn;
        } 
        #endregion
        public void Init(GameStageSO gameStageSo)
        {
            Disable();
            _gameStageSo = gameStageSo;
            gamePanel.SetPanel(GameEnum.EGamePanel.GAMEPLAY_PANEL); 
            
            var cardDeck = _gameStageSo.GetCardDeck(); 
            Shuffle(cardDeck);

            gameStageSo.Init();
            
            List<CardInfo> cardInfoList = new List<CardInfo>();
            foreach (var cardSo in cardDeck)
            {
                CardInfo cardInfo = new CardInfo(cardSo);
                var card = Instantiate(cardPrefab, target);
                card.Init(cardInfo, _gameStageSo.CardSetting.BackCard);
                card.gameObject.SetActive(true);
                card.OnCardClick += OnClickCard;
                _listOfCard.Add(card);
                cardInfoList.Add(cardInfo);
            } 
            layout.columns = _gameStageSo.StageSetting.CardValueX; 
            
            Player.Player.Instance.Init(_gameStageSo,cardInfoList);
            
            GameEvent.OnGameStart?.Invoke();
        }  
        public void Resume()
        {
            Disable();
            
            _gameStageSo = Player.Player.Instance.GameStage;
            gamePanel.SetPanel(GameEnum.EGamePanel.GAMEPLAY_PANEL); 
            
            var cardDeck =  Player.Player.Instance.CurrentCardInfo; 
             
            foreach (var cardInfo in cardDeck)
            {
                var card = Instantiate(cardPrefab, target);
                card.Init(cardInfo, _gameStageSo.CardSetting.BackCard);
                card.gameObject.SetActive(true);
                card.OnCardClick += OnClickCard;
                _listOfCard.Add(card);
            } 
            layout.columns = _gameStageSo.StageSetting.CardValueX;  
            GameEvent.OnGameStart?.Invoke();
        }  
       
        private void OnClickCard(Card info)
        {
            _cardSelected.Add(info);
            if (_cardSelected.Count >= _gameStageSo.StageSetting.CardCompareValue)
            {
                List<PMA.Card.Card> compareCard = new List<PMA.Card.Card>();
                foreach (var card in _cardSelected)
                    compareCard.Add(card.CardInfo.Card);

                int score = _gameStageSo.GetScore(compareCard);
                if (score != 0)
                {
                    Player.Player.Instance.IncreaseScore(score); 
                    Player.Player.Instance.SetCardSelected(info.CardInfo);
                    foreach (var card in _cardSelected)
                        card.Disable();
                }
                else
                {
                    foreach (var card in _cardSelected)
                        card.CloseCard();
                }

                Player.Player.Instance.IncreaseTurn();

                _cardSelected.Clear();
                CheckGameEnd();
            } 
             
        }
        
        private void CheckGameEnd()
        {
            if (Player.Player.Instance.IsCardSelectedAll())
            {
                gamePanel.ShowDialogOk(GameText.WIN, 
                    GameText.YOUR_SCORE + Player.Player.Instance.Score,
                    callback =>
                    {
                        Player.Player.Instance.GameReset();
                        gamePanel.SetPanel(GameEnum.EGamePanel.STAGE_SELECT_PANEL);
                        GameEvent.OnGameEnd?.Invoke();
                    });
                Disable();
            }
             
        }

        #region Shuffle Deck
        private void Shuffle(List<PMA.Card.Card> deck)
        {
            System.Random r = new System.Random();
            for (int n = deck.Count - 1; n > 0; --n)
            {
                int k = r.Next(n+1);
                PMA.Card.Card temp = deck[n];
                deck[n] = deck[k];
                deck[k] = temp;
            }
        }
        #endregion
       
    }
}
