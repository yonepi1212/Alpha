using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TitleTextFader : MonoBehaviour {

    [SerializeField]
    Text touchText;

	// Use this for initialization
	void Start () {
        iTween.ValueTo(gameObject, iTween.Hash("from",0.3f,"to",1.5f, "time",0.7f, "loopType",iTween.LoopType.pingPong,"onUpdate","FadeUpdate"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void FadeUpdate(float alpha_)
    {
        touchText.color = new Color(touchText.color.r, touchText.color.g, touchText.color.b, alpha_);
    }
}
