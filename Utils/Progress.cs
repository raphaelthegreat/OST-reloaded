// Decompiled with JetBrains decompiler
// Type: Utils.Progress
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System;

namespace Utils
{
    public class Progress
    {
        private int lower;
        private int upper;
        private long position;
        private long positionCount;
        private string message;
        private string detailMessage;
        private object thisLock = new object();

        public Progress()
        {
            this.lower = this.upper = 0;
            this.position = this.positionCount = 0L;
        }

        public Progress Reset()
        {
            lock (this.thisLock)
            {
                this.lower = this.upper = 0;
                this.position = this.positionCount = 0L;
                this.message = string.Empty;
                this.detailMessage = string.Empty;
            }
            return this;
        }

        public Progress SetRange(int lower, int upper)
        {
            lock (this.thisLock)
            {
                this.lower = this.ToRangeValue(lower);
                this.upper = Math.Max(this.lower, this.ToRangeValue(upper));
                this.position = 0L;
                this.positionCount = (long)(this.upper - this.lower);
            }
            return this;
        }

        public long GetPosition()
        {
            lock (this.thisLock)
                return this.position;
        }

        public Progress SetPosition(long position)
        {
            lock (this.thisLock)
                this.position = Math.Min(position, this.positionCount);
            return this;
        }

        public Progress OffsetPosition(long offset)
        {
            lock (this.thisLock)
                this.position = Math.Min(this.position + offset, this.positionCount);
            return this;
        }

        public Progress SetPositionCount(long count)
        {
            lock (this.thisLock)
            {
                this.position = 0L;
                this.positionCount = count;
            }
            return this;
        }

        public Progress RefreshPositionCount(long count)
        {
            lock (this.thisLock)
            {
                this.lower = this.GetPercentage();
                this.position = 0L;
                this.positionCount = count;
            }
            return this;
        }

        public Progress SetMessage(string message)
        {
            lock (this.thisLock)
            {
                this.message = message;
                CLogs.I(message);
            }
            return this;
        }

        public Progress SetDetailMessage(string message)
        {
            lock (this.thisLock)
            {
                this.detailMessage = message;
                CLogs.I(message);
            }
            return this;
        }

        public int GetPercentage()
        {
            lock (this.thisLock)
                return Convert.ToInt32(this.CalOuterPercentage());
        }

        public string GetMessage()
        {
            lock (this.thisLock)
                return this.message;
        }

        public string GetDetailMessage()
        {
            lock (this.thisLock)
                return this.detailMessage;
        }

        private int ToRangeValue(int input) => Math.Min(input, 100);

        private double CalInnerPercentage() => this.positionCount <= 0L ? 0.0 : (double)this.position * 100.0 / (double)this.positionCount / 100.0;

        private double CalOuterPercentage() => (double)(this.upper - this.lower) * this.CalInnerPercentage() + (double)this.lower;
    }
}
