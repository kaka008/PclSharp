// Code generated by a template
#pragma once
#include "..\export.h"

#include "pcl\pcl_base.h"
#include "pcl\point_types.h"
#include <pcl/features/integral_image_normal.h>

using namespace pcl;
using namespace std;

typedef IntegralImageNormalEstimation<PointXYZ, Normal> integral_image;
typedef std::shared_ptr<PointCloud<PointXYZ>> std_cloud;
typedef std::shared_ptr<vector<int>> std_indices;

#ifdef __cplusplus  
extern "C" {  // only need to export C interface if  
			  // used by C++ source code  
#endif 

EXPORT(integral_image*) features_integralImageNormalEstimation_pointxyzandnormal_ctor()
{
	return new integral_image();
}

EXPORT(void) features_integralImageNormalEstimation_pointxyzandnormal_delete(integral_image** ptr)
{
	delete *ptr;
	*ptr = NULL;
}

EXPORT(void) features_integralImageNormalEstimation_pointxyzandnormal_setRectSize(IntegralImageNormalEstimation<PointXYZ, Normal>* ptr, int width, int height)
{
	ptr->setRectSize(width, height);
}
EXPORT(void) features_integralImageNormalEstimation_pointxyzandnormal_setBorderPolicy(IntegralImageNormalEstimation<PointXYZ, Normal>* ptr, integral_image::BorderPolicy policy)
{
	ptr->setBorderPolicy(policy);
}
EXPORT(void) features_integralImageNormalEstimation_pointxyzandnormal_setNormalEstimationMethod(IntegralImageNormalEstimation<PointXYZ, Normal>* ptr, integral_image::NormalEstimationMethod method)
{
	ptr->setNormalEstimationMethod(method);
}
EXPORT(void) features_integralImageNormalEstimation_pointxyzandnormal_setMaxDepthChangeFactor(IntegralImageNormalEstimation<PointXYZ, Normal>* ptr, float factor)
{
	ptr->setMaxDepthChangeFactor(factor);
}
EXPORT(void) features_integralImageNormalEstimation_pointxyzandnormal_setNormalSmoothingSize(IntegralImageNormalEstimation<PointXYZ, Normal>* ptr, float size)
{
	ptr->setNormalSmoothingSize(size);
}

EXPORT(void) features_integralImageNormalEstimation_pointxyzandnormal_setInputCloud(IntegralImageNormalEstimation<PointXYZ, Normal>* ptr, PointCloud<PointXYZ>* cloud)
{ ptr->setInputCloud(std_cloud(std_cloud(), cloud)); }

EXPORT(void) features_integralImageNormalEstimation_pointxyzandnormal_setIndices(IntegralImageNormalEstimation<PointXYZ, Normal>* ptr, std::vector<int>* indices)
{ ptr->setIndices(std_indices(std_indices(), indices)); }

EXPORT(void) features_integralImageNormalEstimation_pointxyzandnormal_compute(IntegralImageNormalEstimation<PointXYZ, Normal>* ptr, PointCloud<Normal>* cloud)
{ ptr->compute(*cloud); }

EXPORT(void) features_integralImageNormalEstimation_pointxyzandnormal_setKSearch(IntegralImageNormalEstimation<PointXYZ, Normal>* ptr, int value)
{ ptr->setKSearch(value); }
EXPORT(int) features_integralImageNormalEstimation_pointxyzandnormal_getKSearch(IntegralImageNormalEstimation<PointXYZ, Normal>* ptr)
{ return ptr->getKSearch(); }
EXPORT(void) features_integralImageNormalEstimation_pointxyzandnormal_setRadiusSearch(IntegralImageNormalEstimation<PointXYZ, Normal>* ptr, double value)
{ ptr->setRadiusSearch(value); }
EXPORT(double) features_integralImageNormalEstimation_pointxyzandnormal_getRadiusSearch(IntegralImageNormalEstimation<PointXYZ, Normal>* ptr)
{ return ptr->getRadiusSearch(); }

#ifdef __cplusplus  
}
#endif  
