using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResultPanel : MonoBehaviour {

    public Text scoreText;
    public Text highScoreText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetScore(int score_)
    {
        scoreText.text = "Score\n" + score_;
        // TODO: ハイスコア
        //highScoreText.text = "HighScore\n" + score_;
		SetHighScore ();
    }

	public void SetHighScore()
	{
		highScoreText.text = "HighScore\n" + PlayerPrefs.GetInt("HighScore");
	}

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
