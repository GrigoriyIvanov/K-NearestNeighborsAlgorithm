using UnityEngine;

namespace Main.KDTree
{
    public class TreeNode
    {
        public Vector2 val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(Vector2 val, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}