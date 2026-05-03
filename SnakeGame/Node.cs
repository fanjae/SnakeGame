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
        public void setPrev(Node node) // 이전 위치 설정
        {
            this.prev = node;
        }
        public void setNext(Node node) // 다음 위치 설정
        {
            this.next = node;
        }
        public Node getPrev() // 이전값 반환
        {
            return prev;
        }
        public Node getNext() // 다음값 반환
        {
            return next;
        }
        public Position getPosition() // 위치값 반환
        {
            return value;
        }
    }
}
