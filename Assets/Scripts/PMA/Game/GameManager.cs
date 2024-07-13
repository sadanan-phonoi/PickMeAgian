using System;
using PMA.Menu;
using UnityEngine;

namespace PMA.Game
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameSetting gameSetting;
        [SerializeField] private GamePanel gamePanel;
        private void Start()
        {
            gamePanel.Init(gameSetting);
        }
    }
}
