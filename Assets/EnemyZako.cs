using UnityEngine;
using System.Collections;

public class EnemyZako : EnemyBase {

    public override void Start()
    {
        base.Start();
        hp = 15;
        speed = Random.Range(0.4f, 1.2f);
    }

    public override void MoveUpdate()
    {
        Vector3 pos = transform.position;
        pos.z -= Time.deltaTime * speed * 1;
        transform.position = pos;
    }

    public override void DemoMoveUpdate()
    {
        Vector3 pos = Vector3.zero;
        pos.z += 2;
        pos.z += Mathf.Sin(Time.time * 1.5f) * 1.5f;
        pos.x += Mathf.Cos(Time.time * .7f) * 1.5f;
        transform.position = pos;
    }

    public override void OnTriggerEnter(Collider target)
    {
        base.OnTriggerEnter(target);
        if (target.tag.Equals("PlayerBullet"))
        {
            base.hp--;
            if(base.hp < 1)
            {
                Destroy(gameObject);
                gameManager.StatusManager.score += score;
            }
        }
    }
}
