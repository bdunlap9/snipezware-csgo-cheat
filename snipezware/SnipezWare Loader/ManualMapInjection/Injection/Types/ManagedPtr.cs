using System;
using System.Runtime.InteropServices;

namespace ManualMapInjection.Injection.Types
{
	// Token: 0x02000032 RID: 50
	public class ManagedPtr<T> where T : struct
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000090 RID: 144 RVA: 0x00003CC9 File Offset: 0x00001EC9
		public IntPtr Address { get; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000091 RID: 145 RVA: 0x00003CD1 File Offset: 0x00001ED1
		public T Value
		{
			get
			{
				return this[0u];
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000092 RID: 146 RVA: 0x00003CDA File Offset: 0x00001EDA
		public int StructSize
		{
			get
			{
				if (this._structSize == null)
				{
					this._structSize = new int?(Marshal.SizeOf(typeof(T)));
				}
				return this._structSize.Value;
			}
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00003D0E File Offset: 0x00001F0E
		private static T GetStructure(IntPtr address)
		{
			return (T)((object)Marshal.PtrToStructure(address, typeof(T)));
		}

		// Token: 0x1700000E RID: 14
		public T this[uint index]
		{
			get
			{
				return ManagedPtr<T>.GetStructure(this.Address + (int)(index * (uint)this.StructSize));
			}
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00003D3F File Offset: 0x00001F3F
		public static ManagedPtr<T>operator +(ManagedPtr<T> c1, int c2)
		{
			return new ManagedPtr<T>(c1.Address + c2 * c1.StructSize);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00003D59 File Offset: 0x00001F59
		public static ManagedPtr<T>operator ++(ManagedPtr<T> a)
		{
			return a + 1;
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00003D62 File Offset: 0x00001F62
		public static ManagedPtr<T>operator -(ManagedPtr<T> c1, int c2)
		{
			return new ManagedPtr<T>(c1.Address - c2 * c1.StructSize);
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00003D7C File Offset: 0x00001F7C
		public static ManagedPtr<T>operator --(ManagedPtr<T> a)
		{
			return a - 1;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00003D85 File Offset: 0x00001F85
		public static explicit operator ManagedPtr<T>(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				return null;
			}
			return new ManagedPtr<T>(ptr);
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00003D9C File Offset: 0x00001F9C
		public static explicit operator IntPtr(ManagedPtr<T> ptr)
		{
			return ptr.Address;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00003DA4 File Offset: 0x00001FA4
		public ManagedPtr(IntPtr address)
		{
			this.Address = address;
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00003DB4 File Offset: 0x00001FB4
		public ManagedPtr(object value, bool freeHandle = true)
		{
			if (value == null)
			{
				throw new InvalidOperationException("Cannot create a pointer of type null");
			}
			try
			{
				this._handle = GCHandle.Alloc(value, GCHandleType.Pinned);
			}
			catch (Exception)
			{
				throw new InvalidOperationException("Cannot create a pointer of type " + value.GetType().Name);
			}
			this._freeHandle = freeHandle;
			this.Address = this._handle.AddrOfPinnedObject();
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00003E2C File Offset: 0x0000202C
		~ManagedPtr()
		{
			if (this._handle.IsAllocated && this._freeHandle)
			{
				this._handle.Free();
			}
		}

		// Token: 0x04000148 RID: 328
		private int? _structSize;

		// Token: 0x04000149 RID: 329
		private GCHandle _handle;

		// Token: 0x0400014A RID: 330
		private bool _freeHandle;
	}
}
