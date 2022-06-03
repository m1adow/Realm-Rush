using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _maxHitPoints;

    [Tooltip("Adds amount to maxHitPoints when enemy dies")]
    [SerializeField] private int _diffcultyRamp = 1;

    private Enemy _enemy;
    private int _currentHitPoints = 0;

    private void OnEnable() => _currentHitPoints = _maxHitPoints;

    private void Start() => _enemy = GetComponent<Enemy>();

    private void OnParticleCollision(GameObject other) => ProcessHit();

    private void ProcessHit()
    {
        _currentHitPoints--;

        if (_currentHitPoints <= 0)
        {
            this.gameObject.SetActive(false);
            _maxHitPoints += _diffcultyRamp;
            _enemy.Reward();
        }

    }
}
