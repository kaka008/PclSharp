// Code generated by a template
#pragma once
#include "..\export.h"

#include "pcl\pcl_base.h"
#include "pcl\point_types.h"
#include <pcl/filters/median_filter.h>

using namespace pcl;
using namespace std;

typedef MedianFilter<PointXYZ> filter_t;
typedef std::shared_ptr<PointCloud<PointXYZ>> std_cloud;

#ifdef __cplusplus
extern "C" {
#endif 

EXPORT(filter_t*) filters_medianFilter_xyz_ctor()
{
	return new filter_t();
}

EXPORT(void) filters_medianFilter_xyz_delete(filter_t** ptr)
{
	delete *ptr;
	*ptr = NULL;
}

EXPORT(void) filters_medianFilter_xyz_filter(MedianFilter<PointXYZ>* ptr, PointCloud<PointXYZ>* output)
{
	ptr->filter(*output);
}

EXPORT(void) filters_medianFilter_xyz_setInputCloud(MedianFilter<PointXYZ>* ptr, PointCloud<PointXYZ>* cloud)
{
	ptr->setInputCloud(std_cloud(std_cloud(), cloud));
}
EXPORT(void) filters_medianFilter_xyz_setIndices(MedianFilter<PointXYZ>* ptr, vector<int>* indices)
{
	ptr->setIndices(std::shared_ptr<vector<int>>(std::shared_ptr<vector<int>>(), indices));
}

EXPORT(void) filters_medianFilter_xyz_setWindowSize(MedianFilter<PointXYZ>* ptr, int value)
{ ptr->setWindowSize(value); }
EXPORT(int) filters_medianFilter_xyz_getWindowSize(MedianFilter<PointXYZ>* ptr)
{ return ptr->getWindowSize(); }

EXPORT(void) filters_medianFilter_xyz_setMaxAllowedMovement(MedianFilter<PointXYZ>* ptr, float value)
{ ptr->setMaxAllowedMovement(value); }
EXPORT(float) filters_medianFilter_xyz_getMaxAllowedMovement(MedianFilter<PointXYZ>* ptr)
{ return ptr->getMaxAllowedMovement(); }


#ifdef __cplusplus  
}
#endif  
