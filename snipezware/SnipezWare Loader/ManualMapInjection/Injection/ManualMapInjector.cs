using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using ManualMapInjection.Injection.Win32;

namespace ManualMapInjection.Injection
{
	// Token: 0x02000003 RID: 3
	internal class ManualMapInjector
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000004 RID: 4 RVA: 0x000020C5 File Offset: 0x000002C5
		// (set) Token: 0x06000005 RID: 5 RVA: 0x000020CD File Offset: 0x000002CD
		public bool AsyncInjection { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000006 RID: 6 RVA: 0x000020D6 File Offset: 0x000002D6
		// (set) Token: 0x06000007 RID: 7 RVA: 0x000020DE File Offset: 0x000002DE
		public uint TimeOut { get; set; } = 5000u;

		// Token: 0x06000008 RID: 8 RVA: 0x000020E8 File Offset: 0x000002E8
		private PIMAGE_DOS_HEADER GetDosHeader(IntPtr address)
		{
			PIMAGE_DOS_HEADER pimage_DOS_HEADER = (PIMAGE_DOS_HEADER)address;
			if (!pimage_DOS_HEADER.Value.isValid)
			{
				return null;
			}
			return pimage_DOS_HEADER;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002110 File Offset: 0x00000310
		private PIMAGE_NT_HEADERS32 GetNtHeader(IntPtr address)
		{
			PIMAGE_DOS_HEADER dosHeader = this.GetDosHeader(address);
			if (dosHeader == null)
			{
				return null;
			}
			PIMAGE_NT_HEADERS32 pimage_NT_HEADERS = (PIMAGE_NT_HEADERS32)(address + dosHeader.Value.e_lfanew);
			if (!pimage_NT_HEADERS.Value.isValid)
			{
				return null;
			}
			return pimage_NT_HEADERS;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002154 File Offset: 0x00000354
		private IntPtr RemoteAllocateMemory(uint size)
		{
			return Imports.VirtualAllocEx(this._hProcess, UIntPtr.Zero, new IntPtr((long)((ulong)size)), Imports.AllocationType.Commit | Imports.AllocationType.Reserve, Imports.MemoryProtection.ExecuteReadWrite);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002174 File Offset: 0x00000374
		private IntPtr AllocateMemory(uint size)
		{
			return Imports.VirtualAlloc(IntPtr.Zero, new UIntPtr(size), Imports.AllocationType.Commit | Imports.AllocationType.Reserve, Imports.MemoryProtection.ExecuteReadWrite);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002190 File Offset: 0x00000390
		private IntPtr RvaToPointer(uint rva, IntPtr baseAddress)
		{
			PIMAGE_NT_HEADERS32 ntHeader = this.GetNtHeader(baseAddress);
			if (ntHeader == null)
			{
				return IntPtr.Zero;
			}
			return Imports.ImageRvaToVa(ntHeader.Address, baseAddress, new UIntPtr(rva), IntPtr.Zero);
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000021C8 File Offset: 0x000003C8
		private bool InjectDependency(string dependency)
		{
			IntPtr procAddress = Imports.GetProcAddress(Imports.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
			if (procAddress == IntPtr.Zero)
			{
				return false;
			}
			IntPtr intPtr = this.RemoteAllocateMemory((uint)dependency.Length);
			if (intPtr == IntPtr.Zero)
			{
				return false;
			}
			byte[] bytes = Encoding.ASCII.GetBytes(dependency);
			UIntPtr uintPtr;
			bool flag = Imports.WriteProcessMemory(this._hProcess, intPtr, bytes, bytes.Length, out uintPtr);
			if (flag && Imports.WaitForSingleObject(Imports.CreateRemoteThread(this._hProcess, IntPtr.Zero, 0u, procAddress, intPtr, 0u, IntPtr.Zero), this.TimeOut) != 0u)
			{
				return false;
			}
			Imports.VirtualFreeEx(this._hProcess, intPtr, 0, Imports.FreeType.Release);
			return flag;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002278 File Offset: 0x00000478
		private IntPtr GetRemoteModuleHandleA(string module)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr processHeap = Imports.GetProcessHeap();
			uint num = (uint)Marshal.SizeOf(typeof(PROCESS_BASIC_INFORMATION));
			PPROCESS_BASIC_INFORMATION pprocess_BASIC_INFORMATION = (PPROCESS_BASIC_INFORMATION)Imports.HeapAlloc(processHeap, 8u, new UIntPtr(num));
			uint num3;
			int num2 = Imports.NtQueryInformationProcess(this._hProcess, 0, pprocess_BASIC_INFORMATION.Address, num, out num3);
			if (num2 >= 0 && num < num3)
			{
				if (pprocess_BASIC_INFORMATION != null)
				{
					Imports.HeapFree(processHeap, 0u, pprocess_BASIC_INFORMATION.Address);
				}
				pprocess_BASIC_INFORMATION = (PPROCESS_BASIC_INFORMATION)Imports.HeapAlloc(processHeap, 8u, new UIntPtr(num));
				if (pprocess_BASIC_INFORMATION == null)
				{
					return IntPtr.Zero;
				}
				num2 = Imports.NtQueryInformationProcess(this._hProcess, 0, pprocess_BASIC_INFORMATION.Address, num3, out num3);
			}
			uint num4;
			UIntPtr uintPtr;
			if (num2 >= 0 && pprocess_BASIC_INFORMATION.Value.PebBaseAddress != IntPtr.Zero && Imports.ReadProcessMemory(this._hProcess, pprocess_BASIC_INFORMATION.Value.PebBaseAddress + 12, out num4, out uintPtr))
			{
				uint num5 = num4 + 12u;
				uint num6 = num4 + 12u;
				uint num8;
				for (;;)
				{
					uint num7;
					if (!Imports.ReadProcessMemory(this._hProcess, new IntPtr((long)((ulong)num6)), out num7, out uintPtr))
					{
						Imports.HeapFree(processHeap, 0u, pprocess_BASIC_INFORMATION.Address);
					}
					num6 = num7;
					UNICODE_STRING unicode_STRING;
					Imports.ReadProcessMemory<UNICODE_STRING>(this._hProcess, new IntPtr((long)((ulong)num7)) + 44, out unicode_STRING, out uintPtr);
					string a = string.Empty;
					if (unicode_STRING.Length > 0)
					{
						byte[] array = new byte[(int)unicode_STRING.Length];
						Imports.ReadProcessMemory(this._hProcess, unicode_STRING.Buffer, array, out uintPtr);
						a = Encoding.Unicode.GetString(array);
					}
					Imports.ReadProcessMemory(this._hProcess, new IntPtr((long)((ulong)num7)) + 24, out num8, out uintPtr);
					uint num9;
					Imports.ReadProcessMemory(this._hProcess, new IntPtr((long)((ulong)num7)) + 32, out num9, out uintPtr);
					if (num8 != 0u && num9 != 0u && string.Equals(a, module, StringComparison.OrdinalIgnoreCase))
					{
						break;
					}
					if (num5 == num6)
					{
						goto IL_1DF;
					}
				}
				zero = new IntPtr((long)((ulong)num8));
			}
			IL_1DF:
			if (pprocess_BASIC_INFORMATION != null)
			{
				Imports.HeapFree(processHeap, 0u, pprocess_BASIC_INFORMATION.Address);
			}
			return zero;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002478 File Offset: 0x00000678
		private IntPtr GetDependencyProcAddressA(IntPtr moduleBase, PCHAR procName)
		{
			IntPtr intPtr = IntPtr.Zero;
			IMAGE_DOS_HEADER image_DOS_HEADER;
			UIntPtr uintPtr;
			Imports.ReadProcessMemory<IMAGE_DOS_HEADER>(this._hProcess, moduleBase, out image_DOS_HEADER, out uintPtr);
			if (!image_DOS_HEADER.isValid)
			{
				return IntPtr.Zero;
			}
			IMAGE_NT_HEADERS32 image_NT_HEADERS;
			Imports.ReadProcessMemory<IMAGE_NT_HEADERS32>(this._hProcess, moduleBase + image_DOS_HEADER.e_lfanew, out image_NT_HEADERS, out uintPtr);
			if (!image_NT_HEADERS.isValid)
			{
				return IntPtr.Zero;
			}
			uint virtualAddress = image_NT_HEADERS.OptionalHeader.ExportTable.VirtualAddress;
			if (virtualAddress > 0u)
			{
				uint size = image_NT_HEADERS.OptionalHeader.ExportTable.Size;
				PIMAGE_EXPORT_DIRECTORY pimage_EXPORT_DIRECTORY = (PIMAGE_EXPORT_DIRECTORY)this.AllocateMemory(size);
				Imports.ReadProcessMemory(this._hProcess, moduleBase + (int)virtualAddress, pimage_EXPORT_DIRECTORY.Address, (int)size, out uintPtr);
				PWORD pword = (PWORD)(pimage_EXPORT_DIRECTORY.Address + (int)pimage_EXPORT_DIRECTORY.Value.AddressOfNameOrdinals - (int)virtualAddress);
				PDWORD pdword = (PDWORD)(pimage_EXPORT_DIRECTORY.Address + (int)pimage_EXPORT_DIRECTORY.Value.AddressOfNames - (int)virtualAddress);
				PDWORD pdword2 = (PDWORD)(pimage_EXPORT_DIRECTORY.Address + (int)pimage_EXPORT_DIRECTORY.Value.AddressOfFunctions - (int)virtualAddress);
				uint num = 0u;
				while (num < pimage_EXPORT_DIRECTORY.Value.NumberOfFunctions)
				{
					PCHAR pchar = null;
					ushort num2;
					if (new PDWORD(procName.Address).Value <= 65535u)
					{
						num2 = (ushort)num;
					}
					else
					{
						if (new PDWORD(procName.Address).Value <= 65535u || num >= pimage_EXPORT_DIRECTORY.Value.NumberOfNames)
						{
							return IntPtr.Zero;
						}
						pchar = (PCHAR)new IntPtr((long)((ulong)pdword[num] + (ulong)((long)pimage_EXPORT_DIRECTORY.Address.ToInt32()) - (ulong)virtualAddress));
						num2 = pword[num];
					}
					if ((new PDWORD(procName.Address).Value <= 65535u && new PDWORD(procName.Address).Value == (uint)num2 + pimage_EXPORT_DIRECTORY.Value.Base) || (new PDWORD(procName.Address).Value > 65535u && pchar.ToString() == procName.ToString()))
					{
						intPtr = moduleBase + (int)pdword2[(uint)num2];
						if (intPtr.ToInt64() < (moduleBase + (int)virtualAddress).ToInt64() || intPtr.ToInt64() > (moduleBase + (int)virtualAddress + (int)size).ToInt64())
						{
							break;
						}
						byte[] array = new byte[255];
						Imports.ReadProcessMemory(this._hProcess, intPtr, array, out uintPtr);
						string text = Helpers.ToStringAnsi(array);
						string text2 = text.Substring(0, text.IndexOf(".")) + ".dll";
						string text3 = text.Substring(text.IndexOf(".") + 1);
						IntPtr remoteModuleHandleA = this.GetRemoteModuleHandleA(text2);
						if (remoteModuleHandleA == IntPtr.Zero)
						{
							this.InjectDependency(text2);
						}
						if (text3.StartsWith("#"))
						{
							intPtr = this.GetDependencyProcAddressA(remoteModuleHandleA, new PCHAR(text3) + 1);
							break;
						}
						intPtr = this.GetDependencyProcAddressA(remoteModuleHandleA, new PCHAR(text3));
						break;
					}
					else
					{
						num += 1u;
					}
				}
				Imports.VirtualFree(pimage_EXPORT_DIRECTORY.Address, 0, Imports.FreeType.Release);
			}
			return intPtr;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000027D0 File Offset: 0x000009D0
		private bool ProcessImportTable(IntPtr baseAddress)
		{
			PIMAGE_NT_HEADERS32 ntHeader = this.GetNtHeader(baseAddress);
			if (ntHeader == null)
			{
				return false;
			}
			if (ntHeader.Value.OptionalHeader.ImportTable.Size <= 0u)
			{
				return true;
			}
			PIMAGE_IMPORT_DESCRIPTOR pimage_IMPORT_DESCRIPTOR = (PIMAGE_IMPORT_DESCRIPTOR)this.RvaToPointer(ntHeader.Value.OptionalHeader.ImportTable.VirtualAddress, baseAddress);
			if (pimage_IMPORT_DESCRIPTOR != null)
			{
				while (pimage_IMPORT_DESCRIPTOR.Value.Name > 0u)
				{
					PCHAR pchar = (PCHAR)this.RvaToPointer(pimage_IMPORT_DESCRIPTOR.Value.Name, baseAddress);
					if (pchar != null)
					{
						if (pchar.ToString().Contains("-ms-win-crt-"))
						{
							pchar = new PCHAR("ucrtbase.dll");
						}
						IntPtr remoteModuleHandleA = this.GetRemoteModuleHandleA(pchar.ToString());
						if (remoteModuleHandleA == IntPtr.Zero)
						{
							this.InjectDependency(pchar.ToString());
							remoteModuleHandleA = this.GetRemoteModuleHandleA(pchar.ToString());
							if (remoteModuleHandleA == IntPtr.Zero)
							{
								goto IL_20D;
							}
						}
						PIMAGE_THUNK_DATA pimage_THUNK_DATA;
						PIMAGE_THUNK_DATA pimage_THUNK_DATA2;
						if (pimage_IMPORT_DESCRIPTOR.Value.OriginalFirstThunk > 0u)
						{
							pimage_THUNK_DATA = (PIMAGE_THUNK_DATA)this.RvaToPointer(pimage_IMPORT_DESCRIPTOR.Value.OriginalFirstThunk, baseAddress);
							pimage_THUNK_DATA2 = (PIMAGE_THUNK_DATA)this.RvaToPointer(pimage_IMPORT_DESCRIPTOR.Value.FirstThunk, baseAddress);
						}
						else
						{
							pimage_THUNK_DATA = (PIMAGE_THUNK_DATA)this.RvaToPointer(pimage_IMPORT_DESCRIPTOR.Value.FirstThunk, baseAddress);
							pimage_THUNK_DATA2 = (PIMAGE_THUNK_DATA)this.RvaToPointer(pimage_IMPORT_DESCRIPTOR.Value.FirstThunk, baseAddress);
						}
						while (pimage_THUNK_DATA.Value.AddressOfData > 0u)
						{
							IntPtr dependencyProcAddressA;
							if ((pimage_THUNK_DATA.Value.Ordinal & 2147483648u) > 0u)
							{
								short num = (short)(pimage_THUNK_DATA.Value.Ordinal & 65535u);
								dependencyProcAddressA = this.GetDependencyProcAddressA(remoteModuleHandleA, new PCHAR(num));
								if (dependencyProcAddressA == IntPtr.Zero)
								{
									return false;
								}
							}
							else
							{
								PCHAR procName = (PCHAR)((PIMAGE_IMPORT_BY_NAME)this.RvaToPointer(pimage_THUNK_DATA2.Value.Ordinal, baseAddress)).Address + 2;
								dependencyProcAddressA = this.GetDependencyProcAddressA(remoteModuleHandleA, procName);
							}
							Marshal.WriteInt32(pimage_THUNK_DATA2.Address, dependencyProcAddressA.ToInt32());
							pimage_THUNK_DATA = ++pimage_THUNK_DATA;
							pimage_THUNK_DATA2 = ++pimage_THUNK_DATA2;
						}
					}
					IL_20D:
					pimage_IMPORT_DESCRIPTOR = ++pimage_IMPORT_DESCRIPTOR;
				}
				return true;
			}
			return false;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002A08 File Offset: 0x00000C08
		private bool ProcessDelayedImportTable(IntPtr baseAddress, IntPtr remoteAddress)
		{
			PIMAGE_NT_HEADERS32 ntHeader = this.GetNtHeader(baseAddress);
			if (ntHeader == null)
			{
				return false;
			}
			if (ntHeader.Value.OptionalHeader.DelayImportDescriptor.Size <= 0u)
			{
				return true;
			}
			PIMAGE_IMPORT_DESCRIPTOR pimage_IMPORT_DESCRIPTOR = (PIMAGE_IMPORT_DESCRIPTOR)this.RvaToPointer(ntHeader.Value.OptionalHeader.DelayImportDescriptor.VirtualAddress, baseAddress);
			if (pimage_IMPORT_DESCRIPTOR != null)
			{
				while (pimage_IMPORT_DESCRIPTOR.Value.Name > 0u)
				{
					PCHAR pchar = (PCHAR)this.RvaToPointer(pimage_IMPORT_DESCRIPTOR.Value.Name, baseAddress);
					if (pchar != null)
					{
						IntPtr remoteModuleHandleA = this.GetRemoteModuleHandleA(pchar.ToString());
						if (remoteModuleHandleA == IntPtr.Zero)
						{
							this.InjectDependency(pchar.ToString());
							remoteModuleHandleA = this.GetRemoteModuleHandleA(pchar.ToString());
							if (remoteModuleHandleA == IntPtr.Zero)
							{
								goto IL_1F6;
							}
						}
						PIMAGE_THUNK_DATA pimage_THUNK_DATA;
						PIMAGE_THUNK_DATA pimage_THUNK_DATA2;
						if (pimage_IMPORT_DESCRIPTOR.Value.OriginalFirstThunk > 0u)
						{
							pimage_THUNK_DATA = (PIMAGE_THUNK_DATA)this.RvaToPointer(pimage_IMPORT_DESCRIPTOR.Value.OriginalFirstThunk, baseAddress);
							pimage_THUNK_DATA2 = (PIMAGE_THUNK_DATA)this.RvaToPointer(pimage_IMPORT_DESCRIPTOR.Value.FirstThunk, baseAddress);
						}
						else
						{
							pimage_THUNK_DATA = (PIMAGE_THUNK_DATA)this.RvaToPointer(pimage_IMPORT_DESCRIPTOR.Value.FirstThunk, baseAddress);
							pimage_THUNK_DATA2 = (PIMAGE_THUNK_DATA)this.RvaToPointer(pimage_IMPORT_DESCRIPTOR.Value.FirstThunk, baseAddress);
						}
						while (pimage_THUNK_DATA.Value.AddressOfData > 0u)
						{
							IntPtr dependencyProcAddressA;
							if ((pimage_THUNK_DATA.Value.Ordinal & 2147483648u) > 0u)
							{
								short num = (short)(pimage_THUNK_DATA.Value.Ordinal & 65535u);
								dependencyProcAddressA = this.GetDependencyProcAddressA(remoteModuleHandleA, new PCHAR(num));
								if (dependencyProcAddressA == IntPtr.Zero)
								{
									return false;
								}
							}
							else
							{
								PCHAR procName = (PCHAR)((PIMAGE_IMPORT_BY_NAME)this.RvaToPointer(pimage_THUNK_DATA2.Value.Ordinal, baseAddress)).Address + 2;
								dependencyProcAddressA = this.GetDependencyProcAddressA(remoteModuleHandleA, procName);
							}
							Marshal.WriteInt32(pimage_THUNK_DATA2.Address, dependencyProcAddressA.ToInt32());
							pimage_THUNK_DATA = ++pimage_THUNK_DATA;
							pimage_THUNK_DATA2 = ++pimage_THUNK_DATA2;
						}
					}
					IL_1F6:
					pimage_IMPORT_DESCRIPTOR = ++pimage_IMPORT_DESCRIPTOR;
				}
				return true;
			}
			return false;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002C28 File Offset: 0x00000E28
		private bool ProcessRelocation(uint imageBaseDelta, ushort data, PBYTE relocationBase)
		{
			bool result = true;
			switch (data >> 12 & 15)
			{
			case 0:
			case 4:
				return result;
			case 1:
			{
				PSHORT pshort = (PSHORT)(relocationBase + (int)(data & 4095)).Address;
				Marshal.WriteInt16(pshort.Address, (short)((long)pshort.Value + (long)((ulong)((ushort)(imageBaseDelta >> 16 & 65535u)))));
				return result;
			}
			case 2:
			{
				PSHORT pshort = (PSHORT)(relocationBase + (int)(data & 4095)).Address;
				Marshal.WriteInt16(pshort.Address, (short)((long)pshort.Value + (long)((ulong)((ushort)(imageBaseDelta & 65535u)))));
				return result;
			}
			case 3:
			{
				PDWORD pdword = (PDWORD)(relocationBase + (int)(data & 4095)).Address;
				Marshal.WriteInt32(pdword.Address, (int)(pdword.Value + imageBaseDelta));
				return result;
			}
			case 10:
			{
				PDWORD pdword = (PDWORD)(relocationBase + (int)(data & 4095)).Address;
				Marshal.WriteInt32(pdword.Address, (int)(pdword.Value + imageBaseDelta));
				return result;
			}
			}
			result = false;
			return result;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002D48 File Offset: 0x00000F48
		private bool ProcessRelocations(IntPtr baseAddress, IntPtr remoteAddress)
		{
			PIMAGE_NT_HEADERS32 ntHeader = this.GetNtHeader(baseAddress);
			if (ntHeader == null)
			{
				return false;
			}
			if ((ntHeader.Value.FileHeader.Characteristics & 1) > 0)
			{
				return true;
			}
			uint imageBaseDelta = (uint)((long)remoteAddress.ToInt32() - (long)((ulong)ntHeader.Value.OptionalHeader.ImageBase));
			uint size = ntHeader.Value.OptionalHeader.BaseRelocationTable.Size;
			if (size > 0u)
			{
				PIMAGE_BASE_RELOCATION pimage_BASE_RELOCATION = (PIMAGE_BASE_RELOCATION)this.RvaToPointer(ntHeader.Value.OptionalHeader.BaseRelocationTable.VirtualAddress, baseAddress);
				if (pimage_BASE_RELOCATION == null)
				{
					return false;
				}
				PBYTE pbyte = (PBYTE)pimage_BASE_RELOCATION.Address + (int)size;
				while (pimage_BASE_RELOCATION.Address.ToInt64() < pbyte.Address.ToInt64())
				{
					PBYTE relocationBase = (PBYTE)this.RvaToPointer(pimage_BASE_RELOCATION.Value.VirtualAddress, baseAddress);
					uint num = pimage_BASE_RELOCATION.Value.SizeOfBlock - 8u >> 1;
					PWORD pword = (PWORD)(pimage_BASE_RELOCATION + 1).Address;
					uint num2 = 0u;
					while (num2 < num)
					{
						this.ProcessRelocation(imageBaseDelta, pword.Value, relocationBase);
						num2 += 1u;
						pword = ++pword;
					}
					pimage_BASE_RELOCATION = (PIMAGE_BASE_RELOCATION)pword.Address;
				}
			}
			return true;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002E90 File Offset: 0x00001090
		private uint GetSectionProtection(DataSectionFlags characteristics)
		{
			uint num = 0u;
			if (characteristics.HasFlag(DataSectionFlags.MemoryNotCached))
			{
				num |= 512u;
			}
			if (characteristics.HasFlag(DataSectionFlags.MemoryExecute))
			{
				if (characteristics.HasFlag(DataSectionFlags.MemoryRead))
				{
					if (characteristics.HasFlag((DataSectionFlags)2147483648u))
					{
						num |= 64u;
					}
					else
					{
						num |= 32u;
					}
				}
				else if (characteristics.HasFlag((DataSectionFlags)2147483648u))
				{
					num |= 128u;
				}
				else
				{
					num |= 16u;
				}
			}
			else if (characteristics.HasFlag(DataSectionFlags.MemoryRead))
			{
				if (characteristics.HasFlag((DataSectionFlags)2147483648u))
				{
					num |= 4u;
				}
				else
				{
					num |= 2u;
				}
			}
			else if (characteristics.HasFlag((DataSectionFlags)2147483648u))
			{
				num |= 8u;
			}
			else
			{
				num |= 1u;
			}
			return num;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002F9C File Offset: 0x0000119C
		private bool ProcessSection(char[] name, IntPtr baseAddress, IntPtr remoteAddress, ulong rawData, ulong virtualAddress, ulong rawSize, ulong virtualSize, uint protectFlag)
		{
			UIntPtr uintPtr;
			uint num;
			return Imports.WriteProcessMemory(this._hProcess, new IntPtr(remoteAddress.ToInt64() + (long)virtualAddress), new IntPtr(baseAddress.ToInt64() + (long)rawData), new IntPtr((long)rawSize), out uintPtr) && Imports.VirtualProtectEx(this._hProcess, new IntPtr(remoteAddress.ToInt64() + (long)virtualAddress), new UIntPtr(virtualSize), protectFlag, out num);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x0000300C File Offset: 0x0000120C
		private bool ProcessSections(IntPtr baseAddress, IntPtr remoteAddress)
		{
			PIMAGE_NT_HEADERS32 ntHeader = this.GetNtHeader(baseAddress);
			if (ntHeader == null)
			{
				return false;
			}
			PIMAGE_SECTION_HEADER pimage_SECTION_HEADER = (PIMAGE_SECTION_HEADER)(ntHeader.Address + 24 + (int)ntHeader.Value.FileHeader.SizeOfOptionalHeader);
			for (ushort num = 0; num < ntHeader.Value.FileHeader.NumberOfSections; num += 1)
			{
				if (!Helpers._stricmp(".reloc".ToCharArray(), pimage_SECTION_HEADER[(uint)num].Name))
				{
					DataSectionFlags characteristics = pimage_SECTION_HEADER[(uint)num].Characteristics;
					if (characteristics.HasFlag(DataSectionFlags.MemoryRead) || characteristics.HasFlag((DataSectionFlags)2147483648u) || characteristics.HasFlag(DataSectionFlags.MemoryExecute))
					{
						uint sectionProtection = this.GetSectionProtection(pimage_SECTION_HEADER[(uint)num].Characteristics);
						this.ProcessSection(pimage_SECTION_HEADER[(uint)num].Name, baseAddress, remoteAddress, (ulong)pimage_SECTION_HEADER[(uint)num].PointerToRawData, (ulong)pimage_SECTION_HEADER[(uint)num].VirtualAddress, (ulong)pimage_SECTION_HEADER[(uint)num].SizeOfRawData, (ulong)pimage_SECTION_HEADER[(uint)num].VirtualSize, sectionProtection);
					}
				}
			}
			return true;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00003144 File Offset: 0x00001344
		private bool ExecuteRemoteThreadBuffer(byte[] threadData, bool async)
		{
			IntPtr lpAddress = this.RemoteAllocateMemory((uint)threadData.Length);
			if (lpAddress == IntPtr.Zero)
			{
				return false;
			}
			UIntPtr uintPtr;
			bool flag = Imports.WriteProcessMemory(this._hProcess, lpAddress, threadData, threadData.Length, out uintPtr);
			if (flag)
			{
				IntPtr hHandle = Imports.CreateRemoteThread(this._hProcess, IntPtr.Zero, 0u, lpAddress, IntPtr.Zero, 0u, IntPtr.Zero);
				if (async)
				{
					new Thread(delegate()
					{
						Imports.WaitForSingleObject(hHandle, 5000u);
						Imports.VirtualFreeEx(this._hProcess, lpAddress, 0, Imports.FreeType.Release);
					})
					{
						IsBackground = true
					}.Start();
					return flag;
				}
				Imports.WaitForSingleObject(hHandle, 4000u);
				Imports.VirtualFreeEx(this._hProcess, lpAddress, 0, Imports.FreeType.Release);
			}
			return flag;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00003228 File Offset: 0x00001428
		private bool CallEntryPoint(IntPtr baseAddress, uint entrypoint, bool async)
		{
			List<byte> list = new List<byte>();
			list.Add(104);
			list.AddRange(BitConverter.GetBytes(baseAddress.ToInt32()));
			list.Add(104);
			list.AddRange(BitConverter.GetBytes(1));
			list.Add(104);
			list.AddRange(BitConverter.GetBytes(0));
			list.Add(184);
			list.AddRange(BitConverter.GetBytes(entrypoint));
			list.Add(byte.MaxValue);
			list.Add(208);
			list.Add(51);
			list.Add(192);
			list.Add(194);
			list.Add(4);
			list.Add(0);
			return this.ExecuteRemoteThreadBuffer(list.ToArray(), async);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000032E4 File Offset: 0x000014E4
		private bool ProcessTlsEntries(IntPtr baseAddress, IntPtr remoteAddress)
		{
			PIMAGE_NT_HEADERS32 ntHeader = this.GetNtHeader(baseAddress);
			if (ntHeader == null)
			{
				return false;
			}
			if (ntHeader.Value.OptionalHeader.TLSTable.Size == 0u)
			{
				return true;
			}
			PIMAGE_TLS_DIRECTORY32 pimage_TLS_DIRECTORY = (PIMAGE_TLS_DIRECTORY32)this.RvaToPointer(ntHeader.Value.OptionalHeader.TLSTable.VirtualAddress, baseAddress);
			if (pimage_TLS_DIRECTORY == null)
			{
				return true;
			}
			if (pimage_TLS_DIRECTORY.Value.AddressOfCallBacks == 0u)
			{
				return true;
			}
			byte[] array = new byte[1020];
			UIntPtr uintPtr;
			if (!Imports.ReadProcessMemory(this._hProcess, new IntPtr((long)((ulong)pimage_TLS_DIRECTORY.Value.AddressOfCallBacks)), array, out uintPtr))
			{
				return false;
			}
			PDWORD pdword = new PDWORD(array);
			bool flag = true;
			uint num = 0u;
			while (pdword[num] > 0u)
			{
				flag = this.CallEntryPoint(remoteAddress, pdword[num], false);
				if (!flag)
				{
					break;
				}
				num += 1u;
			}
			return flag;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000033B8 File Offset: 0x000015B8
		private IntPtr LoadImageToMemory(IntPtr baseAddress)
		{
			PIMAGE_NT_HEADERS32 ntHeader = this.GetNtHeader(baseAddress);
			if (ntHeader == null)
			{
				return IntPtr.Zero;
			}
			if (ntHeader.Value.FileHeader.NumberOfSections == 0)
			{
				return IntPtr.Zero;
			}
			uint num = uint.MaxValue;
			uint num2 = 0u;
			PIMAGE_SECTION_HEADER pimage_SECTION_HEADER = (PIMAGE_SECTION_HEADER)(ntHeader.Address + 24 + (int)ntHeader.Value.FileHeader.SizeOfOptionalHeader);
			for (uint num3 = 0u; num3 < (uint)ntHeader.Value.FileHeader.NumberOfSections; num3 += 1u)
			{
				if (pimage_SECTION_HEADER[num3].VirtualSize != 0u)
				{
					if (pimage_SECTION_HEADER[num3].VirtualAddress < num)
					{
						num = pimage_SECTION_HEADER[num3].VirtualAddress;
					}
					if (pimage_SECTION_HEADER[num3].VirtualAddress + pimage_SECTION_HEADER[num3].VirtualSize > num2)
					{
						num2 = pimage_SECTION_HEADER[num3].VirtualAddress + pimage_SECTION_HEADER[num3].VirtualSize;
					}
				}
			}
			uint size = num2 - num;
			if (ntHeader.Value.OptionalHeader.ImageBase % 4096u != 0u)
			{
				return IntPtr.Zero;
			}
			if (ntHeader.Value.OptionalHeader.DelayImportDescriptor.Size > 0u)
			{
				return IntPtr.Zero;
			}
			IntPtr intPtr = this.RemoteAllocateMemory(size);
			if (intPtr == IntPtr.Zero)
			{
				return IntPtr.Zero;
			}
			if (!this.ProcessImportTable(baseAddress))
			{
				return IntPtr.Zero;
			}
			if (!this.ProcessDelayedImportTable(baseAddress, intPtr))
			{
				return IntPtr.Zero;
			}
			if (!this.ProcessRelocations(baseAddress, intPtr))
			{
				return IntPtr.Zero;
			}
			if (!this.ProcessSections(baseAddress, intPtr))
			{
				return IntPtr.Zero;
			}
			if (!this.ProcessTlsEntries(baseAddress, intPtr))
			{
				return IntPtr.Zero;
			}
			if (ntHeader.Value.OptionalHeader.AddressOfEntryPoint > 0u)
			{
				int entrypoint = intPtr.ToInt32() + (int)ntHeader.Value.OptionalHeader.AddressOfEntryPoint;
				if (!this.CallEntryPoint(intPtr, (uint)entrypoint, this.AsyncInjection))
				{
					return IntPtr.Zero;
				}
			}
			return intPtr;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x0000359C File Offset: 0x0000179C
		private GCHandle PinBuffer(byte[] buffer)
		{
			return GCHandle.Alloc(buffer, GCHandleType.Pinned);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000035A5 File Offset: 0x000017A5
		private void FreeHandle(GCHandle handle)
		{
			if (handle.IsAllocated)
			{
				handle.Free();
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000035B8 File Offset: 0x000017B8
		private void OpenTarget()
		{
			this._hProcess = Imports.OpenProcess(this._process, Imports.ProcessAccessFlags.All);
			if (this._hProcess == IntPtr.Zero)
			{
				throw new Exception(string.Format("Failed to open handle. Error {0}", Marshal.GetLastWin32Error()));
			}
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00003607 File Offset: 0x00001807
		private void CloseTarget()
		{
			if (this._hProcess != IntPtr.Zero)
			{
				Imports.CloseHandle(this._hProcess);
				this._hProcess = IntPtr.Zero;
			}
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00003634 File Offset: 0x00001834
		public IntPtr Inject(byte[] buffer)
		{
			GCHandle handle = default(GCHandle);
			buffer = buffer.ToArray<byte>();
			IntPtr result = IntPtr.Zero;
			try
			{
				if (this._process == null || this._process.HasExited)
				{
					return result;
				}
				handle = this.PinBuffer(buffer);
				this.OpenTarget();
				result = this.LoadImageToMemory(handle.AddrOfPinnedObject());
			}
			catch (Exception)
			{
			}
			finally
			{
				this.FreeHandle(handle);
				this.CloseTarget();
			}
			return result;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000036C0 File Offset: 0x000018C0
		public IntPtr Inject(string file)
		{
			return this.Inject(File.ReadAllBytes(file));
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000036CE File Offset: 0x000018CE
		public ManualMapInjector(Process p)
		{
			this._process = p;
		}

		// Token: 0x04000003 RID: 3
		private readonly Process _process;

		// Token: 0x04000004 RID: 4
		private IntPtr _hProcess;
	}
}
