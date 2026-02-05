using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxhitPoints=5;

    [Tooltip("Adds amount to maxhitPoints when enemy dies.")]
    [SerializeField] int difficultyRamp=1;
    [SerializeField] int currentHealthPoints =0;
    Enemy enemy;

   
    void OnEnable()
    {
        currentHealthPoints= maxhitPoints;
    }
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    
    void OnParticleCollision(GameObject other) 
    {
        ProcessHit();
    }
    void ProcessHit()
    {
        currentHealthPoints--;
        if(currentHealthPoints <= 0)
        {
            gameObject.SetActive(false);
            maxhitPoints+= difficultyRamp;
            enemy.RewardGold();
        }
    }
}
