// TestCppMethod.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include <iostream>
#include "pcl/impl/point_types.hpp"
#include "pcl\pcl_base.h"
#include "pcl\point_cloud.h"
#include <pcl/filters/passthrough.h>
#include <pcl/io/pcd_io.h>
#include <pcl/surface/convex_hull.h>
#include <pcl/visualization/pcl_visualizer.h>

#include <pcl/console/parse.h>
#include <pcl/point_types.h>
#include <pcl/segmentation/supervoxel_clustering.h>
#include <vtkPolyLine.h>    //  这句需要添加，否则会报错
#include <pcl/surface/impl/mls.hpp>

using namespace pcl;
using namespace std;
// Types
typedef pcl::PointXYZRGBA PointT;
typedef pcl::PointCloud<PointT> PointCloudT;
typedef pcl::PointNormal PointNT;
typedef pcl::PointCloud<PointNT> PointNCloudT;
typedef pcl::PointXYZL PointLT;
typedef pcl::PointCloud<PointLT> PointLCloudT;

typedef std::shared_ptr<PointCloud<PointXYZ>> std_cloud;




typedef PassThrough<PointXYZ> filter_t;

void addSupervoxelConnectionsToViewer(PointT& supervoxel_center,
	PointCloudT& adjacent_supervoxel_centers,
	std::string supervoxel_name,
	boost::shared_ptr<pcl::visualization::PCLVisualizer>& viewer);

void static passthroughTest(pcl::PointCloud<pcl::PointXYZ>::Ptr cloud, pcl::PointCloud<pcl::PointXYZ>::Ptr& cloud_after_PassThrough, float rangelow, float rangehigh, string dimension) {

	//方法1：直通滤波器对点云处理
	//pcl::PointCloud<pcl::PointXYZ>::Ptr cloud_after_PassThrough(new pcl::PointCloud<pcl::PointXYZ>);
	pcl::PassThrough<pcl::PointXYZ> passthrough;
	passthrough.setInputCloud(cloud);//输入点云
	passthrough.setFilterFieldName(dimension);//对z轴进行操作
	passthrough.setFilterLimits(rangelow, rangehigh);//设置直通滤波器操作范围
	//passthrough.setFilterLimitsNegative(true);//true表示保留范围内，false表示保留范围外
	passthrough.filter(*cloud_after_PassThrough);//执行滤波，过滤结果保存在 cloud_after_PassThrough
	passthrough.setFilterFieldName("y");
	passthrough.setFilterLimits(0, 100);
	passthrough.filter(*cloud_after_PassThrough);
}
void static ConvexHullTest()
{
	pcl::PointCloud<pcl::PointXYZ>::Ptr cloud(new pcl::PointCloud<pcl::PointXYZ>);
	pcl::io::loadPCDFile<pcl::PointXYZ>("bun_45.pcd", *cloud);

	pcl::ConvexHull<pcl::PointXYZ> hull;
	hull.setInputCloud(cloud);
	hull.setDimension(3);  // 设置凸包维度
	hull.setComputeAreaVolume(true);

	std::vector<pcl::Vertices> polygons;
	// polygons保存的是所有凸包多边形的顶点在surface_hull中的下标
	pcl::PointCloud<pcl::PointXYZ>::Ptr surface_hull(new pcl::PointCloud<pcl::PointXYZ>);
	// surface_hull是所有凸包多边形的顶点
	hull.reconstruct(*surface_hull, polygons);
	//凸包点云存放在surface_hull中,polygons中的Vertices存放一组点的索引，索引是surface_hull中的点对应的索引

	double convex_volume = hull.getTotalVolume();

	cout << surface_hull->size() << endl;
	cout << "凸包体积： " << convex_volume << endl;

	// ---------------------- Visualizer -------------------------------------------
	boost::shared_ptr<pcl::visualization::PCLVisualizer> viewer(new pcl::visualization::PCLVisualizer);
	viewer->setBackgroundColor(255, 255, 255);

	pcl::visualization::PointCloudColorHandlerCustom<pcl::PointXYZ> color_handler(cloud, 255, 255, 0);
	viewer->addPointCloud(cloud, color_handler, "sample cloud");
	viewer->setPointCloudRenderingProperties(pcl::visualization::PCL_VISUALIZER_POINT_SIZE, 6, "sample cloud");

	pcl::visualization::PointCloudColorHandlerCustom<pcl::PointXYZ> color_handlerK(surface_hull, 255, 0, 0);
	viewer->addPointCloud(surface_hull, color_handlerK, "point");
	viewer->setPointCloudRenderingProperties(pcl::visualization::PCL_VISUALIZER_POINT_SIZE, 6, "point");

	//viewer->addPolygon<pcl::PointXYZ>(surface_hull, 0, 0, 255, "polyline");

	while (!viewer->wasStopped())
	{
		viewer->spinOnce(100);
	}
}



//int main()
//{
//	pcl::PointCloud<pcl::PointXYZ>* cloud = new pcl::PointCloud<pcl::PointXYZ>();
//	pcl::PointCloud<pcl::PointXYZ>* filteredCloud = new pcl::PointCloud<pcl::PointXYZ>();
//	pcl::PCDReader reader = pcl::PCDReader();
//	reader.read("C:\\Users\\l4420\\Desktop\\myply.pcd", *cloud);
//
//	//PassThrough<PointXYZ> filter = PassThrough<PointXYZ>();
//	//filter.setInputCloud(std_cloud(std_cloud(), cloud));
//	//filter.setFilterFieldName("x");
//	//filter.setFilterLimits(0.0f, 120.0f);
//	//filter.setFilterLimitsNegative(false);
//
//	//filter.filter(*filteredCloud);
//
//	//delete cloud;
//	//cloud = NULL;
//	//delete filteredCloud;
//	pcl::PointCloud<pcl::PointXYZ>::Ptr  pt = std_cloud(std_cloud(),cloud);
//	pcl::PointCloud<pcl::PointXYZ>::Ptr  pt1 = std_cloud(std_cloud(), filteredCloud);
//
//	passthroughTest(pt, pt1, 0.0f, 120.0f, "x");
//	//filteredCloud->points.clear();
//	//filteredCloud->points.resize(0);
//	//filteredCloud->clear();
//	//filteredCloud->resize(0);
//	delete filteredCloud;
//	delete cloud;
//
//	ConvexHullTest();
//}




// Types
typedef pcl::PointXYZRGBA PointT;
typedef pcl::PointCloud<PointT> PointCloudT;
typedef pcl::PointNormal PointNT;
typedef pcl::PointCloud<PointNT> PointNCloudT;
typedef pcl::PointXYZL PointLT;
typedef pcl::PointCloud<PointLT> PointLCloudT;

int
main(int argc, char** argv)
{
	//if (argc < 2)
	//{
	//	pcl::console::print_error("Syntax is: %s <pcd-file> \n "
	//		"--NT Dsables the single cloud transform \n"
	//		"-v <voxel resolution>\n-s <seed resolution>\n"
	//		"-c <color weight> \n-z <spatial weight> \n"
	//		"-n <normal_weight>\n", argv[0]);
	//	return (1);
	//}

	PointCloudT::Ptr cloud(new PointCloudT);
	pcl::console::print_highlight("Loading point cloud...\n");
	if (pcl::io::loadPCDFile<pcl::PointXYZRGBA>("E:/other/pcl/test/milk_cartoon_all_small_clorox.pcd", *cloud))
	{
		pcl::console::print_error("Error loading cloud file!\n");
		return (1);
	}


	bool use_transform = !pcl::console::find_switch(argc, argv, "--NT");

	float voxel_resolution = 0.008f;
	bool voxel_res_specified = pcl::console::find_switch(argc, argv, "-v");
	if (voxel_res_specified)
		pcl::console::parse(argc, argv, "-v", voxel_resolution);

	float seed_resolution = 0.1f;
	bool seed_res_specified = pcl::console::find_switch(argc, argv, "-s");
	if (seed_res_specified)
		pcl::console::parse(argc, argv, "-s", seed_resolution);

	float color_importance = 0.2f;
	if (pcl::console::find_switch(argc, argv, "-c"))
		pcl::console::parse(argc, argv, "-c", color_importance);

	float spatial_importance = 0.4f;
	if (pcl::console::find_switch(argc, argv, "-z"))
		pcl::console::parse(argc, argv, "-z", spatial_importance);

	float normal_importance = 1.0f;
	if (pcl::console::find_switch(argc, argv, "-n"))
		pcl::console::parse(argc, argv, "-n", normal_importance);

	//  //
	// This is how to use supervoxels
	//  //

	pcl::SupervoxelClustering<pcl::PointXYZRGBA> super(voxel_resolution, seed_resolution);
	super.setInputCloud(cloud);
	super.setColorImportance(color_importance);
	super.setSpatialImportance(spatial_importance);
	super.setNormalImportance(normal_importance);

	std::map <uint32_t, pcl::Supervoxel<PointT>::Ptr > supervoxel_clusters;

	pcl::console::print_highlight("Extracting supervoxels!\n");
	super.extract(supervoxel_clusters);
	pcl::console::print_info("Found %d supervoxels\n", supervoxel_clusters.size());

	boost::shared_ptr<pcl::visualization::PCLVisualizer> viewer(new pcl::visualization::PCLVisualizer("3D Viewer"));
	viewer->setBackgroundColor(0, 0, 0);

	PointCloudT::Ptr voxel_centroid_cloud = super.getVoxelCentroidCloud();
	viewer->addPointCloud(voxel_centroid_cloud, "voxel centroids");
	viewer->setPointCloudRenderingProperties(pcl::visualization::PCL_VISUALIZER_POINT_SIZE, 2.0, "voxel centroids");
	viewer->setPointCloudRenderingProperties(pcl::visualization::PCL_VISUALIZER_OPACITY, 0.95, "voxel centroids");

	PointCloudT::Ptr colored_voxel_cloud = super.getVoxelCentroidCloud();
	viewer->addPointCloud(colored_voxel_cloud, "colored voxels");
	viewer->setPointCloudRenderingProperties(pcl::visualization::PCL_VISUALIZER_OPACITY, 0.8, "colored voxels");

	PointNCloudT::Ptr sv_normal_cloud = super.makeSupervoxelNormalCloud(supervoxel_clusters);
	//We have this disabled so graph is easy to see, uncomment to see supervoxel normals
	//viewer->addPointCloudNormals<PointNormal> (sv_normal_cloud,1,0.05f, "supervoxel_normals");

	pcl::console::print_highlight("Getting supervoxel adjacency\n");
	std::multimap<uint32_t, uint32_t> supervoxel_adjacency;
	super.getSupervoxelAdjacency(supervoxel_adjacency);
	//To make a graph of the supervoxel adjacency, we need to iterate through the supervoxel adjacency multimap
	std::multimap<uint32_t, uint32_t>::iterator label_itr = supervoxel_adjacency.begin();
	for (; label_itr != supervoxel_adjacency.end(); )
	{
		//First get the label
		uint32_t supervoxel_label = label_itr->first;
		//Now get the supervoxel corresponding to the label
		pcl::Supervoxel<PointT>::Ptr supervoxel = supervoxel_clusters.at(supervoxel_label);

		//Now we need to iterate through the adjacent supervoxels and make a point cloud of them
		PointCloudT adjacent_supervoxel_centers;
		std::multimap<uint32_t, uint32_t>::iterator adjacent_itr = supervoxel_adjacency.equal_range(supervoxel_label).first;
		for (; adjacent_itr != supervoxel_adjacency.equal_range(supervoxel_label).second; ++adjacent_itr)
		{
			pcl::Supervoxel<PointT>::Ptr neighbor_supervoxel = supervoxel_clusters.at(adjacent_itr->second);
			adjacent_supervoxel_centers.push_back(neighbor_supervoxel->centroid_);
		}
		//Now we make a name for this polygon
		std::stringstream ss;
		ss << "supervoxel_" << supervoxel_label;
		//This function is shown below, but is beyond the scope of this tutorial - basically it just generates a "star" polygon mesh from the points given
		addSupervoxelConnectionsToViewer(supervoxel->centroid_, adjacent_supervoxel_centers, ss.str(), viewer);
		//Move iterator forward to next label
		label_itr = supervoxel_adjacency.upper_bound(supervoxel_label);
	}

	while (!viewer->wasStopped())
	{
		viewer->spinOnce(100);
	}
	return (0);
}


void
addSupervoxelConnectionsToViewer(PointT& supervoxel_center,
	PointCloudT& adjacent_supervoxel_centers,
	std::string supervoxel_name,
	boost::shared_ptr<pcl::visualization::PCLVisualizer>& viewer)
{
	vtkSmartPointer<vtkPoints> points = vtkSmartPointer<vtkPoints>::New();
	vtkSmartPointer<vtkCellArray> cells = vtkSmartPointer<vtkCellArray>::New();
	vtkSmartPointer<vtkPolyLine> polyLine = vtkSmartPointer<vtkPolyLine>::New();

	//Iterate through all adjacent points, and add a center point to adjacent point pair
	PointCloudT::iterator adjacent_itr = adjacent_supervoxel_centers.begin();
	for (; adjacent_itr != adjacent_supervoxel_centers.end(); ++adjacent_itr)
	{
		points->InsertNextPoint(supervoxel_center.data);
		points->InsertNextPoint(adjacent_itr->data);
	}
	// Create a polydata to store everything in
	vtkSmartPointer<vtkPolyData> polyData = vtkSmartPointer<vtkPolyData>::New();
	// Add the points to the dataset
	polyData->SetPoints(points);
	polyLine->GetPointIds()->SetNumberOfIds(points->GetNumberOfPoints());
	for (unsigned int i = 0; i < points->GetNumberOfPoints(); i++)
		polyLine->GetPointIds()->SetId(i, i);
	cells->InsertNextCell(polyLine);
	// Add the lines to the dataset
	polyData->SetLines(cells);
	viewer->addModelFromPolyData(polyData, supervoxel_name);
}



// 运行程序: Ctrl + F5 或调试 >“开始执行(不调试)”菜单
// 调试程序: F5 或调试 >“开始调试”菜单

// 入门使用技巧: 
//   1. 使用解决方案资源管理器窗口添加/管理文件
//   2. 使用团队资源管理器窗口连接到源代码管理
//   3. 使用输出窗口查看生成输出和其他消息
//   4. 使用错误列表窗口查看错误
//   5. 转到“项目”>“添加新项”以创建新的代码文件，或转到“项目”>“添加现有项”以将现有代码文件添加到项目
//   6. 将来，若要再次打开此项目，请转到“文件”>“打开”>“项目”并选择 .sln 文件




