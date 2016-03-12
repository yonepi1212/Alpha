using UnityEngine;

public class Common : MonoBehaviour
{

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
    public static StatusManager statusManager;


}
