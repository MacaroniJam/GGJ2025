using PrimeTween;
using UnityEngine;
using UnityEngine.InputSystem.Android;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerControl PlayerControl;
    public Image jumpscare;
    public Camera cam;
    private RectTransform rect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rect = jumpscare.GetComponent<RectTransform>();
        jumpscare.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerControl.life <= 0)
        {
            AudioManager.Play("Jumpscare");
            jumpscare.enabled = true;
            Tween.ShakeLocalPosition(rect, new Vector3(200f, 200f, 0f), 2f, 20f);
        }
    }
}
