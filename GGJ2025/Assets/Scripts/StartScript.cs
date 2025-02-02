using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    [SerializeField] AudioSource sfx;

    public AudioClip sfxClip;
   
    public void OnStartClick()
    {
        sfx.clip = sfxClip;
        sfx.Play();
        StartCoroutine(LoadSceneAfterSound());

    }

    private System.Collections.IEnumerator LoadSceneAfterSound()
    {
        yield return new WaitForSeconds(sfxClip.length); // Wait for the sound to finish
        SceneManager.LoadScene("Game");
    }

  
    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();

    }

}