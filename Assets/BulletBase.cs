using UnityEngine;
using System.Collections;

public class BulletBase : MonoBehaviour {

    public GameManager gameManager;

    private GameObject hitParticle;

    public float speed = 0.1f;

	// Use this for initialization
	void Start () {
        hitParticle = Resources.Load("Prefab/HitParticle") as GameObject;
        Invoke("Destroy",1.6f);
	}
	
	// Update is called once per frame
	void Update () {
        //this.transform.position += new Vector3(0, 0, speed);
        this.transform.Translate(this.transform.forward * -1 * speed);
    }

    void OnTriggerEnter(Collider target)
    {
        if(target.tag.Equals("Enemy"))
        {
            var hit = Instantiate(hitParticle);
            hit.transform.SetParent(null,true);
            hit.transform.position = transform.position;
            Destroy();
        }
    }


    private void Destroy()
    {
        Destroy(gameObject);
    }
}
