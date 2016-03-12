using UnityEngine;
using System.Collections;

[System.Serializable]
public class StatusManager
{
	public GameManager gameManager;
	public int score;
	public int hp;

	public StatusManager (GameManager gameManager_)
	{
		score = 0;
		hp = 5;
		gameManager = gameManager_;
	}


	public void TakeDamage (int damage_)
	{
		hp -= damage_;
		if (hp < 1) {
			hp = 0;
			gameManager.SetTimeScaleSlow ();
			gameManager.DestroyPlayer ();
		}
	}

	public void AddScore (int score_)
	{
		score += score_;

	}
}
