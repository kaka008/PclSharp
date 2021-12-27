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
                //writerTest(cloud);
                //PassThroughFilterTest(cloud);
                //RadiusOutlierRemovalFilterTest(cloud);
               // FastBilateralFilterTest(cloud);

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
        /// <summary>
        /// 点云的直通滤波器(给的X/Y/Z的名称和范围，取范围内或范围外的点云数据)
        /// </summary>
        /// <param name="cloud"></param>
        private static void PassThroughFilterTest(PointCloudOfXYZ cloud)
        {
            using (var filter = new PassThroughOfXYZ())
            {
                Console.WriteLine($"原始点云数量:{cloud.Points.Count}" );
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
                Console.WriteLine($"处理后点云数量:{cloudFiltered.Points.Count}");
                show(cloudFiltered);
            }


        }
        /// <summary>
        /// 按指定点云半径和数量的方法来过滤点云数据
        /// </summary>
        /// <param name="cloud"></param>
        private static void RadiusOutlierRemovalFilterTest(PointCloudOfXYZ cloud)
        {
            
            using (var filter = new RadiusOutlierRemovalOfXYZ())
            {
                Console.WriteLine($"原始点云数量:{cloud.Points.Count}" );
                PointCloudOfXYZ cloudFiltered = new PointCloudOfXYZ();
                filter.SetInputCloud(cloud);
                filter.MinNeighborsInRadius = 2;
                filter.RadiusSearch = 0.8;
                filter.filter(cloudFiltered);
                Console.WriteLine($"处理后点云数量:{cloudFiltered.Points.Count}");
                show(cloudFiltered);
            }
        }
        //需要输入结构化后的点云
        private static void FastBilateralFilterTest(PointCloudOfXYZ cloud)
        {
            using (var filter = new FastBilateralFilterOfXYZ())
            {
                Console.WriteLine($"原始点云数量:{cloud.Points.Count}");
                PointCloudOfXYZ cloudFiltered = new PointCloudOfXYZ();
                
                filter.SetInputCloud(cloud);
                filter.SigmaS = 20.0f;
                filter.SigmaR = 0.8f;
                filter.filter(cloudFiltered);
                Console.WriteLine($"处理后点云数量:{cloudFiltered.Points.Count}");
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
