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
        [SerializeField] private TextMeshProUGUI stageDifficulty;
        [Space,Header("StageSelectTab")]
        [SerializeField] private StageSelectTab stageSelectTabPrefab;
        [SerializeField] private Transform targetStageSelect;   
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

        public void Init(GameSettingSO gameSettingSo)
        {
            DisableUi();
            
            root.gameObject.SetActive(true);
            
            foreach (var stage in gameSettingSo.StageInfoList)
            { 
                var tab = Instantiate(stageSelectTabPrefab, targetStageSelect);
                tab.Init(stage);
                tab.OnButtonClickEvent += OnButtonClickTab; 
                tab.gameObject.SetActive(true);
                _listOfStageSelectTabs.Add(tab);
            }
        } 

        private void DisableUi()
        {
            root.gameObject.SetActive(false);

            DisableStageSelect();
            DisableStageInfo();
        } 
        private void OnButtonClickTab(GameStageSO info)
        {
            DisableStageInfo();
            
            foreach (var tab in _listOfStageSelectTabs)
            {
                tab.Disable();
            }

            stageTitle.text = info.GetStageName;
            stageDifficulty.text = GameText.STAGE_DIFFICULTY +info.StageDifficulty;
            
            foreach (var rule in info.ScoreRule)
            {
                var tab = Instantiate(stageInfoTabPrefab, targetStageInfo);
                tab.Init(rule);
                tab.gameObject.SetActive(true);
                _listOfStageInfoTabs.Add(tab);
            }
            GameEvent.OnStageSelected?.Invoke(info);
        }

        #region DestroyTab 
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
        #endregion
    }
}
