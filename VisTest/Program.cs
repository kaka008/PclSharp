using PclSharp;
using PclSharp.Filters;
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
                using (var reader = new PCDReader())
                    reader.Read(@"C:\Users\l4420\Desktop\myply.pcd", cloud);
              // writerTest(cloud);
               filterTest(cloud);


            }
        }
        /// <summary>
        /// 测试写文件
        /// </summary>
        /// <param name="cloud"></param>
        private static void writerTest(PointCloudOfXYZ cloud)
        {

            using (var writer = new PCDWriter())
            {

                writer.Write(@"c:\users\l4420\desktop\myply.pcd", cloud, true);

            }
            for (int i = 0; i < cloud.Count; i++)
            {
                Console.WriteLine($"x:{cloud.Points[i].X} y:{cloud.Points[i].Y} z:{cloud.Points[i].Z}");
            }
        }

        private static void filterTest(PointCloudOfXYZ cloud)
        {
            using (var filter = new PassthroughOfXYZ())
            {
                PointCloudOfXYZ cloudFiltered = new PointCloudOfXYZ();
                filter.SetInputCloud(cloud);
                filter.SetFilterFieldName("x");
                Console.WriteLine($"FilterFieldName:{filter.GetFilterFieldName()}");
                filter.SetFilterLimits(0.0f,120f);
                filter.FilterLimitsNegative = false;
                filter.filter(cloudFiltered);
                filter.SetInputCloud(cloudFiltered);
                filter.SetFilterFieldName("y");
                filter.SetFilterLimits(0.0f, 70f);
                Console.WriteLine($"FilterFieldName:{filter.GetFilterFieldName()}");
                filter.filter(cloudFiltered);
                float min=0, max = 0;
                filter.GetFilterLimits(ref min,ref max);
                Console.WriteLine($"min:{min},max:{max}");
                show(cloudFiltered);
            }


        }
        private static void show(PointCloudOfXYZ cloud)
        {
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

        public static string DataPath(string path)
            => Path.Combine(@"E:\other\PclSharp\", "data", path);
    }
}
