namespace SnakeGame
{     
    internal class MyList
    {
        private Node head;
        private Node tail;
        private int count;

        public MyList(int x, int y)
        {
            head = null;
            tail = null;
            count = 0;
            AddFront(x, y);
        }
        public void AddFront(int x, int y)
        {
            Node temp = new Node(x, y);
            if(head == null)
            {
                head = tail = temp;
            }
            else
            {
                temp.setNext(head);
                head.setPrev(temp);
                head = temp;
            }
            count++;
        }

        public void DeleteBack()
        { 
            if(tail == null)
            {
                return;
            }
            else
            {
                Node temp = tail;
                if (head == tail)
                {
                    head = tail = null;
                }
                else
                {
                    tail = tail.getPrev();
                    temp.setPrev(null);
                    tail.setNext(null);
                }
                count--;
            }
        }
        public Position[] GetPositions()
        {
            Position[] positions = new Position[count];
            Node cursor = head;
            int cnt = 0;

            while(cursor != null)
            {
                positions[cnt++] = cursor.getPosition();
                cursor = cursor.getNext();
            }
            return positions;
        }
    }
}
