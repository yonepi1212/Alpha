using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private bool isDemoMove = false;

    private GameObject bullet01;
    private GameObject bullet02;


    // Use this for initialization
    void Start () {
        bullet01 = Resources.Load("Prefab/Bullet") as GameObject;
        bullet02 = Resources.Load("Prefab/Bullet02") as GameObject;
        InvokeRepeating("GenerateBullet", 0f,0.12f);
        InvokeRepeating("GenerateBullet02", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update () {
        if(isDemoMove)
        {
            DemoMoveUpdate();
        }
    }

    private void GenerateBullet()
    {
        var b = Instantiate(bullet01);
        b.transform.position = transform.position;

        var b2 = Instantiate(bullet01);
        b2.transform.position = transform.position;
        b2.transform.eulerAngles = new Vector3(90, -15, 0);
        b2.GetComponent<BulletBase>().gameManager = gameManager;


        var b3 = Instantiate(bullet01);
        b3.transform.position = transform.position;
        b3.transform.eulerAngles = new Vector3(90, 15, 0);
        b3.GetComponent<BulletBase>().gameManager = gameManager;

    }

    private void GenerateBullet02()
    {

        var b4 = Instantiate(bullet02);
        b4.transform.position = transform.position + new Vector3(-0.3f, 0, 0.2f);
        b4.transform.eulerAngles = new Vector3(90, 0, 0);
        b4.GetComponent<BulletBase>().gameManager = gameManager;
        b4.GetComponent<BulletBase>().speed = 0.3f;

        var b5 = Instantiate(bullet02);
        b5.transform.position = transform.position + new Vector3(0.3f, 0, 0.2f);
        b5.transform.eulerAngles = new Vector3(90, 0, 0);
        b5.GetComponent<BulletBase>().gameManager = gameManager;
        b5.GetComponent<BulletBase>().speed = 0.3f;
    }

    private void DemoMoveUpdate()
    {
        Vector3 pos = Vector3.zero;
        pos.z = -2.0f;
        pos.x += Mathf.Cos(Time.time * 1.5f) * 1.5f;
        transform.position = pos;
    }
}
