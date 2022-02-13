using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] [Range(0, 5)] float speed = 0.5f;
    [SerializeField] List<Waypoint> path = new List<Waypoint>();

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
            path.Add(child.GetComponent<Waypoint>());
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
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

        gameObject.SetActive(false);
    }
}
