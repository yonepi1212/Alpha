using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    [SerializeField]
    private GameManager gameManager;

    public ResultPanel resultPanel;

    public Text scoreText;
    public Text lifeText;

	// Use this for initialization
	void Start () {
        Initialization();
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = gameManager.StatusManager.score.ToString();
       lifeText.text = gameManager.StatusManager.hp.ToString();
    }

    private void Initialization()
    {
        scoreText.text = gameManager.StatusManager.score.ToString();
        lifeText.text = gameManager.StatusManager.hp.ToString();
    }

    public void ShowResultScore(int score_)
    {
        resultPanel.SetScore(score_);
        resultPanel.Show();
    }
}
