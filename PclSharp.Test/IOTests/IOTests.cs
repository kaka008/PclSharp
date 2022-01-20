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
    public class IOTests
    {
        public string pcdfilePath = DataPath("tutorials/ism_test_horse.pcd");
        public string plyfilePath = DataPath("tutorials/box.ply");
        public IOTests()
        {

        }
        [TestMethod]
        public void PCDReaderAndWriterTest()
        {
            using (var cloud = new PointCloudOfXYZ())
            using (var writer = new PCDWriter())
            using (var pcdReader = new PCDReader())
            {
                if (pcdReader.Read(pcdfilePath, cloud) < 0)
                {
                    Assert.Fail("读取点云失败！");
                }
                Assert.AreEqual(3400, cloud.Width);
                Assert.AreEqual(1, cloud.Height);
                if (writer.Write("test.pcd", cloud) < 0)
                {
                    Assert.Fail("写入点云失败！");
                }
                if (writer.Write("test.pcd", cloud, true) < 0)
                {
                    Assert.Fail("以二进制写入点云失败！");
                }
            }
        }
        [TestMethod]
        public void PLYReaderAndWriterTest()
        {
            using (var cloud = new PointCloudOfXYZ())
            using (var writer = new PLYWriter())
            using (var plyReader = new PLYReader())
            {
                if (plyReader.Read(plyfilePath, cloud) < 0)
                {
                    Assert.Fail("读取点云失败！");
                }
                Assert.AreEqual(10500, cloud.Width);
                Assert.AreEqual(1, cloud.Height);
                if (writer.Write("test.ply", cloud) < 0)
                {
                    Assert.Fail("写入点云失败！");
                }
                if (writer.Write("test.ply", cloud, true) < 0)
                {
                    Assert.Fail("以二进制写入点云失败！");
                }
            }
        }


    }
}
