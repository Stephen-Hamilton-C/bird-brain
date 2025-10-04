using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelCompleteText : MonoBehaviour
{
    private void Start()
    {
        var text = GetComponent<TMP_Text>();
        text.text = string.Format(text.text, SceneManager.GetActiveScene().name);
    }
}
