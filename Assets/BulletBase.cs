using UnityEngine;
using System.Collections;

public class BulletBase : MonoBehaviour
{

	public GameManager gameManager;

	private GameObject hitParticle;

	public float speed = 0.1f;

	public float destroyTime = 1.6f;

	public bool isEnemyBullet = false;

	// Use this for initialization
	void Start ()
	{
		hitParticle = Resources.Load ("Prefab/HitParticle") as GameObject;
		Invoke ("Destroy", destroyTime);
	}
	
	// Update is called once per frame
	void Update ()
	{
		//this.transform.position += new Vector3(0, 0, speed);
		this.transform.Translate (this.transform.forward * -1 * speed);
	}

	void OnTriggerEnter (Collider target)
	{
		if (!isEnemyBullet) {
			if (target.tag.Equals ("Enemy")) {
				var hit = Instantiate (hitParticle);
				hit.transform.SetParent (null, true);
				hit.transform.position = transform.position;
				Destroy ();
			}
		} else {
			// 敵の玉
			if (target.tag.Equals ("Player")) {
				var hit = Instantiate (hitParticle);
				hit.transform.SetParent (null, true);
				hit.transform.position = transform.position;
				gameManager.statusManager.TakeDamage (1);
				Destroy ();
			}
		}
	}


	private void Destroy ()
	{
		Destroy (gameObject);
	}
}
