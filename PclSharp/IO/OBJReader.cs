﻿// Code generated by a template
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using PclSharp.Struct;
using PclSharp.Std;
namespace PclSharp.IO
{
	public static partial class Invoke
	{
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern IntPtr io_objreader_ctor();
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void io_objreader_delete(ref IntPtr ptr);

		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern int io_objreader_read_xyz(IntPtr ptr, string fileName, IntPtr cloud, int offset);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern int io_objreader_read_xyzrgba(IntPtr ptr, string fileName, IntPtr cloud, int offset);
	}

	public class OBJReader : UnmanagedObject
	{
		public OBJReader()
		{
			_ptr = Invoke.io_objreader_ctor();
		}

		public int Read(string fileName, PointCloud<PointXYZ> cloud, int offset=0)
		{
			var res = Invoke.io_objreader_read_xyz(_ptr, fileName, cloud.Ptr, offset);
			return res;
		}

		public int Read(string fileName, PointCloud<PointXYZRGBA> cloud, int offset=0)
		{
			return Invoke.io_objreader_read_xyzrgba(_ptr, fileName, cloud, offset);
		}

		protected override void DisposeObject()
		{
			Invoke.io_objreader_delete(ref _ptr);
		}
	}
}