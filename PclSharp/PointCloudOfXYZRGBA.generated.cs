// Code generated by a template
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using PclSharp.Struct;
using PclSharp.Std;
using System.Runtime.CompilerServices;

namespace PclSharp
{
	public static partial class Invoke
	{
		//ctor/dctor
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern IntPtr pointcloud_xyzrgba_ctor();
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern IntPtr pointcloud_xyzrgba_ctor_indices(IntPtr cloud, IntPtr indices);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern IntPtr pointcloud_xyzrgba_ctor_wh(uint width, uint height);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void pointcloud_xyzrgba_delete(ref IntPtr ptr);
		//methods
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern unsafe PointXYZRGBA* pointcloud_xyzrgba_at_colrow(IntPtr ptr, int col, int row);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void pointcloud_xyzrgba_clear(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void pointcloud_xyzrgba_resize(IntPtr ptr, Int32 size);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern unsafe void pointcloud_xyzrgba_add(IntPtr ptr, PointXYZRGBA* value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void pointcloud_xyzrgba_downsample(IntPtr ptr, int factor, IntPtr output);
		//properties
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern UIntPtr pointcloud_xyzrgba_size(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern IntPtr pointcloud_xyzrgba_data(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern uint pointcloud_xyzrgba_width(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void pointcloud_xyzrgba_width_set(IntPtr ptr, uint width);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern uint pointcloud_xyzrgba_height(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void pointcloud_xyzrgba_height_set(IntPtr ptr, uint height);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern IntPtr pointcloud_xyzrgba_points(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void pointcloud_xyzrgba_setIsDense(IntPtr ptr, bool value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern bool pointcloud_xyzrgba_getIsDense(IntPtr ptr);
		[return: MarshalAs(UnmanagedType.Bool)]
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern bool pointcloud_xyzrgba_isOrganized(IntPtr ptr);
	}

	public unsafe class PointCloudOfXYZRGBA : PointCloud<PointXYZRGBA>
	{
		private bool _suppressDispose;

		public override int Width 
		{
			get { return (int)Invoke.pointcloud_xyzrgba_width(_ptr); }
			set { Invoke.pointcloud_xyzrgba_width_set(_ptr, (uint)value); }
		}
		public override int Height 
		{
			get { return (int)Invoke.pointcloud_xyzrgba_height(_ptr); }
			set { Invoke.pointcloud_xyzrgba_height_set(_ptr, (uint)value); }
		}
		public override bool IsDense
		{
			get { return Invoke.pointcloud_xyzrgba_getIsDense(_ptr); }
            set { Invoke.pointcloud_xyzrgba_setIsDense(_ptr, value); }
		}
		public override int Count => (int)Invoke.pointcloud_xyzrgba_size(_ptr);
		public int Size => Count;
		public override bool IsOrganized => Invoke.pointcloud_xyzrgba_isOrganized(_ptr);
		public PointXYZRGBA* Data => (PointXYZRGBA*)Invoke.pointcloud_xyzrgba_data(_ptr);
		//此对象的Resize方法不可用，暂未找到解决办法(如果使用，会导致资源释放时报错问题)，替代方案为调用本类的Resize方法
		private VectorOfXYZRGBA _points;
		//此对象的Resize方法不可用，暂未找到解决办法(如果使用，会导致资源释放时报错问题)，替代方案为调用本类的Resize方法
		public override Vector<PointXYZRGBA> Points => _points;

		private PointCloudOfXYZRGBA(IntPtr ptr)
		{
			_ptr = ptr;
			_points = new VectorOfXYZRGBA(Invoke.pointcloud_xyzrgba_points(_ptr));
		}

		internal PointCloudOfXYZRGBA(IntPtr ptr, bool suppressDispose)
			:this(ptr)
		{
			_suppressDispose = suppressDispose;
		}

		public PointCloudOfXYZRGBA() 
			: this(Invoke.pointcloud_xyzrgba_ctor())
		{
		}

		public PointCloudOfXYZRGBA(int width, int height)
			: this(Invoke.pointcloud_xyzrgba_ctor_wh((uint)width, (uint)height))
		{
		}

		public PointCloudOfXYZRGBA(PointCloudOfXYZRGBA cloud, Std.VectorOfInt indices)
			:this (Invoke.pointcloud_xyzrgba_ctor_indices(cloud.Ptr, indices.Ptr))
		{
		}

		public void Downsample(int factor, PointCloud<PointXYZRGBA> output)
			=> Invoke.pointcloud_xyzrgba_downsample(_ptr, factor, output);

		public override ref PointXYZRGBA At(int col, int row)
			=>  ref Unsafe.AsRef<PointXYZRGBA>(Invoke.pointcloud_xyzrgba_at_colrow(_ptr, col, row));

		public override void Add(PointXYZRGBA value)
			=> Invoke.pointcloud_xyzrgba_add(_ptr, &value);
        public override void Resize(Int32 size)
			=> Invoke.pointcloud_xyzrgba_resize(_ptr, size);

		protected override void DisposeObject()
		{
			if (_suppressDispose)
				return;
			Invoke.pointcloud_xyzrgba_delete(ref _ptr);
		}
	}
}
