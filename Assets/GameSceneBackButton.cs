using UnityEngine;
using System.Collections;

public class GameSceneBackButton : MonoBehaviour
{

	public void OnClick ()
	{
		Time.timeScale = 1.0f;
		Invoke ("Invoke", 0.2f);
	}

	private void Invoke ()
	{
		Application.LoadLevel ("Title");
	}
}
