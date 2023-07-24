using UnityEngine;

namespace Main.KDTree
{
    public class TreeNode
    {
        public Vector3 val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(Vector3 val, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}