using UnityEngine;

namespace Main.KDTree
{
    public class KDTreeConstructor
    {
        private TreeNode _root;
        
        public TreeNode CreateTree(Transform[] points)
        {
            _root = new TreeNode(new Vector2(points[0].position.x, points[0].position.z));

            for (int i = 1; i < points.Length; i++)
                Insert(new Vector2(points[i].position.x, points[i].position.z));

            return _root;
        }

        private void Insert(Vector2 position)
        {
            InsertionRecoursion(position, _root, 0);
        }

        private void InsertionRecoursion(Vector2 position, TreeNode temp, int demention)
        {
            if (temp.val[demention] < position[demention])
            {
                if (temp.right != null)
                    InsertionRecoursion(position, temp.right, (demention + 1) % 2);
                else
                    temp.right = new TreeNode(position);
            }
            else
            {
                if (temp.left != null)
                    InsertionRecoursion(position, temp.left, (demention + 1) % 2);
                else
                    temp.left = new TreeNode(position);
            }
        }
    }
}