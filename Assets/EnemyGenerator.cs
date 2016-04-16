using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour
{

	[SerializeField]
	public GameManager gameManager;

	private GameObject zakoEnemy;

	// Use this for initialization
	void Start ()
	{
		zakoEnemy = Resources.Load ("Prefab/ZakoEnemy01") as GameObject;
		//InvokeRepeating ("GenerateZako", 0f, 2.5f);
	}

	// Update is called once per frame
	void Update ()
	{

	}

	public void GenerateZako ()
	{
		var e = Instantiate (zakoEnemy);
		var randomRange = new Vector3 (Random.Range (-2f, 2f), 0f, Random.Range (0f, 7f));
		e.transform.position = transform.position + randomRange;
		EnemyBase enemy = e.GetComponent<EnemyBase> ();
		enemy.gameManager = gameManager;
		enemy.shotbulletRate = Random.Range (0.1f, 0.8f);
		enemy.score = 100;
	}
}
