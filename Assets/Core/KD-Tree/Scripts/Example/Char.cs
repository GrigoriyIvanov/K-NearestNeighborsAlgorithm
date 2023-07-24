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

            nearestpointVal = new Vector3[1];
        }

        private void FixedUpdate()
        {
            UpdateNearestPosition();

            Move();
        }
        public Vector3[] nearestpointVal;
        private void UpdateNearestPosition()
        {
            var nearestpoint = _kdTree.SearchNearestNeighbour(transform.position, 1);
            
            if (nearestpoint == null)
                return;

            nearestpointVal[0] = nearestpoint.val;
            //Debug.DrawLine(transform.position, nearestpoint.val, Color.red, Time.fixedDeltaTime);
            //for (int i = 0; i < nearestpoint.Length; i++)
            //{
            //    nearestpointVal[i] = nearestpoint[i].val;

            //    Debug.DrawLine(transform.position, nearestpoint[i].val, Color.red, Time.fixedDeltaTime);

            //}
            _line.SetPosition(0, transform.position);
            _line.SetPosition(1, nearestpoint.val);
        }

        private void Move()
        {
            if (Vector3.Distance(_destinationPoint, transform.position) < 0.1f)
            {
                _destinationPoint = new Vector3(
                                        Random.Range(-70, 70),
                                        Random.Range(-70, 70),
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