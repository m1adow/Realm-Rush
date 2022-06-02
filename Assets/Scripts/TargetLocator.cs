using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] private Transform _weapon;
    [SerializeField] private float _range = 15f;

    private ParticleSystem _projectileParticles;
    private Transform _target;

    private void Start() => _projectileParticles = GetComponentInChildren<ParticleSystem>();

    private void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    private void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (var enemy in enemies)
        {
            float targetDistance = Vector3.Distance(this.transform.position, enemy.transform.position);

            if (targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }               
        }

        _target = closestTarget;
    }

    private void AimWeapon()
    {      
        float targetDistance = Vector3.Distance(this.transform.position, _target.position);

        if (targetDistance > _range)
        {
            Attack(false);
            return;
        }

        _weapon.LookAt(_target);
        Attack(true);
    }

    private void Attack(bool isActive)
    {
        var emmisionModule = _projectileParticles.emission;

        emmisionModule.enabled = isActive;
    }
}
