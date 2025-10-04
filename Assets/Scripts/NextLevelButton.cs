using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class NextLevelButton : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ButtonClicked);
    }

    private void ButtonClicked()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
