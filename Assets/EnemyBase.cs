using UnityEngine;
using System.Collections;

[System.Serializable]
public class EnemyBase : MonoBehaviour
{

	[SerializeField]
	private bool isDemoMove = false;
	[SerializeField]
	public GameManager gameManager;

	public Material bodyMaterial { get; set; }

	public int hp { get; set; }

	public float speed { get; set; }

	public int score = 5;

	public float shotbulletRate = 0.8f;

	private GameObject bullet;

	private float directionY = 180;


	// Use this for initialization
	public virtual void Start ()
	{
		bodyMaterial = gameObject.GetComponent<MeshRenderer> ().materials [0];
		bullet = Resources.Load ("Prefab/EnemyBullet") as GameObject;
		InvokeRepeating ("GenerateBullet", 0f, shotbulletRate);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isDemoMove) {
			DemoMoveUpdate ();
		} else {
			MoveUpdate ();
		}
	}

	public virtual void OnTriggerEnter (Collider target)
	{
		if (target.tag.Equals ("PlayerBullet")) {
			StartCoroutine (FlashBody ());
		}
	}

	private IEnumerator FlashBody ()
	{
		for (int i = 0; i < 2; i++) {
			bodyMaterial.SetFloat ("_MainTexBlend", 0.8f);
			yield return new WaitForSeconds (0.1f);
			bodyMaterial.SetFloat ("_MainTexBlend", 1f);
			yield return new WaitForSeconds (0.1f);
		}

		yield return null;
	}

	public virtual void DemoMoveUpdate ()
	{

	}

	public virtual void MoveUpdate ()
	{

	}

	private void GenerateBullet ()
	{
		GameObject b = Instantiate (bullet) as GameObject;
		b.transform.position = transform.position;

		b.transform.eulerAngles = new Vector3 (0, directionY + Random.Range (-30, 30), 0);
		var bulletBase = b.GetComponent<BulletBase> ();
		bulletBase.speed = Random.Range (0.02f, 0.08f);
		bulletBase.gameManager = gameManager;

	
	}
}
