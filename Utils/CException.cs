// Decompiled with JetBrains decompiler
// Type: Utils.CException
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System;
using System.Runtime.Serialization;

namespace Utils
{
    internal class CException : Exception, ISerializable
    {
        private long cResult;

        public long CResult => this.cResult;

        public CException()
          : base("")
          => this.cResult = 0L;

        public CException(long result)
          : base("")
          => this.cResult = result;

        public CException(long result, string message)
          : base(message)
          => this.cResult = result;

        public CException(string message)
          : base(message)
          => this.cResult = 0L;

        public CException(string message, Exception inner)
          : base(message, inner)
          => this.cResult = 0L;

        public CException(SerializationInfo info, StreamingContext context)
          : base(info, context)
          => this.cResult = 0L;
    }
}
