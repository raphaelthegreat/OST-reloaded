// Decompiled with JetBrains decompiler
// Type: Utils.MutexLock
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System;
using System.Threading;

namespace Utils
{
    internal class MutexLock
    {
        private Mutex mutex;
        private string mutexName;

        public string Name => this.mutexName;

        public MutexLock(string name) => this.mutexName = name;

        public bool Create(bool initialOwned)
        {
            try
            {
                this.mutex = new Mutex(initialOwned, this.mutexName);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool WaitExit(int timeout)
        {
            try
            {
                if (!this.mutex.WaitOne(timeout))
                    return false;
                this.mutex.ReleaseMutex();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool OpenExisting()
        {
            try
            {
                this.mutex = Mutex.OpenExisting(this.mutexName);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void Release()
        {
            try
            {
                if (this.mutex == null)
                    return;
                this.mutex.ReleaseMutex();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
