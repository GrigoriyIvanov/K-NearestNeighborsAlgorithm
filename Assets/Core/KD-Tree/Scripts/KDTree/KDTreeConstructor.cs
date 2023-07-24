using UnityEngine;

namespace Main.KDTree
{
    public class KDTreeConstructor
    {
        private TreeNode _root;
        
        public TreeNode CreateTree(Transform[] points)
        {
            _root = new TreeNode(points[0].position);

            for (int i = 1; i < points.Length; i++)
                Insert(points[i].position);

            return _root;
        }

        private void Insert(Vector3 position) => InsertionRecoursion(position, _root, 0);

        private void InsertionRecoursion(Vector3 position, TreeNode temp, int demention)
        {
            if (temp.val[demention] < position[demention])
            {
                if (temp.right != null)
                    InsertionRecoursion(position, temp.right, ++demention % 3);
                else
                    temp.right = new TreeNode(position);
            }
            else
            {
                if (temp.left != null)
                    InsertionRecoursion(position, temp.left, ++demention % 3);
                else
                    temp.left = new TreeNode(position);
            }
        }
    }
}