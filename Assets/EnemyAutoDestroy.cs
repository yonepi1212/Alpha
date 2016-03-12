using UnityEngine;
using System.Collections;

public class EnemyAutoDestroy : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
            Destroy(gameObject,13.5f);
    }
}