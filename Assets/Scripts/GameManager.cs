using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public StatusManager StatusManager
    {
        get
        {
            if (statusManager == null)
            {
                return new StatusManager();
            }
            else
            {
                return statusManager;
            }
        }
    }
    public StatusManager statusManager;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
