using System;

namespace 二叉树
{
    internal class Program
    {
        private static void Main()
        {
            var rootNode = BinTree();

            Console.WriteLine("先序遍历方法遍历二叉树： ");
            PreOrde(rootNode);

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("中序遍历方法遍历二叉树：");
            InOrde(rootNode);

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("后序遍历方法遍历二叉树：");
            AfterOrde(rootNode);
            Console.ReadKey();
        }

        /// <summary>
        /// 构建二叉树
        /// </summary>
        /// <returns></returns>
        public static Node<string> BinTree()
        {
            var binTree = new Node<string>[11];
            //创建节点
            binTree[0] = new Node<string>("A");
            binTree[1] = new Node<string>("B");
            binTree[2] = new Node<string>("C");
            binTree[3] = new Node<string>("D");
            binTree[4] = new Node<string>("E");
            binTree[5] = new Node<string>("F");
            binTree[6] = new Node<string>("G");
            binTree[7] = new Node<string>("H");
            binTree[8] = new Node<string>("J");
            binTree[9] = new Node<string>("K");
            binTree[10] = new Node<string>("L");

            //构建关系
            binTree[0].LNode = binTree[1];
            binTree[0].RNode = binTree[2];
            binTree[1].LNode = binTree[3];
            binTree[1].RNode = binTree[4];
            binTree[2].LNode = binTree[6];
            binTree[2].RNode = binTree[7];
            binTree[6].RNode = binTree[8];
            binTree[7].RNode = binTree[9];
            binTree[8].RNode = binTree[10];

            //返回跟节点
            return binTree[0];
        }

        /// <summary>
        /// 先序遍历（先访问跟节点->在访问左孩子->在访问右孩子）递归
        /// 注意的是：遍历左右子树时仍然采用中序遍历方法。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rootNode"></param>
        public static void PreOrde<T>(Node<T> rootNode)
        {
            if (rootNode == null) return;
            Console.Write("{0} ", rootNode.Data);
            PreOrde(rootNode.LNode);
            PreOrde(rootNode.RNode);
        }

        /// <summary>
        /// 中序遍历（先访问左节点->在访问跟节点->在访问右孩子）递归
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rootNode"></param>
        public static void InOrde<T>(Node<T> rootNode)
        {
            if (rootNode == null) return;
            InOrde(rootNode.LNode);
            Console.Write("{0} ", rootNode.Data);
            InOrde(rootNode.RNode);
        }

        /// <summary>
        /// 后序遍历（先访问左节点->在访问右节点->在访问跟孩子）递归
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rootNode"></param>
        public static void AfterOrde<T>(Node<T> rootNode)
        {
            if (rootNode == null) return;
            AfterOrde(rootNode.LNode);
            AfterOrde(rootNode.RNode);
            Console.Write("{0} ", rootNode.Data);
        }
    }

    //节点类
    public class Node<T>
    {
        /// <summary>
        /// 数据
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 左孩子
        /// </summary>
        public Node<T> LNode { get; set; }

        /// <summary>
        /// 右孩子
        /// </summary>
        public Node<T> RNode { get; set; }

        /// <summary>
        /// 节点构造函数
        /// </summary>
        /// <param name="data"></param>
        public Node(T data)
        {
            Data = data;
        }
    }
}