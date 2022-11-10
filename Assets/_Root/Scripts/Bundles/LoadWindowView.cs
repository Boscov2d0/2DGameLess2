using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Collections.Generic;

namespace Tool.Bundles.Examples
{
    internal class LoadWindowView : AssetBundleViewBase
    {
        //[Header("Asset Bundles")]
        //[SerializeField] private Button _loadAssetsButton;
        [SerializeField] private Button _changeButtonBackgroundButton;

        //[Header("Addressables")]
        //[SerializeField] private AssetReference _spawningButtonPrefab;
        //[SerializeField] private RectTransform _spawnedButtonsContainer;
        //[SerializeField] private Button _spawnAssetButton;

        [SerializeField] private AssetReference _background;
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Button _addBackgroundButton;
        [SerializeField] private Button _removeBackgroundButton;

        private readonly List<AsyncOperationHandle<GameObject>> _addressablePrefabs =
            new List<AsyncOperationHandle<GameObject>>();

        private AsyncOperationHandle<Sprite> _loadBackground;

        private void Start()
        {
            //_loadAssetsButton.onClick.AddListener(LoadAssets);
            //_spawnAssetButton.onClick.AddListener(SpawnPrefab);

            _changeButtonBackgroundButton.onClick.AddListener(ChangeButtonBackground);
            _addBackgroundButton.onClick.AddListener(AddBackground);
            _removeBackgroundButton.onClick.AddListener(RemoveBackground);
        }

        private void OnDestroy()
        {
            //_loadAssetsButton.onClick.RemoveAllListeners();
            //_spawnAssetButton.onClick.RemoveAllListeners();

            _changeButtonBackgroundButton.onClick.RemoveAllListeners();
            _addBackgroundButton.onClick.RemoveAllListeners();
            _removeBackgroundButton.onClick.RemoveAllListeners();

            DespawnPrefabs();
            RemoveBackground();
        }
        
        private void LoadAssets()
        {
            //_loadAssetsButton.interactable = false;
            StartCoroutine(DownloadAndSetAssetBundles());
        }
        private void ChangeButtonBackground()
        {
            _changeButtonBackgroundButton.interactable = false;
            StartCoroutine(DownloadAndSetBackgroundsAssetBundle());
        }
        /*
        private void SpawnPrefab()
        {
            AsyncOperationHandle<GameObject> addressablePrefab =
                Addressables.InstantiateAsync(_spawningButtonPrefab, _spawnedButtonsContainer);

            _addressablePrefabs.Add(addressablePrefab);
        }
        */
        private void DespawnPrefabs()
        {
            foreach (AsyncOperationHandle<GameObject> addressablePrefab in _addressablePrefabs)
                Addressables.ReleaseInstance(addressablePrefab);

            _addressablePrefabs.Clear();
        }
        private void AddBackground()
        {
            if (!_loadBackground.IsValid())
            {
                _loadBackground = Addressables.LoadAssetAsync<Sprite>(_background);
                _loadBackground.Completed += OnBackgrounLoaded;
            }
        }
        private void RemoveBackground()
        {
            if (_loadBackground.IsValid())
            {
                _loadBackground.Completed -= OnBackgrounLoaded;
                Addressables.Release(_loadBackground);
                SetBackground(null);
            }
        }
        private void OnBackgrounLoaded(AsyncOperationHandle<Sprite> asyncOperationHandle)
        {
            asyncOperationHandle.Completed -= OnBackgrounLoaded;
            SetBackground(asyncOperationHandle.Result);
        }
        private void SetBackground(Sprite background)
        {
            _backgroundImage.sprite = background;
        }
    }
}