namespace SnakeGame
{ 
    internal class Node
    {
        private readonly Position nodePos;
        private Node prev;
        private Node next;
        public Node(int x, int y)
        {
            this.nodePos = new Position(x, y);
            prev = null;
            next = null;
        }

        public Node Prev
        {
            get { return prev; }
            set { prev = value; }
        }

        public Node Next
        {
            get { return next; }
            set { next = value; }
        }

        public Position NodePos
        {
            get { return nodePos; }
        }
    }
}
