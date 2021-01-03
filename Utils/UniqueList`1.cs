// Decompiled with JetBrains decompiler
// Type: Utils.UniqueList`1
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System.Collections.Generic;

namespace Utils
{
    internal class UniqueList<T> : List<T>
    {
        public new void Add(T obj)
        {
            if (this.Contains(obj))
                return;
            base.Add(obj);
        }
    }
}
