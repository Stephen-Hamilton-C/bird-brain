using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class NextLevelButton : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    [SerializeField] private bool _selectOnStart;
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(NextLevel);
        PlayerPrefs.SetInt($"unlocked_{_sceneName}", 1);
        PlayerPrefs.Save();

        if (_selectOnStart)
            _button.Select();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
