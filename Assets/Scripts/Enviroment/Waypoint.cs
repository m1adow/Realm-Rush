using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Tower _towerPrefab;
    [SerializeField] private bool _isPlaceable;

    private Transform _parentForTower;
    
    public bool IsPlaceable { get { return _isPlaceable; } }

    private void Start() => _parentForTower = FindObjectOfType<PlayerBuildings>().transform;


    private void OnMouseDown()
    {
        if (_isPlaceable)
            _isPlaceable = !_towerPrefab.CreateTower(_towerPrefab, this.transform.position, _parentForTower);
    }
}
