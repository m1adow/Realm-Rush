using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private GameObject _towerPrefab;
    [SerializeField] private bool _isPlaceable;

    private Transform _parentForTower;

    private void Start() => _parentForTower = FindObjectOfType<PlayerBuildings>().transform;

    public bool IsPlaceable { get { return _isPlaceable; } }

    private void OnMouseDown()
    {
        if (_isPlaceable)
        {
            Instantiate(_towerPrefab, this.transform.position, Quaternion.identity, _parentForTower);

            _isPlaceable = false;
        }

    }
}
