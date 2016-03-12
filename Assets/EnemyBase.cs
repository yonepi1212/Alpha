using UnityEngine;
using System.Collections;

[System.Serializable]
public class EnemyBase : MonoBehaviour {

    [SerializeField]
    private bool isDemoMove = false;
    [SerializeField]
    public GameManager gameManager;

    public Material bodyMaterial { get; set; }

    public int hp { get; set; }

    public float speed { get; set; }

    public int score = 5;

	// Use this for initialization
	public virtual void Start () {
        bodyMaterial = gameObject.GetComponent<MeshRenderer>().materials[0];
	}
	
	// Update is called once per frame
	void Update () {
        if (isDemoMove)
        {
            DemoMoveUpdate();
        }
        else
        {
            MoveUpdate();
        }
    }

    public virtual void OnTriggerEnter(Collider target)
    {
        if (target.tag.Equals("PlayerBullet"))
        {
            StartCoroutine(FlashBody());
        }
    }

    private IEnumerator FlashBody()
    {
        for (int i = 0; i < 2; i++)
        {
            bodyMaterial.SetFloat("_MainTexBlend", 0.8f);
            yield return new WaitForSeconds(0.1f);
            bodyMaterial.SetFloat("_MainTexBlend", 1f);
            yield return new WaitForSeconds(0.1f);
        }

        yield return null;
    }

    public virtual void DemoMoveUpdate()
    {

    }

    public virtual void MoveUpdate()
    {

    }
}
