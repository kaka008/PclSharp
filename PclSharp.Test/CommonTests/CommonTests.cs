using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PclSharp.Common;
using PclSharp.IO;
using static PclSharp.Test.TestData;

namespace PclSharp.Test.CommonTests
{
    [TestClass]
    public class CommonTests
    {
        string filePath = DataPath("tutorials/box.ply");
        string organisedfilePath = DataPath("tutorials/region_growing_rgb_tutorial.pcd");
        PointCloudOfXYZ cloud = new PointCloudOfXYZ();
        PointCloudOfXYZ organisedCloud = new PointCloudOfXYZ();

        public CommonTests()
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
        [TestMethod]
        public  void TransformTest()
        {
            PointCloudOfXYZ cloudTransformed = new PointCloudOfXYZ();

            PclSharp.Eigen.Matrix4f mtx = new PclSharp.Eigen.Matrix4f();
            mtx[0, 0] = 0.0f;
            mtx[0, 1] = -1.0f;
            mtx[0, 2] = 0.0f;
            mtx[0, 3] = -80.0f;

            mtx[1, 0] = 0.0f;
            mtx[1, 1] = 0.0f;
            mtx[1, 2] = -1.0f;
            mtx[1, 3] = -200.0f;

            mtx[2, 0] = 1.0f;
            mtx[2, 1] = 0.0f;
            mtx[2, 2] = 0.0f;
            mtx[2, 3] = 4000.0f;

            mtx[3, 0] = 0.0f;
            mtx[3, 1] = 0.0f;
            mtx[3, 2] = 0.0f;
            mtx[3, 3] = 1.0f;

            Transforms.TransformPointCloud(cloud, ref cloudTransformed, mtx);
            Assert.AreEqual(cloudTransformed.Points.Count,cloud.Points.Count);
            Assert.AreNotEqual(cloud.Points[0].X, cloudTransformed.Points[0].X);
            Assert.AreNotEqual(cloud.Points[0].Y, cloudTransformed.Points[0].Y);
            Assert.AreNotEqual(cloud.Points[0].Z, cloudTransformed.Points[0].Z);

            cloudTransformed.Dispose();
        }



    }
}
