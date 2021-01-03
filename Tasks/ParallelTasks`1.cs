// Decompiled with JetBrains decompiler
// Type: Tasks.ParallelTasks`1
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System.Collections.Generic;
using System.Threading;
using Utils;

namespace Tasks
{
    public class ParallelTasks<T>
    {
        private string sessionId;
        private List<T> requests;
        private List<ManualResetEvent> doneEvents;

        public List<T> Requests => this.requests;

        public ParallelTasks(string sessionId)
        {
            this.sessionId = sessionId;
            this.requests = new List<T>();
            this.doneEvents = new List<ManualResetEvent>();
        }

        public ParallelTasks<T> QueueRequest(
          T request,
          ManualResetEvent doneEvent,
          WaitCallback callback)
        {
            this.requests.Add(request);
            this.doneEvents.Add(doneEvent);
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.InternalCallback), (object)callback);
            return this;
        }

        private void InternalCallback(object state)
        {
            Sessions.AddChildThread(this.sessionId);
            try
            {
                ((WaitCallback)state)((object)null);
            }
            finally
            {
                Sessions.RemoveChildThread(this.sessionId);
            }
        }

        public bool WaitAllRequests() => this.doneEvents.Count != 0 && WaitHandle.WaitAll((WaitHandle[])this.doneEvents.ToArray());
    }
}
