using System;
using System.Threading;
using LightR.Common;
using Magnum.Extensions;

namespace LightR.TestFramework
{
    /// <summary>
    /// A future object that supports both callbacks and asynchronous waits once a future value becomes available.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Future<T> :
        IAsyncResult
    {
        readonly AsyncCallback _callback;
        readonly ManualResetEvent _event;
        readonly object _state;
        volatile bool _completed;

        public Future()
            : this(NullCallback, 0)
        {
        }

        public Future(AsyncCallback callback, object state)
        {
            Guard.AgainstNull(callback, "callback");

            _callback = callback;
            _state = state;

            _event = new ManualResetEvent(false);
        }

        public T Value { get; private set; }

        public bool IsCompleted
        {
            get { return _completed; }
        }

        public WaitHandle AsyncWaitHandle
        {
            get { return _event; }
        }

        public object AsyncState
        {
            get { return _state; }
        }

        public bool CompletedSynchronously
        {
            get { return false; }
        }

        public void Complete(T message)
        {
            if (_completed)
            {
                throw new InvalidOperationException("A Future cannot be completed twice, value = {0}, passed = {1}".FormatWith(Value, message));
            }

            Value = message;

            _completed = true;

            _event.Set();

            _callback(this);
        }

        public bool WaitUntilCompleted(TimeSpan timeout)
        {
            return _event.WaitOne(timeout);
        }

        public bool WaitUntilCompleted(int timeout)
        {
            return _event.WaitOne(timeout);
        }

        ~Future()
        {
            _event.Close();
        }

        static void NullCallback(object state)
        {
        }
    }
}