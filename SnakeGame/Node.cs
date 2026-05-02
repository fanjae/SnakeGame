namespace SnakeGame
{ 
    internal class Node
    {
        private Position value;
        Node prev;
        Node next;
        public Node(int x, int y)
        {
            this.value = new Position(x, y);
            prev = null;
            next = null;
        }
        public void setPrev(Node node)
        {
            this.prev = node;
        }
        public void setNext(Node node)
        {
            this.next = node;
        }
        public Node getPrev()
        {
            return prev;
        }
        public Node getNext()
        {
            return next;
        }
        public Position getPosition()
        {
            return value;
        }
    }
}
