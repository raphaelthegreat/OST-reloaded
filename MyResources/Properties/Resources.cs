// Decompiled with JetBrains decompiler
// Type: MyResources.Properties.Resources
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace MyResources.Properties
{
    [CompilerGenerated]
    [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    [DebuggerNonUserCode]
    internal class Resources
    {
        private static ResourceManager resourceMan;
        private static CultureInfo resourceCulture;

        internal Resources()
        {
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals((object)MyResources.Properties.Resources.resourceMan, (object)null))
                    MyResources.Properties.Resources.resourceMan = new ResourceManager("OnlineUpdateTool.Properties.Resources", typeof(MyResources.Properties.Resources).Assembly);
                return MyResources.Properties.Resources.resourceMan;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get => MyResources.Properties.Resources.resourceCulture;
            set => MyResources.Properties.Resources.resourceCulture = value;
        }

        internal static Bitmap BackMain => (Bitmap)MyResources.Properties.Resources.ResourceManager.GetObject(nameof(BackMain), MyResources.Properties.Resources.resourceCulture);

        internal static Bitmap BackWarning => (Bitmap)MyResources.Properties.Resources.ResourceManager.GetObject(nameof(BackWarning), MyResources.Properties.Resources.resourceCulture);

        internal static Bitmap Button => (Bitmap)MyResources.Properties.Resources.ResourceManager.GetObject(nameof(Button), MyResources.Properties.Resources.resourceCulture);
    }
}
