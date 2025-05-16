using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Keyboard
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resource1
	{
		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (resourceMan == null)
				{
					ResourceManager resourceManager = (resourceMan = new ResourceManager("Keyboard.Resource1", typeof(Resource1).Assembly));
				}
				return resourceMan;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return resourceCulture;
			}
			set
			{
				resourceCulture = value;
			}
		}

		internal static Bitmap _3
		{
			get
			{
				object @object = ResourceManager.GetObject("3", resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap _6
		{
			get
			{
				object @object = ResourceManager.GetObject("6", resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap _7
		{
			get
			{
				object @object = ResourceManager.GetObject("7", resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static UnmanagedMemoryStream complete => ResourceManager.GetStream("complete", resourceCulture);

		internal static UnmanagedMemoryStream err => ResourceManager.GetStream("err", resourceCulture);

		internal static byte[] k2
		{
			get
			{
				object @object = ResourceManager.GetObject("k2", resourceCulture);
				return (byte[])@object;
			}
		}

		internal static Icon key
		{
			get
			{
				object @object = ResourceManager.GetObject("key", resourceCulture);
				return (Icon)@object;
			}
		}

		internal static Bitmap sound
		{
			get
			{
				object @object = ResourceManager.GetObject("sound", resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap soundStop
		{
			get
			{
				object @object = ResourceManager.GetObject("soundStop", resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static UnmanagedMemoryStream type => ResourceManager.GetStream("type", resourceCulture);

		internal Resource1()
		{
		}
	}
}
