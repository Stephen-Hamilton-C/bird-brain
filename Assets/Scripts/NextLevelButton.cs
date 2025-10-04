using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class NextLevelButton : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    public void NextLevel()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
