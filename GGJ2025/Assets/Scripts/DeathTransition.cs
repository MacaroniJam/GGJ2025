using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTransition : MonoBehaviour
{
    public float delayBeforeDeath = 1.8f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DelayedDeath());
        }
    }

    private IEnumerator DelayedDeath()
    {
        yield return new WaitForSeconds(delayBeforeDeath); // Wait before loading scene
        SceneManager.LoadScene("Death");
    }
}

