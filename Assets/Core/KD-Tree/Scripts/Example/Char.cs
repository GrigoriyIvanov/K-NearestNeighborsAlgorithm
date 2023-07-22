using UnityEngine;

namespace Main.KDTree.Example
{
    public class Char : MonoBehaviour
    {
        [SerializeField] private int _speed;

        [SerializeField] private Example _example;

        [SerializeField, HideInInspector] private LineRenderer _line;

        private KDTreeSearch _kdTree;
        private Vector3 _destinationPoint;

        private void Start()
        {
            _destinationPoint = transform.position;
            _kdTree = _example.Tree;
        }

        private void FixedUpdate()
        {
            UpdateNearestPosition();

            Move();
        }

        private void UpdateNearestPosition()
        {
            var nearestpoint = _kdTree.SearchNearestNeighbour(new Vector2(transform.position.x, transform.position.z));

            _line.SetPosition(0, transform.position);
            _line.SetPosition(1, new Vector3(nearestpoint.val.x, transform.position.y, nearestpoint.val.y));
        }

        private void Move()
        {
            if (Vector3.Distance(_destinationPoint, transform.position) < 0.1f)
            {
                _destinationPoint = new Vector3(
                                        Random.Range(-70, 70),
                                        0,
                                        Random.Range(-70, 70));
            }

            transform.position = Vector3.MoveTowards(
                                    transform.position,
                                    _destinationPoint,
                                    Time.fixedDeltaTime * _speed);
        }

        private void OnValidate()
        {
            if (_line == null) _line = GetComponentInChildren<LineRenderer>();
        }
    }
}