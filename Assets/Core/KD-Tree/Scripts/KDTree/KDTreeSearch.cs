using UnityEngine;

namespace Main.KDTree
{
    public class KDTreeSearch
    {
        private TreeNode _root;

        public TreeNode SearchNearestNeighbour(Vector2 value) => SearchNearestNeighbourRecoursion(_root, value, 0);

        public void UpdateRoot(TreeNode root) => _root = root;

        private TreeNode SearchNearestNeighbourRecoursion(TreeNode temp, Vector2 value, int demention)
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

            TreeNode tempRes = SearchNearestNeighbourRecoursion(nextNode, value, (demention + 1) % 2);

            TreeNode nearestNode = Closest(temp, tempRes, value);

            float radiusSquared = DistanceSquared(value, nearestNode.val);

            float dist = Mathf.Abs(value[demention] - temp.val[demention]);

            if (radiusSquared >= dist * dist)
            {
                tempRes = SearchNearestNeighbourRecoursion(otherNode, value, (demention + 1) % 2);
                nearestNode = Closest(tempRes, nearestNode, value);
            }

            return nearestNode;
        }

        private TreeNode Closest(TreeNode n0, TreeNode n1, Vector2 target)
        {
            if (n0 == null) return n1;

            if (n1 == null) return n0;

            float d1 = Vector2.Distance(n0.val, target);
            float d2 = Vector2.Distance(n1.val, target);

            if (d1 < d2)
                return (n0.val == target) ? n1 : n0;
            else
                return (n1.val == target) ? n0 : n1;
        }

        private float DistanceSquared(Vector2 p0, Vector2 p1)
        {
            float total = 0;

            for (int i = 0; i < 2; i++)
            {
                float diff = Mathf.Abs(p0[i] - p1[i]);
                total += Mathf.Pow(diff, 2);
            }
            return total;
        }
    }
}