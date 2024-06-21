using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [SerializeField] int currentHitPoints = 0;

    void OnEnable()
    {
        currentHitPoints = maxHitPoints;    
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();    
    }

    void ProcessHit()
    {
        currentHitPoints--;

        if(currentHitPoints <= 0) 
        {
            gameObject.SetActive(false);
            gameObject.GetComponent<Enemy>().RewardGold();
        }
    }
}
