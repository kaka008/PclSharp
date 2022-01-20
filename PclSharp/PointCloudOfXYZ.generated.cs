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
		public static extern IntPtr pointcloud_xyz_ctor();
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern IntPtr pointcloud_xyz_ctor_indices(IntPtr cloud, IntPtr indices);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern IntPtr pointcloud_xyz_ctor_wh(uint width, uint height);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void pointcloud_xyz_delete(ref IntPtr ptr);
		//methods
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern unsafe PointXYZ* pointcloud_xyz_at_colrow(IntPtr ptr, int col, int row);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void pointcloud_xyz_clear(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void pointcloud_xyz_resize(IntPtr ptr, Int32 size);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern unsafe void pointcloud_xyz_add(IntPtr ptr, PointXYZ* value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void pointcloud_xyz_downsample(IntPtr ptr, int factor, IntPtr output);
		//properties
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern UIntPtr pointcloud_xyz_size(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern IntPtr pointcloud_xyz_data(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern uint pointcloud_xyz_width(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void pointcloud_xyz_width_set(IntPtr ptr, uint width);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern uint pointcloud_xyz_height(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void pointcloud_xyz_height_set(IntPtr ptr, uint height);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern IntPtr pointcloud_xyz_points(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void pointcloud_xyz_setIsDense(IntPtr ptr, bool value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern bool pointcloud_xyz_getIsDense(IntPtr ptr);
		[return: MarshalAs(UnmanagedType.Bool)]
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern bool pointcloud_xyz_isOrganized(IntPtr ptr);
	}

	public unsafe class PointCloudOfXYZ : PointCloud<PointXYZ>
	{
		private bool _suppressDispose;

		public override int Width 
		{
			get { return (int)Invoke.pointcloud_xyz_width(_ptr); }
			set { Invoke.pointcloud_xyz_width_set(_ptr, (uint)value); }
		}
		public override int Height 
		{
			get { return (int)Invoke.pointcloud_xyz_height(_ptr); }
			set { Invoke.pointcloud_xyz_height_set(_ptr, (uint)value); }
		}
		public override bool IsDense
		{
			get { return Invoke.pointcloud_xyz_getIsDense(_ptr); }
            set { Invoke.pointcloud_xyz_setIsDense(_ptr, value); }
		}
		public override int Count => (int)Invoke.pointcloud_xyz_size(_ptr);
		public int Size => Count;
		public override bool IsOrganized => Invoke.pointcloud_xyz_isOrganized(_ptr);
		public PointXYZ* Data => (PointXYZ*)Invoke.pointcloud_xyz_data(_ptr);
		//此对象的Resize方法不可用，暂未找到解决办法(如果使用，会导致资源释放时报错问题)，替代方案为调用本类的Resize方法
		private VectorOfXYZ _points;
		//此对象的Resize方法不可用，暂未找到解决办法(如果使用，会导致资源释放时报错问题)，替代方案为调用本类的Resize方法
		public override Vector<PointXYZ> Points => _points;

		private PointCloudOfXYZ(IntPtr ptr)
		{
			_ptr = ptr;
			_points = new VectorOfXYZ(Invoke.pointcloud_xyz_points(_ptr));
		}

		internal PointCloudOfXYZ(IntPtr ptr, bool suppressDispose)
			:this(ptr)
		{
			_suppressDispose = suppressDispose;
		}

		public PointCloudOfXYZ() 
			: this(Invoke.pointcloud_xyz_ctor())
		{
		}

		public PointCloudOfXYZ(int width, int height)
			: this(Invoke.pointcloud_xyz_ctor_wh((uint)width, (uint)height))
		{
		}

		public PointCloudOfXYZ(PointCloudOfXYZ cloud, Std.VectorOfInt indices)
			:this (Invoke.pointcloud_xyz_ctor_indices(cloud.Ptr, indices.Ptr))
		{
		}

		public void Downsample(int factor, PointCloud<PointXYZ> output)
			=> Invoke.pointcloud_xyz_downsample(_ptr, factor, output);

		public override ref PointXYZ At(int col, int row)
			=>  ref Unsafe.AsRef<PointXYZ>(Invoke.pointcloud_xyz_at_colrow(_ptr, col, row));

		public override void Add(PointXYZ value)
			=> Invoke.pointcloud_xyz_add(_ptr, &value);
        public override void Resize(Int32 size)
			=> Invoke.pointcloud_xyz_resize(_ptr, size);

		protected override void DisposeObject()
		{
			if (_suppressDispose)
				return;
			Invoke.pointcloud_xyz_delete(ref _ptr);
		}
	}
}
