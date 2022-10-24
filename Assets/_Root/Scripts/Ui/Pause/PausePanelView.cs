using UnityEngine;
using UnityEngine.UI;

internal class PausePanelView : MonoBehaviour
{
    [field: SerializeField] public Button ContinueGameButton { get; private set; }
    [field: SerializeField] public Button ToMenuButton { get; private set; }
}
