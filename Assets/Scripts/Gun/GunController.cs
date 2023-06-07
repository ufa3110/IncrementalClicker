using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine.UIElements;

public class GunController : MonoBehaviour
{
    public GameObject BulletPrefab;
    public int Damage;
    public float AttackRate = 1f;
    public DateTime LastShoot = DateTime.Now;
    public GameObject TargetedEnemy;

    // Start is called before the first frame update
    void Start()
    {
        LastShoot = DateTime.Now;
    }

    private void FixedUpdate()
    {
        TargetedEnemy = FindNearestEnemy();

        if (TargetedEnemy == null && DateTime.Now > LastShoot.AddSeconds(3))
        {
            this.enabled = false;
        }

        if (LastShoot.AddMilliseconds(AttackRate * 1000) < DateTime.Now && TargetedEnemy != null)
        {
            LastShoot = DateTime.Now;
            Shoot();
        }
    }

    public GameObject FindNearestEnemy()
    {
        var enemies = FindObjectsOfType<EnemyController>();

        var closest = enemies.FirstOrDefault();
        if (closest == null) 
        {
            return null;
        }

        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (var enemy in enemies)
        {
            Vector3 diff = enemy.transform.position - position;
            float curDistance = diff.sqrMagnitude;

            if (curDistance < distance)
            {
                closest = enemy;
                distance = curDistance;
            }
        }
        return closest.gameObject;
    }

    private void Shoot()
    {
        Vector3 diff = TargetedEnemy.transform.position - this.transform.position;
        float EnemyDistance = diff.sqrMagnitude;
        if (EnemyDistance > 20)
        {
            return;
        }

        var bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<BulletController>().TargetToEnemy(TargetedEnemy);
        bullet.GetComponent<BulletController>().Damage = Damage;
    }
}
