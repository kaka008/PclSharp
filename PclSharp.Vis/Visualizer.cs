using PclSharp.Struct;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace PclSharp.Vis
{
    public static partial class Invoke
    {
        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        public static extern IntPtr visualizer_ctor(string name, bool createInteractor);
        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        public static extern void visualizer_delete(ref IntPtr ptr);

        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        public static extern void visualizer_setBackgroundColor(IntPtr ptr, byte r, byte g, byte b);

        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        public static extern void visualizer_addPointCloud_xyz(IntPtr ptr, IntPtr cloud, string name, int viewport);
        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        public static extern void visualizer_addPointCloud_xyzrgba(IntPtr ptr, IntPtr cloud, string name, int viewport);

        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        public static extern void visualizer_setPointCloudRenderingProperties_1x(IntPtr ptr, int property, double value, string name, int viewport);
        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        public static extern void visualizer_addCoordinateSystem(IntPtr ptr, double scale, float x, float y, float z, int viewport);

        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool visualizer_addText(IntPtr ptr, String text, int x, int y, int fontsize, double r, double g, double b, String id = "", int viewport = 0);


        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool visualizer_addText3D(IntPtr ptr, String text, PointXYZ position, double textScale, double r, double g, double b, String id = "", int viewport = 0);

        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool visualizer_addSphere(IntPtr ptr, PointXYZ center, double radius, double r, double g, double b, String id = "sphere", int viewport = 0);
        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool visualizer_addCube(IntPtr ptr, float x_min, float x_max, float y_min, float y_max, float z_min, float z_max, double r = 1.0, double g = 1.0, double b = 1.0, string id = "cube", int viewport = 0);
        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        public static extern void visualizer_setCameraPosition(IntPtr ptr, double pos_x, double pos_y, double pos_z, double up_x, double up_y, double up_z, int viewport = 0);

        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        public static extern void visualizer_setCameraPositionWithView(IntPtr ptr, double pos_x, double pos_y, double pos_z, double view_x, double view_y, double view_z, double up_x, double up_y, double up_z, int viewport = 0);

        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        public static extern void visualizer_spin(IntPtr ptr);
        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        public static extern void visualizer_spinOnce(IntPtr ptr, int time, bool forceRedraw);

        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        public static extern bool visualizer_contains(IntPtr ptr, string id);

        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        public static extern bool visualizer_wasStopped(IntPtr ptr);
    }

    public class Visualizer : UnmanagedObject
    {
        public Visualizer(string windowName = "", bool createInteractor = true)
        {
            _ptr = Invoke.visualizer_ctor(windowName, createInteractor);
        }

        public void SetBackgroundColor(byte r, byte g, byte b)
            => Invoke.visualizer_setBackgroundColor(_ptr, r, g, b);

        public void AddPointCloud(PointCloud<PointXYZ> cloud, string name = "cloud", int viewport = 0)
            => Invoke.visualizer_addPointCloud_xyz(_ptr, cloud, name, viewport);

        public void AddPointCloud(PointCloud<PointXYZRGBA> cloud, string name = "cloud", int viewport = 0)
            => Invoke.visualizer_addPointCloud_xyzrgba(_ptr, cloud, name, viewport);

        public void SetPointCloudRenderingProperties(RenderingProperties property, double value, string name = "cloud", int viewport = 0)
            => Invoke.visualizer_setPointCloudRenderingProperties_1x(_ptr, (int)property, value, name, viewport);
        public void AddCoordinateSystem(double scale = 1.0, float x = 0, float y = 0, float z = 0, int viewport = 0)
        {
            Invoke.visualizer_addCoordinateSystem(_ptr, scale, x, y, z, viewport);
        }
        public bool AddText(String text, int x, int y, int fontsize = 5, double r = 1.0, double g = 1.0, double b = 1.0, String id = "h", int viewport = 0)
        {
            return Invoke.visualizer_addText(_ptr, text, x, y, fontsize, r, g, b, id, viewport);
        }
        public bool AddText3D(String text, PointXYZ position, double textScale = 1.0, double r = 1.0, double g = 1.0, double b = 1.0, String id = "", int viewport = 0)
        {
            return Invoke.visualizer_addText3D(_ptr, text, position, textScale, r, g, b, id, viewport);
        }
        public bool AddSphere(PointXYZ center, double radius = 1.0, double r = 1.0, double g = 1.0, double b = 1.0, String id = "sphere", int viewport = 0)
        {
            return Invoke.visualizer_addSphere(_ptr, center, radius, r, g, b, id, viewport);
        }
        public bool AddCube(float x_min, float x_max, float y_min, float y_max, float z_min, float z_max, double r = 1.0, double g = 1.0, double b = 1.0, string id = "cube", int viewport = 0)
        {
            return Invoke.visualizer_addCube(_ptr, x_min, x_max, y_min, y_max, z_min, z_max, r, g, b, id, viewport);
        }
        public void SetCameraPosition(double pos_x, double pos_y, double pos_z, double up_x, double up_y, double up_z, int viewport = 0)
        {
            Invoke.visualizer_setCameraPosition(_ptr, pos_x, pos_y, pos_z, up_x, up_y, up_z, viewport);
        }
        public void SetCameraPosition(double pos_x, double pos_y, double pos_z, double view_x, double view_y, double view_z, double up_x, double up_y, double up_z, int viewport = 0)
        {
            Invoke.visualizer_setCameraPositionWithView(_ptr, pos_x, pos_y, pos_z, view_x, view_y, view_z, up_x, up_y, up_z, viewport);
        }

        public void Spin()
            => Invoke.visualizer_spin(_ptr);

        public void SpinOnce(int time = 1, bool forceRedraw = false)
            => Invoke.visualizer_spinOnce(_ptr, time, forceRedraw);

        public bool Contains(string id)
            => Invoke.visualizer_contains(_ptr, id);

        public bool WasStopped
            => Invoke.visualizer_wasStopped(_ptr);

        protected override void DisposeObject()
        {
            Invoke.visualizer_delete(ref _ptr);
        }
    }
}
