using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;

    void OnEnable()
    {
        FindPath();
        GoToStart();
        StartCoroutine(FollowPath());
    }

    void FindPath()
    {
        path.Clear();   

        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        foreach (Transform child in parent.transform)
        {
            Waypoint waypoint=child.GetComponent<Waypoint>();
            if(waypoint != null) {
                path.Add(waypoint);
            }               
        }

    }

    void GoToStart()
    {
        transform.position = path[0].transform.position;
    }
    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float percent = 0f;

            transform.LookAt(endPosition);

            while (percent < 1f)
            {
                percent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, percent);
                yield return new WaitForEndOfFrame();
            }
        }
        FinishPath();
    }

    public void FinishPath()
    {
        gameObject.SetActive(false);
        gameObject.GetComponent<Enemy>().StealGold();
    }
}
