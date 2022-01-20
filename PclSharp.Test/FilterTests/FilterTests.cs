using PclSharp.Filters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PclSharp.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PclSharp.Test.TestData;

namespace PclSharp.Test
{
    
    [TestClass]
    public class FilterTests
    {
        string filePath = DataPath("tutorials/box.ply");
        string organisedfilePath = DataPath("tutorials/region_growing_rgb_tutorial.pcd");
        PointCloudOfXYZ cloud = new PointCloudOfXYZ();
        PointCloudOfXYZ organisedCloud = new PointCloudOfXYZ();

        public FilterTests()
        {
            using (var pcdReader = new PCDReader())
            using (PLYReader reader = new PLYReader())
            {
                if (reader.Read(filePath, cloud) < 0)
                {
                    Assert.Fail("读取点云失败");
                }
                if (pcdReader.Read(organisedfilePath, organisedCloud) < 0)
                {
                    Assert.Fail("读取点云失败");
                }
            }
        }
         ~FilterTests()
        {
            cloud.Dispose();
        }
        
        /// <summary>
        /// 点云的直通滤波器(给的X/Y/Z的名称和范围，取范围内或范围外的点云数据)
        /// </summary>
        /// <param name="cloud"></param>
        [TestMethod]
        public void PassThroughFilterTest()
        {
            using (var cloudFiltered = new PointCloudOfXYZ())
            using (var filter = new PassThroughOfXYZ())
            {
                float min = 0, max = 0;
                filter.SetInputCloud(cloud);
                filter.SetFilterFieldName("x");
                filter.SetFilterLimits(320.0f, 324.0f);
                filter.FilterLimitsNegative = false;
                filter.GetFilterLimits(ref min, ref max);
                Assert.AreEqual(320.0, min);
                Assert.AreEqual(324.0, max);
                filter.filter(cloudFiltered);
                filter.SetInputCloud(cloudFiltered);
                filter.SetFilterFieldName("y");
                filter.SetFilterLimits(50.0f, 106.0f);
                filter.filter(cloudFiltered);
                
                filter.GetFilterLimits(ref min, ref max);                
                Assert.AreEqual(50.0, min);
                Assert.AreEqual(106.0, max);
                Assert.AreEqual(cloudFiltered.Size, 50);
            }
        }

        /// <summary>
        /// 按指定点云半径和数量的方法来过滤点云数据
        /// </summary>
        /// <param name="cloud"></param>
        [TestMethod]
        public  void RadiusOutlierRemovalFilterTest()
        {           
            using (var cloudFiltered = new PointCloudOfXYZ())
            using (var filter = new RadiusOutlierRemovalOfXYZ())
            {
                Console.WriteLine($"原始点云数量:{cloud.Points.Count}");
                Assert.AreEqual(cloud.Points.Count, 10500);
                filter.SetInputCloud(cloud);
                filter.MinNeighborsInRadius = 2;
                filter.RadiusSearch = 0.8;
                filter.filter(cloudFiltered);
                Assert.AreEqual(cloudFiltered.Points.Count,9628);
            }
        }

        [TestMethod]
        public  void GridMinimumFilterTest()
        {
            using (var filter = new GridMinimumOfXYZ(0.2f))
            {
                Console.WriteLine($"GridMinimumFilter原始点云数量:{cloud.Points.Count}");
                PointCloudOfXYZ cloudFiltered = new PointCloudOfXYZ();

                filter.SetInputCloud(cloud);

                filter.filter(cloudFiltered);
                Console.WriteLine($"GridMinimumFilter处理后点云数量:{cloudFiltered.Points.Count}");
                Assert.AreEqual(cloudFiltered.Points.Count,8711);
                cloudFiltered.Dispose();
            }
        }
        [TestMethod]
        public void LocalMaximumFilterTest()
        {
            using (var filter = new LocalMaximumOfXYZ())
            {
                Console.WriteLine($"LocalMaximumFilter原始点云数量:{cloud.Points.Count}");
                PointCloudOfXYZ cloudFiltered = new PointCloudOfXYZ();

                filter.SetInputCloud(cloud);
                filter.Radius = 2;
                filter.filter(cloudFiltered);
                Console.WriteLine($"LocalMaximumFilter处理后点云数量:{cloudFiltered.Points.Count}");
                Assert.AreEqual(cloudFiltered.Points.Count, 5479);
                cloudFiltered.Dispose();
            }
        }
        //需要输入结构化后的点云
        [TestMethod]
        public void MedianFilterTest()
        {
            using (var filter = new MedianFilterOfXYZ())
            {
                PointCloudOfXYZ cloudFiltered = new PointCloudOfXYZ();
                filter.WindowSize = 20;
                filter.MaxAllowedMovement = 100.0f;
                filter.SetInputCloud(organisedCloud);
                filter.filter(cloudFiltered);
                Console.WriteLine($"处理后点云数量:{cloudFiltered.Points.Count}");

            }
        }
        //需要输入结构化后的点云
        [TestMethod]
        public void FastBilateralFilterTest()
        {
            using (var filter = new FastBilateralFilterOfXYZ())
            {
                Console.WriteLine($"FastBilateralFilter原始点云数量:{organisedCloud.Points.Count}");
                PointCloudOfXYZ cloudFiltered = new PointCloudOfXYZ();

                filter.SetInputCloud(organisedCloud);
                filter.SigmaS = 1.0f;
                filter.SigmaR = 0.8f;
                filter.filter(cloudFiltered);
                Console.WriteLine($"FastBilateralFilter处理后点云数量:{cloudFiltered.Points.Count}");
                Assert.AreEqual(cloudFiltered.Points.Count,307200);
                cloudFiltered.Dispose();
            }
        }


    }

}
