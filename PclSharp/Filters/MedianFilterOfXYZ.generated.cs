// Code generated by a template
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using PclSharp.Struct;
using PclSharp.Std;
using PclSharp.Search;
namespace PclSharp.Filters
{
	public static partial class Invoke
	{
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern IntPtr filters_medianFilter_xyz_ctor();
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void filters_medianFilter_xyz_delete(ref IntPtr ptr);
		//methods
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void filters_medianFilter_xyz_filter(IntPtr ptr, IntPtr output);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void filters_medianFilter_xyz_setInputCloud(IntPtr ptr, IntPtr cloud);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void filters_medianFilter_xyz_setIndices(IntPtr ptr, IntPtr indices);


		//properties
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void filters_medianFilter_xyz_setWindowSize(IntPtr ptr, int value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern int filters_medianFilter_xyz_getWindowSize(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void filters_medianFilter_xyz_setMaxAllowedMovement(IntPtr ptr, float value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern float filters_medianFilter_xyz_getMaxAllowedMovement(IntPtr ptr);
	}

	public class MedianFilterOfXYZ :MedianFilter<PointXYZ>
	{
		public override int WindowSize
		{
			get { return Invoke.filters_medianFilter_xyz_getWindowSize(_ptr); }
            set { Invoke.filters_medianFilter_xyz_setWindowSize(_ptr, value); }
		}

		public override float MaxAllowedMovement
		{
			get { return Invoke.filters_medianFilter_xyz_getMaxAllowedMovement(_ptr); }
            set { Invoke.filters_medianFilter_xyz_setMaxAllowedMovement(_ptr, value); }
		}


		public MedianFilterOfXYZ()
		{
			_ptr = Invoke.filters_medianFilter_xyz_ctor();
		}

		public override void SetInputCloud(PointCloud<PointXYZ> cloud)
		{
			Invoke.filters_medianFilter_xyz_setInputCloud(_ptr, cloud);
		}

		public override void filter(PointCloud<PointXYZ> output)
		{
			Invoke.filters_medianFilter_xyz_filter(_ptr, output.Ptr);
		}

		public override void SetIndices(VectorOfInt indices)
		{
			Invoke.filters_medianFilter_xyz_setIndices(_ptr, indices);
		}

		public override ref PointXYZ this[int idx]
		{
			get { return ref this.Index(idx); }
		}

		protected override void DisposeObject()
		{
			Invoke.filters_medianFilter_xyz_delete(ref _ptr);
		}
	}
}
