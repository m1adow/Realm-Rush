using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _maxHitPoints;

    private int _currentHitPoints = 0;

    private void OnEnable() => _currentHitPoints = _maxHitPoints;

    private void OnParticleCollision(GameObject other) => ProcessHit();

    private void ProcessHit()
    {
        _currentHitPoints--;

        if (_currentHitPoints <= 0) 
            this.gameObject.SetActive(false);
    }
}
