using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] [Range(0, 5)] float speed = 0.5f;
    [SerializeField] List<Waypoint> path = new List<Waypoint>();

    Enemy enemy;

    void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    void FindPath()
    {
        //Clear out path first
        path.Clear();
        
        //Find the path object and loop through each child tile and add to list
        GameObject parent = GameObject.FindGameObjectWithTag("Path");
        foreach (Transform child in parent.transform)
        {
            Waypoint waypoint = child.GetComponent<Waypoint>();
            if (waypoint != null)
            {
                path.Add(waypoint);
            }
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    void FinishPath()
    {
        //These lines happen if the enemy reaches the end of the path
        enemy.StealMoney();
        gameObject.SetActive(false);
    }

    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 nextPosition = waypoint.transform.position;
            float travelPercentage = 0f;

            transform.LookAt(nextPosition);
            
            while (travelPercentage < 1)
            {
                travelPercentage += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, nextPosition, travelPercentage);
                yield return new WaitForEndOfFrame();
            }
        }
        
        FinishPath();
    }
}
