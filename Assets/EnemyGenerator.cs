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
		InvokeRepeating ("GenerateZako", 0f, 2.5f);
	}

	// Update is called once per frame
	void Update ()
	{
	
	}

	private void GenerateZako ()
	{
		var e = Instantiate (zakoEnemy);
		var randomRange = new Vector3 (Random.Range (-2, 2), 0, Random.Range (-3, 3));
		e.transform.position = transform.position + randomRange;
		EnemyBase enemy = e.GetComponent<EnemyBase> ();
		enemy.gameManager = gameManager;
		enemy.shotbulletRate = Random.Range (0.1f, 0.8f);
	}
}
