using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raven1 : MonoBehaviour
{
    [SerializeField] GameObject fireBall, gun,sound;
    public int damage;
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform close;
    public GameObject enemy;

    private void Start()
    {
        damage = 8;
    }
    private void Update()
    {
        if(FindClosestEnemy() != null)
        close = FindClosestEnemy().transform;
        if (timeBtwAttack >= 0)
        {
            timeBtwAttack -= Time.deltaTime;
        }
        if (Mathf.Abs(FindClosestEnemy().transform.position.x - transform.position.x) < 9f && Mathf.Abs(FindClosestEnemy().transform.position.y - transform.position.y) < 6.5f)
        {
            if (timeBtwAttack <= 0)
            {
                enemy = FindClosestEnemy();
                Instantiate(sound, gun.transform.position, transform.rotation);
                Instantiate(fireBall, gun.transform.position, transform.rotation);
                timeBtwAttack = startTimeBtwAttack;
            }
        }
    }
    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
