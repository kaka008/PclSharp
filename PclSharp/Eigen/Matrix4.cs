﻿// Code generated by a template
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Numerics;

namespace PclSharp.Eigen
{
	public static unsafe partial class Invoke
	{
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern IntPtr eigen_matrix4_f_ctor();
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void eigen_matrix4_f_delete(ref IntPtr ptr);

		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern float eigen_matrix4_f_getIndex(IntPtr ptr, int row, int col);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void eigen_matrix4_f_setIndex(IntPtr ptr, int row, int col, float value);

		//properties
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern float* eigen_matrix4_f_data(IntPtr ptr);
	}

    public class Matrix4f : UnmanagedObject
    {
		public unsafe float* Data => Invoke.eigen_matrix4_f_data(_ptr);

		public Matrix4f()
		{
			_ptr = Invoke.eigen_matrix4_f_ctor();
		}

		/// <summary>
        /// Copy from an existing Matrix4x4
        /// </summary>
        /// <param name="m">matrix to copy</param>
		public unsafe Matrix4f(Matrix4x4 m)
			: this()
        {
            var start = &m.M11;
            for (int row = 0, i = 0; row < 4; row++)
                for (int col = 0; col < 4; col++, i++)
                    this[row, col] = start[i];
        }

		public float this[int row, int col]
		{
			get { return Invoke.eigen_matrix4_f_getIndex(_ptr, row, col); }
			set { Invoke.eigen_matrix4_f_setIndex(_ptr, row, col, value); }
		}

        protected override void DisposeObject()
        {
            Invoke.eigen_matrix4_f_delete(ref _ptr);
        }
    }
}
