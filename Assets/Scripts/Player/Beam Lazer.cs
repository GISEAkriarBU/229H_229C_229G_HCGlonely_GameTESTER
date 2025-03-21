using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamLazer : _Weapon
{
    public float delayTime;
    public override void OnHitWith(Entity enemy) //polymorph
    {
        if (enemy is Enemy)
        {
            enemy.TakeDamage(this.Damage);
            if (delayTime > 20) { Destroy(this.gameObject); }
        }
        else if (delayTime > 60) { Destroy(this.gameObject); }
    }


    private void FixedUpdate()
    {

        delayTime += Time.deltaTime;
        Move();
    }

    public override void Move()//polymorph
    {

        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddTorque(Vector3.forward * 10f); // Adjust the force as needed
        }
    }
    
}
