using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour {
    public TMP_Text scoretext;
    private int score = 0;





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        scoretext.text = "score " + score;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "ScoreTrigger") {
            score++;
        }
    }


}