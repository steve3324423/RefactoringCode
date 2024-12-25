using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _allPlacesPoint;

    private Transform[] _arrayPlaces;
    private int _indexPlaces;
    
    private void Update()
    {
        SetPlace();
    }

    private void SetPlace()
    {
        Vector3 currentPlace = _arrayPlaces[_indexPlaces].position;
        Vector3 offset = transform.position - currentPlace;
        float minDistance = .1f;

        if (offset.sqrMagnitude < minDistance * minDistance)
            IncreaseIndex();
        else
            transform.position = Vector3.MoveTowards(transform.position, currentPlace, _speed * Time.deltaTime);
    }

    private void IncreaseIndex()
    {
        _indexPlaces++;

        if (_indexPlaces >= _arrayPlaces.Length - 1)
            _indexPlaces = 0;
    }
}