using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelButton : MonoBehaviour
{
    [SerializeField] private bool _startsUnlocked;
    private Button _button;
    
    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
        
        var isUnlocked = _startsUnlocked || PlayerPrefs.GetInt($"unlocked_{gameObject.name}") != 0;
        _button.interactable = isUnlocked;
        
        if(_startsUnlocked)
            _button.Select();
    }

    public void OnClick()
    {
        SceneManager.LoadScene(gameObject.name);
    }
}
