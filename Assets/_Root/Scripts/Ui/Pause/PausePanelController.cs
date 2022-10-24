using Profile;
using Tool;
using UnityEngine;

internal class PausePanelController : BaseController
{
    private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/Pause/PausePanelView");
    private readonly ProfilePlayer _profilePlayer;
    private readonly PausePanelView _view;

    public PausePanelController(Transform placeForUi, ProfilePlayer profilePlayer)
    {
        _profilePlayer = profilePlayer;
        _view = LoadView(placeForUi);

        Subscribe(_view);
    }

    protected override void OnDispose()
    {
        Unsubscribe(_view);
    }


    private PausePanelView LoadView(Transform placeForUi)
    {
        GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
        GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
        AddGameObject(objectView);

        return objectView.GetComponent<PausePanelView>();
    }

    private void Subscribe(PausePanelView view)
    {
        view.ContinueGameButton.onClick.AddListener(Continue);
        view.ToMenuButton.onClick.AddListener(Close);
    }

    private void Unsubscribe(PausePanelView view)
    {
        view.ContinueGameButton.onClick.RemoveAllListeners();
        view.ToMenuButton.onClick.RemoveAllListeners();
    }
    private void Continue() => _profilePlayer.CurrentState.Value = GameState.Game;
    private void Close() => _profilePlayer.CurrentState.Value = GameState.Start;
}
