using System;
using System.Collections.Generic;
using PMA.Event;
using PMA.Game;
using TMPro;
using UnityEngine; 

namespace PMA.Menu
{
    public class StageSelectCtrl : MonoBehaviour
    {
        [SerializeField] private GameObject root; 
        [SerializeField] private TextMeshProUGUI stageTitle;
        [Space,Header("StageSelectTab")]
        [SerializeField] private StageSelectTab stageSelectTabPrefab;
        [SerializeField] private Transform targetStageSelect;  
        [Space]
        private List<StageSelectTab> _listOfStageSelectTabs = new List<StageSelectTab>();
        [Space,Header("StageInfoTab")]
        [SerializeField] private StageInfoTab stageInfoTabPrefab;
        [SerializeField] private Transform targetStageInfo;  
        private List<StageInfoTab> _listOfStageInfoTabs = new List<StageInfoTab>();
        
        void Start()
        { 
            stageSelectTabPrefab.gameObject.SetActive(false);
            stageInfoTabPrefab.gameObject.SetActive(false);
        }

        public void RefreshUi(GameSetting gameSetting)
        {
            root.gameObject.SetActive(true);
            
            foreach (var stage in gameSetting.StageInfoList)
            {
                var tab = Instantiate(stageSelectTabPrefab, targetStageSelect);
                tab.Init(stage.Stage);
                tab.OnButtonClickEvent += OnButtonClickTab; 
                tab.gameObject.SetActive(true);
                _listOfStageSelectTabs.Add(tab);
            }
        }

        public void DisableUi()
        {
            root.gameObject.SetActive(false);

            DisableStageSelect();
            DisableStageInfo();
        }

        private void OnButtonClickTab(GameStage info)
        {
            DisableStageInfo();
            
            foreach (var tab in _listOfStageSelectTabs)
            {
                tab.Disable();
            }

            stageTitle.text = info.GetStageName;
            foreach (var rule in info.ScoreRule)
            {
                var tab = Instantiate(stageInfoTabPrefab, targetStageInfo);
                tab.Init(rule);
                tab.gameObject.SetActive(true);
                _listOfStageInfoTabs.Add(tab);
            }
            GameEvent.OnStageSelected?.Invoke(info);
        }

        void DisableStageSelect()
        {
            foreach (var tab in _listOfStageSelectTabs)
            {
                Destroy(tab.gameObject);
            }
            _listOfStageSelectTabs.Clear();
        }
        void DisableStageInfo()
        {
            foreach (var tab in _listOfStageInfoTabs)
            {
                Destroy(tab.gameObject);
            }
            _listOfStageInfoTabs.Clear();
        }
    }
}
