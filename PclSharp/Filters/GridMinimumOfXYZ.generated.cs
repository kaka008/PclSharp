// Code generated by a template
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using PclSharp.Struct;
using PclSharp.Std;
namespace PclSharp.Filters
{
	public static partial class Invoke
	{
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern IntPtr filters_gridMinimum_xyz_ctor(float resolution);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void filters_gridMinimum_xyz_delete(ref IntPtr ptr);
		//methods
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void filters_gridMinimum_xyz_filter(IntPtr ptr, IntPtr output);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void filters_gridMinimum_xyz_setInputCloud(IntPtr ptr, IntPtr cloud);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void filters_gridMinimum_xyz_setIndices(IntPtr ptr, IntPtr indices);

		//properties
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void filters_gridMinimum_xyz_setKeepOrganized(IntPtr ptr, bool value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern bool filters_gridMinimum_xyz_getKeepOrganized(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void filters_gridMinimum_xyz_setNegative(IntPtr ptr, bool value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern bool filters_gridMinimum_xyz_getNegative(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void filters_gridMinimum_xyz_setResolution(IntPtr ptr, float value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern float filters_gridMinimum_xyz_getResolution(IntPtr ptr);
	}

	public class GridMinimumOfXYZ : GridMinimum<PointXYZ>
	{
		public override float Resolution
		{
			get { return Invoke.filters_gridMinimum_xyz_getResolution(_ptr); }
            set { Invoke.filters_gridMinimum_xyz_setResolution(_ptr, value); }
		}

		public override bool Negative
		{
			get { return Invoke.filters_gridMinimum_xyz_getNegative(_ptr); }
            set { Invoke.filters_gridMinimum_xyz_setNegative(_ptr, value); }
		}

		public override bool KeepOrganized
		{
			get { return Invoke.filters_gridMinimum_xyz_getKeepOrganized(_ptr); }
            set { Invoke.filters_gridMinimum_xyz_setKeepOrganized(_ptr, value); }
		}

		public GridMinimumOfXYZ(float resolution=0.0f)
		{
			_ptr = Invoke.filters_gridMinimum_xyz_ctor(resolution);
		}

		public override void SetInputCloud(PointCloud<PointXYZ> cloud)
		{
			Invoke.filters_gridMinimum_xyz_setInputCloud(_ptr, cloud);
		}

		public override void filter(PointCloud<PointXYZ> output)
		{
			Invoke.filters_gridMinimum_xyz_filter(_ptr, output.Ptr);
		}

		public override void SetIndices(VectorOfInt indices)
		{
			Invoke.filters_gridMinimum_xyz_setIndices(_ptr, indices);
		}

		public override ref PointXYZ this[int idx]
		{
			get { return ref this.Index(idx); }
		}

		protected override void DisposeObject()
		{
			Invoke.filters_gridMinimum_xyz_delete(ref _ptr);
		}
	}
}
