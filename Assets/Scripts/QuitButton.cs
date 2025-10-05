using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class QuitButton : MonoBehaviour
{
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
#if UNITY_WEBGL
        gameObject.SetActive(false);
#endif
    }

    public static void OnClick()
    {
        Application.Quit();
    }
}
