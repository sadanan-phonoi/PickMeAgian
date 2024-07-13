using System;
using System.Collections;
using System.Collections.Generic;
using PMA.Card;
using PMA.Game;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; set; }
    
    [SerializeField] private GameStage stage;
    [SerializeField] private List<CardSO> cardSO = new List<CardSO>();
    [SerializeField] private List<int> cardSelectedId = new List<int>();
    [SerializeField] private int score;
    [SerializeField] private int turn; 
    public GameStage Stage => stage;
    public List<CardSO> CardSO => cardSO;
    public List<int> CardSelectedId => cardSelectedId;
    public int GetCardSelectedCount => cardSelectedId.Count;
    public int Score => score;
    public int Turn => turn; 
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
    } 
    public void Init(GameStage stage,List<CardSO> deck)
    {
        this.stage = stage;
        cardSO = deck;
    }

    public void GameReset()
    {
        stage = null;
        cardSO.Clear();
        cardSelectedId.Clear();
        score = 0;
        turn = 0;
    }
    public void IncreaseTurn()
    {
        turn++;
    }
    public void IncreaseScore(int value)
    {
        score += value;
    }
    public void SetCardSelectedId(int id)
    {
        cardSelectedId.Add(id);
    }
    
}
