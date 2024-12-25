using System.Collections;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    [SerializeField] private Bullet _prefabBullet;
    [SerializeField] private Transform _shotPosition;
    [SerializeField] private float _timeWaitShooting;

    private WaitForSeconds _waitSeconds;

    private void Awake()
    {
        _waitSeconds = new WaitForSeconds(_timeWaitShooting);
    }

    void Start()
    {
        StartCoroutine(Shot());
    }

    private IEnumerator Shot()
    {
        while (enabled)
        {
            Vector3 direction = transform.position + (_shotPosition.position - transform.position).normalized;
            Bullet bullet = Instantiate(_prefabBullet,direction, Quaternion.identity);
            bullet.SetDirection(direction);

            yield return _waitSeconds;
        }
    }
}