using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyLocator : MonoBehaviour
{
    [SerializeField] ParticleSystem bolts;
    [SerializeField] Transform weapon;
    [SerializeField] float maxRange = 1f;
    Transform target;
    void Start()
    {
        target = FindObjectOfType<Enemy>().GetComponent<Transform>();
    }

    void Update()
    {
        FindNearestEnemy();
        Aim();
    }

    void FindNearestEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestEnemy = null;
        float maxDistance = Mathf.Infinity;

        foreach(Enemy enemy in enemies) 
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance < maxDistance)
            {
                closestEnemy = enemy.transform;
                maxDistance = targetDistance;
            }
        }
        target= closestEnemy;
    }

    void Aim()
    {
        float targetDistance=Vector3.Distance(transform.position, target.position);
        weapon.LookAt(target);

        if (targetDistance < maxRange)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }

    }

    void Attack(bool isActive)
    {
        var emissionModule = bolts.emission;
        emissionModule.enabled= isActive;
    }

}
