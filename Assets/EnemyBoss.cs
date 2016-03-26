using UnityEngine;
using System.Collections;

public class EnemyBoss : EnemyBase {

    public override void Start()
    {
        base.Start();
        base.hp = 300;
        base.score = 500;
    }

    public override void OnTriggerEnter(Collider target)
    {
        base.OnTriggerEnter(target);
        if (target.tag.Equals("PlayerBullet"))
        {
            base.hp--;
            if (base.hp < 1)
            {
                Destroy(gameObject);
            }
        }
    }

    public override void DemoMoveUpdate()
    {
        Vector3 pos = Vector3.zero;
        pos.z += 2;
        pos.z += Mathf.Sin(Time.time * 0.8f) * 1.2f;
        pos.x += Mathf.Cos(Time.time * 1.0f) * 1.5f;
        transform.position = pos;
    }
}
