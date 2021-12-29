// Code generated by a template
#pragma once
#include "..\export.h"

#include "pcl\pcl_base.h"
#include "pcl\point_types.h"
#include <pcl/search/organized.h>

using namespace pcl::search;
using namespace std;

typedef pcl::PointXYZ PointXYZ;
typedef OrganizedNeighbor<PointXYZ> search_t;
typedef std::shared_ptr<pcl::PointCloud<PointXYZ>> std_cloud;

#ifdef __cplusplus
extern "C" {
#endif 

EXPORT(search_t*) search_organizedNeighbor_xyz_ctor(int sorted, float eps, uint32_t pyramidLevel)
{
	return new search_t(sorted, eps, pyramidLevel);
}

EXPORT(void) search_organizedNeighbor_xyz_delete(search_t** ptr)
{
	delete *ptr;
	*ptr = NULL;
}

EXPORT(void) search_organizedNeighbor_xyz_setInputCloud(OrganizedNeighbor<PointXYZ>* ptr, pcl::PointCloud<PointXYZ>* cloud)
{
	ptr->setInputCloud(std_cloud(std_cloud(), cloud));
}

EXPORT(void) search_organizedNeighbor_xyz_setSortedResults(OrganizedNeighbor<PointXYZ>* ptr, int value)
{ ptr->setSortedResults(value); }
EXPORT(int) search_organizedNeighbor_xyz_getSortedResults(OrganizedNeighbor<PointXYZ>* ptr)
{ return ptr->getSortedResults(); }

#ifdef __cplusplus  
}
#endif  
