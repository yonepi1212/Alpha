using UnityEngine;
using System.Collections;

public class GameSceneBackButton : MonoBehaviour {

    public void OnClick()
    {
        Invoke("Invoke", 0.2f);
    }

    private void Invoke()
    {
        Application.LoadLevel("Title");
    }
}
