using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

	public StatusManager StatusManager {
		get {
			if (statusManager == null) {
				return new StatusManager (this);
			} else {
				return statusManager;
			}
		}
	}

	public StatusManager statusManager;

	public Player player;

	// Use this for initialization
	void Start ()
	{
		statusManager.gameManager = this;
		SetTimeScaleNormal ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void SetTimeScaleSlow ()
	{
		Time.timeScale = 0.05f;
	}

	public void SetTimeScaleNormal ()
	{
		Time.timeScale = 1f;
	}

	public void SetPlayerActive (bool isActive_)
	{
		player.gameObject.SetActive (isActive_);
	}

	public void DestroyPlayer ()
	{
		Destroy (player.gameObject);
	}


}
