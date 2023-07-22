using UnityEngine;

namespace Main.KDTree.Example
{
    public class Example : MonoBehaviour
    {
        [SerializeField] private Transform[] _points;
        [SerializeField] private Char[] _chars;

        private KDTreeSearch _kdTree;
        private KDTreeConstructor _treeConstructor;

        public KDTreeSearch Tree => _kdTree;

        private void Awake()
        {
            _treeConstructor = new KDTreeConstructor();
            _kdTree = new KDTreeSearch();
        }

        private void FixedUpdate()
        {
            var root = _treeConstructor.CreateTree(_points);
            _kdTree.UpdateRoot(root);
        }
    }
}