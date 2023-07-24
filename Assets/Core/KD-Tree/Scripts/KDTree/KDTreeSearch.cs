using UnityEngine;

namespace Main.KDTree
{
    public class KDTreeSearch
    {
        private TreeNode _root;

        TreeNode[] _answer;

        //public TreeNode[] SearchNearestNeighbour(Vector3 value, int k)
        //{
        //    _answer = new TreeNode[k];
        //    SearchNearestNeighbourRecoursion(_root, value, 0);
        //    return _answer;
        //}
        public TreeNode SearchNearestNeighbour(Vector3 value, int k) => SearchNearestNeighbourRecoursion(_root, value, 0);

        public void UpdateRoot(TreeNode root) => _root = root;

        private TreeNode SearchNearestNeighbourRecoursion(TreeNode temp, Vector3 value, int demention)
        {
            if (temp == null)
                return null;

            TreeNode nextNode = null;
            TreeNode otherNode = null;

            if (value[demention] < temp.val[demention])
            {
                nextNode = temp.left;
                otherNode = temp.right;
            }
            else
            {
                nextNode = temp.right;
                otherNode = temp.left;
            }

            TreeNode tempRes = SearchNearestNeighbourRecoursion(nextNode, value, (demention + 1) % 3);

            TreeNode nearestNode = Closest(temp, tempRes, value);

            //IterateTroughAnswer(nearestNode, value);

            float radiusSquared = DistanceSquared(value, nearestNode.val);

            float dist = Mathf.Abs(value[demention] - temp.val[demention]);

            if (radiusSquared >= dist * dist)
            {
                tempRes = SearchNearestNeighbourRecoursion(otherNode, value, (demention + 1) % 3);
                nearestNode = Closest(tempRes, nearestNode, value);
            }

            //IterateTroughAnswer(nearestNode, value);

            return nearestNode;
        }

        private TreeNode Closest(TreeNode n0, TreeNode n1, Vector3 target)
        {
            if (n0 == null) return n1;

            if (n1 == null) return n0;

            float d1 = Vector3.Distance(n0.val, target);
            float d2 = Vector3.Distance(n1.val, target);

            if (d1 < d2)
                return (n0.val == target) ? n1 : n0;
            else
                return (n1.val == target) ? n0 : n1;
        }

        private float DistanceSquared(Vector3 p0, Vector3 p1)
        {
            float total = 0;

            for (int i = 0; i < 3; i++)
            {
                float diff = Mathf.Abs(p0[i] - p1[i]);
                total += Mathf.Pow(diff, 2);
            }
            return total;
        }

        //private void IterateTroughAnswer(TreeNode temp, Vector3 target)
        //{
        //    for (int i = _answer.Length - 1; i >= 0; i--)
        //    {
        //        if (_answer[i] == null)
        //        {
        //            _answer[i] = temp;
        //            return;
        //        }

        //        TreeNode newClosest = Closest(_answer[i], temp, target);

        //        if (newClosest != _answer[i])
        //        {
        //            for (int j = i; j >= 0; j--)
        //            {
        //                TreeNode f = _answer[j];
        //                _answer[j] = newClosest;
        //                newClosest = f;
        //            }

        //            return;
        //        }
        //    }
        //}
    }
}