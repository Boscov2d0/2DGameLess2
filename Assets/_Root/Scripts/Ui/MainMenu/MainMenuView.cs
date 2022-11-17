using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Ui
{
    internal class MainMenuView : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private string _productId;

        [Header("Buttons")]
        [SerializeField] private Button _buttonStart;
        [SerializeField] private Button _buttonSettings;
        [SerializeField] private Button _buttonShed;
        [SerializeField] private Button _buttonAdsReward;
        [SerializeField] private Button _buttonBuyProduct;
        [SerializeField] private Button _buttonDailyReward;
        [SerializeField] private Button _exitGame;

        [SerializeField] private Button _buttonRussianLanguage;
        [SerializeField] private Button _buttonEnglishLanguage;

        public void Init(UnityAction startGame, UnityAction openSettings,
            UnityAction openShed, UnityAction playRewardedAds, UnityAction<string> buyProduct,
            UnityAction openDailyReward, UnityAction exitGame, UnityAction translateToRussain, UnityAction translateToEnglish)
        {
            _buttonStart.onClick.AddListener(startGame);
            _buttonSettings.onClick.AddListener(openSettings);
            _buttonShed.onClick.AddListener(openShed);
            _buttonAdsReward.onClick.AddListener(playRewardedAds);
            _buttonBuyProduct.onClick.AddListener(() => buyProduct(_productId));
            _buttonDailyReward.onClick.AddListener(openDailyReward);
            _exitGame.onClick.AddListener(exitGame);

            _buttonRussianLanguage.onClick.AddListener(translateToRussain);
            _buttonEnglishLanguage.onClick.AddListener(translateToEnglish);
        }

        public void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
            _buttonSettings.onClick.RemoveAllListeners();
            _buttonShed.onClick.RemoveAllListeners();
            _buttonAdsReward.onClick.RemoveAllListeners();
            _buttonBuyProduct.onClick.RemoveAllListeners();
            _buttonDailyReward.onClick.RemoveAllListeners();
            _exitGame.onClick.RemoveAllListeners();

            _buttonRussianLanguage.onClick.RemoveAllListeners();
            _buttonEnglishLanguage.onClick.RemoveAllListeners();
        }
    }
}
