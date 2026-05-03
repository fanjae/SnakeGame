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
        public void AddFront(int x, int y) // 앞 데이터 추가
        {
            Node temp = new Node(x, y);
            if(head == null) // 첫번째 데이터였으면, head,tail 모두 동일
            {
                head = tail = temp;
            }
            else
            {
                temp.setNext(head); // 기존 head값은 신규 데이터의 next가 됨.
                head.setPrev(temp); // 기존 head의 이전 값은 신규 데이터가 됨. 
                head = temp; // head 교체
            }
            count++;
        }

        public void DeleteBack() // 끝 값 삭제
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
                    tail = tail.getPrev(); // tail을 이전 값으로 대체
                    temp.setPrev(null);
                    tail.setNext(null);
                }
                count--;
            }
        }
        public Position GetHeadPosition() // 헤드값 좌표 위치 반환
        {
            return head.getPosition();
        }

        public Position[] GetPositions() // 좌표 값 목록 전체 가져오기
        {
            if(count == 0)
            {
                return null;
            }
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
