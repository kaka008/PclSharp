// Code generated by a template
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using PclSharp.Struct;
using PclSharp.Std;

namespace PclSharp.Features
{
	public static partial class Invoke
	{
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern IntPtr features_fpfhestimation_pointxyzandnormal_ctor();
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void features_fpfhestimation_pointxyzandnormal_delete(ref IntPtr ptr);

		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void features_fpfhestimation_pointxyzandnormal_setInputCloud(IntPtr ptr, IntPtr cloud);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void features_fpfhestimation_pointxyzandnormal_setInputNormals(IntPtr ptr, IntPtr normals);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void features_fpfhestimation_pointxyzandnormal_setIndices(IntPtr ptr, IntPtr indices);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void features_fpfhestimation_pointxyzandnormal_compute(IntPtr ptr, IntPtr cloud);

		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void features_fpfhestimation_pointxyzandnormal_setKSearch(IntPtr ptr, int value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern int features_fpfhestimation_pointxyzandnormal_getKSearch(IntPtr ptr);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void features_fpfhestimation_pointxyzandnormal_setRadiusSearch(IntPtr ptr, double value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern double features_fpfhestimation_pointxyzandnormal_getRadiusSearch(IntPtr ptr);

		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void features_fpfhestimation_pointxyzandnormal_getNrSubdivisions(IntPtr ptr, ref int f1, ref int f2, ref int f3);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void features_fpfhestimation_pointxyzandnormal_setNrSubdivisions(IntPtr ptr, int f1, int f2, int f3);
	}

	public class FPFHEstimationOfPointXYZAndNormal : FPFHEstimation<PointXYZ, Normal>
	{
		public override (int f1, int f2, int f3) NrSubdivisions 
		{
			get
			{
				int f1 = 0;
				int f2 = 0;
				int f3 = 0;
				Invoke.features_fpfhestimation_pointxyzandnormal_getNrSubdivisions(_ptr, ref f1, ref f2, ref f3);
				return (f1, f2, f3);
			}
			set { Invoke.features_fpfhestimation_pointxyzandnormal_setNrSubdivisions(_ptr, value.f1, value.f2, value.f3); }
		}

		public override int KSearch 
		{ 
			get { return Invoke.features_fpfhestimation_pointxyzandnormal_getKSearch(_ptr); }
            set { Invoke.features_fpfhestimation_pointxyzandnormal_setKSearch(_ptr, value); } 
		}

        public override double RadiusSearch 
		{ 
			get { return Invoke.features_fpfhestimation_pointxyzandnormal_getRadiusSearch(_ptr); }
            set { Invoke.features_fpfhestimation_pointxyzandnormal_setRadiusSearch(_ptr, value); } 
		}

		public FPFHEstimationOfPointXYZAndNormal()
		{
			_ptr = Invoke.features_fpfhestimation_pointxyzandnormal_ctor();
		}

		public override void SetInputCloud(PointCloud<PointXYZ> cloud) 
			=> Invoke.features_fpfhestimation_pointxyzandnormal_setInputCloud(_ptr, cloud.Ptr);

		public override void SetIndices(VectorOfInt indices)
			=> Invoke.features_fpfhestimation_pointxyzandnormal_setIndices(_ptr, indices);

		public override ref PointXYZ this[int idx]
		{
			get { return ref this.Index(idx); }
		}

		public override void Compute(PointCloud<FPFHSignature33> cloud) 
			=> Invoke.features_fpfhestimation_pointxyzandnormal_compute(_ptr, cloud.Ptr);

		public override void SetInputNormals(PointCloud<Normal> normals)
			=> Invoke.features_fpfhestimation_pointxyzandnormal_setInputNormals(_ptr, normals);

		protected override void DisposeObject()
			=> Invoke.features_fpfhestimation_pointxyzandnormal_delete(ref _ptr);
	}
}
