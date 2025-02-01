using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathUI : MonoBehaviour {
    public void OnRetryClick() {
        SceneManager.LoadScene("Game");
    }
    public void OnQuitClick() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();


    }

}
