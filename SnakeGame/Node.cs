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

        public Node Prev // 이전값 프로퍼티
        {
            get { return prev; }
            set { prev = value; }
        }

        public Node Next // 다음값 프로퍼티
        {
            get { return next; }
            set { next = value; }
        }

        public Position NodePos // 위치값 프로퍼티
        {
            get { return nodePos; }
        }
    }
}
