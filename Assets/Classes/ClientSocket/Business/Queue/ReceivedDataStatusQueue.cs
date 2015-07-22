using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ClientSocket.Business
{
    public class ReceivedDataStatusQueue
    {
        private static ReceivedDataStatusQueue _instance = null;
        private Queue _queue = null;

        public static ReceivedDataStatusQueue shareInstance()
        {
            if (null == _instance)
            {
                _instance = new ReceivedDataStatusQueue();
            }
            return _instance;
        }

        private ReceivedDataStatusQueue()
        {
            _queue = new Queue();
        }

        public int getSize()
        {
            return _queue.Count;
        }

        public int getStatus()
        {
            return (int)_queue.Peek();
        }

        public void addStatus(int socketConst)
        {
            lock (_queue)
            {
                _queue.Enqueue(socketConst);
            }
        }

        public void removeStatus()
        {
            lock (_queue)
            {
                if (_queue.Count > 0)
                {
                    _queue.Dequeue();
                }
            }
        }

        public void clear()
        {
            lock (_queue)
            {
                if (_queue.Count > 0)
                {
                    _queue.Clear();
                }
            }
        }
    }
}
