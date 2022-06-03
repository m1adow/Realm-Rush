using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] [Range(0f, 5f)] private float _speed;

    private List<Waypoint> _path = new();
    private Enemy _enemy;

    private void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    private void Start() => _enemy = GetComponent<Enemy>();

    private void FindPath()
    {
        _path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        foreach (Transform child in parent.transform)
        {
            Waypoint waypoint = child.GetComponent<Waypoint>();

            if (waypoint is not null)
                _path.Add(waypoint);
        }
    }

    private void ReturnToStart() => this.transform.position = _path[0].transform.position;

    private IEnumerator FollowPath()
    {
        foreach (var waypoint in _path)
        {
            Vector3 startPosition = this.transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            this.transform.LookAt(endPosition);

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * _speed;
                this.transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }

        _enemy.Steal();
        this.gameObject.SetActive(false);
    }
}
