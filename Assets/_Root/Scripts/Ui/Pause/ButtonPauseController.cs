using Profile;
using Tool;
using UnityEngine;

internal class ButtonPauseController : BaseController
{
    private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/Pause/PauseButtonView");

    private readonly ButtonPauseView _view;
    private readonly ProfilePlayer _profilePlayer;


    public ButtonPauseController(Transform placeForUi, ProfilePlayer profilePlayer)
    {
        _profilePlayer = profilePlayer;
        _view = LoadView(placeForUi);
        _view.Init(ToMainMenu);
    }


    private ButtonPauseView LoadView(Transform placeForUi)
    {
        GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
        GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
        AddGameObject(objectView);

        return objectView.GetComponent<ButtonPauseView>();
    }

    private void ToMainMenu() =>
        _profilePlayer.CurrentState.Value = GameState.Pause;
}