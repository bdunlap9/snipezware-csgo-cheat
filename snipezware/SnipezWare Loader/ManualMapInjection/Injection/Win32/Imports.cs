using System;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x0200001D RID: 29
	[SuppressUnmanagedCodeSecurity]
	internal static class Imports
	{
		// Token: 0x0600002D RID: 45
		[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr VirtualAllocEx(IntPtr hProcess, UIntPtr lpAddress, IntPtr dwSize, Imports.AllocationType flAllocationType, Imports.MemoryProtection flProtect);

		// Token: 0x0600002E RID: 46
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern IntPtr VirtualAlloc(IntPtr lpAddress, UIntPtr dwSize, Imports.AllocationType flAllocationType, Imports.MemoryProtection flProtect);

		// Token: 0x0600002F RID: 47
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern IntPtr OpenProcess(Imports.ProcessAccessFlags processAccess, bool bInheritHandle, int processId);

		// Token: 0x06000030 RID: 48
		[SuppressUnmanagedCodeSecurity]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CloseHandle(IntPtr hObject);

		// Token: 0x06000031 RID: 49
		[DllImport("Dbghelp.dll")]
		public static extern IntPtr ImageRvaToVa(IntPtr NtHeaders, IntPtr Base, UIntPtr Rva, IntPtr LastRvaSection);

		// Token: 0x06000032 RID: 50
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern IntPtr GetProcessHeap();

		// Token: 0x06000033 RID: 51
		[DllImport("kernel32.dll")]
		public static extern IntPtr HeapAlloc(IntPtr hHeap, uint dwFlags, UIntPtr dwBytes);

		// Token: 0x06000034 RID: 52
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool HeapFree(IntPtr hHeap, uint dwFlags, IntPtr lpMem);

		// Token: 0x06000035 RID: 53
		[DllImport("NTDLL.DLL", SetLastError = true)]
		public static extern int NtQueryInformationProcess(IntPtr hProcess, int pic, IntPtr pbi, uint cb, out uint pSize);

		// Token: 0x06000036 RID: 54
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, int dwSize, out UIntPtr lpNumberOfBytesRead);

		// Token: 0x06000037 RID: 55
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, out UIntPtr lpNumberOfBytesWritten);

		// Token: 0x06000038 RID: 56
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, IntPtr nSize, out UIntPtr lpNumberOfBytesWritten);

		// Token: 0x06000039 RID: 57
		[DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

		// Token: 0x0600003A RID: 58
		[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr GetModuleHandle(string lpModuleName);

		// Token: 0x0600003B RID: 59
		[DllImport("kernel32.dll")]
		public static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

		// Token: 0x0600003C RID: 60
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern uint WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);

		// Token: 0x0600003D RID: 61
		[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, int dwSize, Imports.FreeType dwFreeType);

		// Token: 0x0600003E RID: 62
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool VirtualFree(IntPtr lpAddress, int dwSize, Imports.FreeType dwFreeType);

		// Token: 0x0600003F RID: 63
		[DllImport("kernel32.dll")]
		public static extern bool VirtualProtectEx(IntPtr hProcess, IntPtr lpAddress, UIntPtr dwSize, uint flNewProtect, out uint lpflOldProtect);

		// Token: 0x06000040 RID: 64
		[DllImport("kernel32.dll")]
		public static extern void GetSystemTimeAsFileTime(out FILETIME lpSystemTimeAsFileTime);

		// Token: 0x06000041 RID: 65
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

		// Token: 0x06000042 RID: 66 RVA: 0x000037A8 File Offset: 0x000019A8
		public static bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, out UIntPtr lpNumberOfBytesRead)
		{
			GCHandle gchandle = GCHandle.Alloc(lpBuffer, GCHandleType.Pinned);
			bool result = Imports.ReadProcessMemory(hProcess, lpBaseAddress, gchandle.AddrOfPinnedObject(), lpBuffer.Length, out lpNumberOfBytesRead);
			gchandle.Free();
			return result;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000037D8 File Offset: 0x000019D8
		public static bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, out uint lpBuffer, out UIntPtr lpNumberOfBytesRead)
		{
			byte[] array = new byte[4];
			bool result = Imports.ReadProcessMemory(hProcess, lpBaseAddress, array, out lpNumberOfBytesRead);
			lpBuffer = BitConverter.ToUInt32(array, 0);
			return result;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00003800 File Offset: 0x00001A00
		public static bool ReadProcessMemory<T>(IntPtr hProcess, IntPtr lpBaseAddress, out T lpBuffer, out UIntPtr lpNumberOfBytesRead) where T : struct
		{
			byte[] array = new byte[Marshal.SizeOf(typeof(T))];
			bool result = Imports.ReadProcessMemory(hProcess, lpBaseAddress, array, out lpNumberOfBytesRead);
			GCHandle gchandle = GCHandle.Alloc(array, GCHandleType.Pinned);
			lpBuffer = Marshal.PtrToStructure<T>(gchandle.AddrOfPinnedObject());
			gchandle.Free();
			return result;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x0000384C File Offset: 0x00001A4C
		public static IntPtr OpenProcess(Process proc, Imports.ProcessAccessFlags flags)
		{
			return Imports.OpenProcess(flags, false, proc.Id);
		}

		// Token: 0x0200001E RID: 30
		[Flags]
		public enum AllocationType
		{
			// Token: 0x04000121 RID: 289
			Commit = 4096,
			// Token: 0x04000122 RID: 290
			Reserve = 8192,
			// Token: 0x04000123 RID: 291
			Decommit = 16384,
			// Token: 0x04000124 RID: 292
			Release = 32768,
			// Token: 0x04000125 RID: 293
			Reset = 524288,
			// Token: 0x04000126 RID: 294
			Physical = 4194304,
			// Token: 0x04000127 RID: 295
			TopDown = 1048576,
			// Token: 0x04000128 RID: 296
			WriteWatch = 2097152,
			// Token: 0x04000129 RID: 297
			LargePages = 536870912
		}

		// Token: 0x0200001F RID: 31
		[Flags]
		public enum MemoryProtection
		{
			// Token: 0x0400012B RID: 299
			Execute = 16,
			// Token: 0x0400012C RID: 300
			ExecuteRead = 32,
			// Token: 0x0400012D RID: 301
			ExecuteReadWrite = 64,
			// Token: 0x0400012E RID: 302
			ExecuteWriteCopy = 128,
			// Token: 0x0400012F RID: 303
			NoAccess = 1,
			// Token: 0x04000130 RID: 304
			ReadOnly = 2,
			// Token: 0x04000131 RID: 305
			ReadWrite = 4,
			// Token: 0x04000132 RID: 306
			WriteCopy = 8,
			// Token: 0x04000133 RID: 307
			GuardModifierflag = 256,
			// Token: 0x04000134 RID: 308
			NoCacheModifierflag = 512,
			// Token: 0x04000135 RID: 309
			WriteCombineModifierflag = 1024
		}

		// Token: 0x02000020 RID: 32
		[Flags]
		public enum ProcessAccessFlags : uint
		{
			// Token: 0x04000137 RID: 311
			All = 2035711u,
			// Token: 0x04000138 RID: 312
			Terminate = 1u,
			// Token: 0x04000139 RID: 313
			CreateThread = 2u,
			// Token: 0x0400013A RID: 314
			VirtualMemoryOperation = 8u,
			// Token: 0x0400013B RID: 315
			VirtualMemoryRead = 16u,
			// Token: 0x0400013C RID: 316
			VirtualMemoryWrite = 32u,
			// Token: 0x0400013D RID: 317
			DuplicateHandle = 64u,
			// Token: 0x0400013E RID: 318
			CreateProcess = 128u,
			// Token: 0x0400013F RID: 319
			SetQuota = 256u,
			// Token: 0x04000140 RID: 320
			SetInformation = 512u,
			// Token: 0x04000141 RID: 321
			QueryInformation = 1024u,
			// Token: 0x04000142 RID: 322
			QueryLimitedInformation = 4096u,
			// Token: 0x04000143 RID: 323
			Synchronize = 1048576u
		}

		// Token: 0x02000021 RID: 33
		[Flags]
		public enum FreeType
		{
			// Token: 0x04000145 RID: 325
			Decommit = 16384,
			// Token: 0x04000146 RID: 326
			Release = 32768
		}
	}
}
