using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class Path2mover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path2 = new List<Waypoint>();
    [SerializeField] [Range(0f,5f)]float speed =1f;
     Enemy enemy;

    void OnEnable()
    {
        FindPath2();
        ReturnToStart2();
        StartCoroutine(FallowPath2());
        
        
    }
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    void FindPath2()
    {
        path2.Clear();
        GameObject parent = GameObject.FindGameObjectWithTag("Path2");

        foreach(Transform child in parent.transform)
        {
            Waypoint waypoint = child.GetComponent<Waypoint>();
            if(waypoint != null)
            {
                path2.Add(waypoint);
            }
           
        }
    }
    
    void ReturnToStart2()
    {
        transform.position = path2[0].transform.position;
        
    }
    void FinishPath2()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }
    IEnumerator FallowPath2()
    {
        foreach(Waypoint waypoint in path2)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position= Vector3.Lerp(startPosition,endPosition,travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        
        FinishPath2();

    }
}
