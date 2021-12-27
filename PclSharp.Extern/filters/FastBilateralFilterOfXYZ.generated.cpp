// Code generated by a template

#pragma once
#include "..\export.h"

#include "pcl\pcl_base.h"
#include "pcl\point_types.h"
#include <pcl/filters/fast_bilateral.h>

using namespace pcl;
using namespace std;

typedef FastBilateralFilter<PointXYZ> filter_t;
typedef boost::shared_ptr<PointCloud<PointXYZ>> boost_cloud;

#ifdef __cplusplus
extern "C" {
#endif 

EXPORT(filter_t*) filters_fastBilateralFilter_xyz_ctor()
{
	return new filter_t();
}

EXPORT(void) filters_fastBilateralFilter_xyz_delete(filter_t** ptr)
{
	delete *ptr;
	*ptr = NULL;
}

EXPORT(void) filters_fastBilateralFilter_xyz_filter(FastBilateralFilter<PointXYZ>* ptr, PointCloud<PointXYZ>* output)
{
	ptr->filter(*output);
}

EXPORT(void) filters_fastBilateralFilter_xyz_setInputCloud(FastBilateralFilter<PointXYZ>* ptr, PointCloud<PointXYZ>* cloud)
{
	ptr->setInputCloud(boost_cloud(boost_cloud(), cloud));
}
EXPORT(void) filters_fastBilateralFilter_xyz_setIndices(FastBilateralFilter<PointXYZ>* ptr, vector<int>* indices)
{
	ptr->setIndices(boost::shared_ptr<vector<int>>(boost::shared_ptr<vector<int>>(), indices));
}

EXPORT(void) filters_fastBilateralFilter_xyz_setSigmaS(FastBilateralFilter<PointXYZ>* ptr, float value)
{ ptr->setSigmaS(value); }
EXPORT(float) filters_fastBilateralFilter_xyz_getSigmaS(FastBilateralFilter<PointXYZ>* ptr)
{ return ptr->getSigmaS(); }

EXPORT(void) filters_fastBilateralFilter_xyz_setSigmaR(FastBilateralFilter<PointXYZ>* ptr, float value)
{ ptr->setSigmaR(value); }
EXPORT(float) filters_fastBilateralFilter_xyz_getSigmaR(FastBilateralFilter<PointXYZ>* ptr)
{ return ptr->getSigmaR(); }


#ifdef __cplusplus  
}
#endif  
