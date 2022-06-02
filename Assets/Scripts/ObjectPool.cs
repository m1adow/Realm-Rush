using System.Collections;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private int _poolSize = 5;
    [SerializeField] private float _spawnTimer = 1f;

    private GameObject[] _pool;

    private void Awake() => PopulatePool();

    private void Start() => StartCoroutine(EnemyInstantianting());
    
    private void PopulatePool()
    {
        _pool = new GameObject[_poolSize];

        for (int i = 0; i < _pool.Length; i++)
        {
            _pool[i] = Instantiate(_enemyPrefab, this.transform.position, Quaternion.identity, this.transform);
            _pool[i].SetActive(false);
        }
           
    }

    private IEnumerator EnemyInstantianting()
    {
        while (true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(_spawnTimer);
        }
    }

    private void EnableObjectInPool() 
    {
        for (int i = 0; i < _pool.Length; i++)
            if (!_pool[i].activeInHierarchy)
            {
                _pool[i].SetActive(true);
                return;
            }
    }
}
