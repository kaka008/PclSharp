using PclSharp;
using PclSharp.IO;
using PclSharp.Vis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var cloud = new PointCloudOfXYZ())
            {
                //using (var reader = new PCDReader())
                //    reader.Read(@"E:\other\PclSharp\data\tutorials\table_scene_mug_stereo_textured.pcd", cloud);
                using (var reader = new PLYReader())
                    reader.Read(@"E:\vision\VisionMasterVision\src\Hatch3DVision\bin\x64\Debug\Output\Project1\job2\202111_25_15_57_18.ply", cloud);

                using (var writer = new PCDWriter())
                {

                    writer.Write(@"C:\Users\l4420\desktop\myply.pcd", cloud,false);

                }
                //for(int i=0; i<cloud.Count;i++)
                //{
                //    Console.WriteLine($"x:{cloud.Points[i].X} y:{cloud.Points[i].Y} z:{cloud.Points[i].Z}");
                //}

                using (var visualizer = new Visualizer("a window"))
                {
                    visualizer.AddPointCloud(cloud);
                    visualizer.SetPointCloudRenderingProperties(RenderingProperties.PointSize, 2);
                    visualizer.SetPointCloudRenderingProperties(RenderingProperties.Opacity, 1);
                    visualizer.SetBackgroundColor(0, 0, 55);
                    while (!visualizer.WasStopped)
                        visualizer.SpinOnce(100);
                }

            }
        }

        public static string DataPath(string path)
            => Path.Combine(@"E:\other\PclSharp\", "data", path);
    }
}
