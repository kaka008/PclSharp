// Code generated by a template
#pragma once
#include "..\export.h"

#include "pcl\pcl_base.h"
#include "pcl\point_types.h"

using namespace pcl;
using namespace std;

typedef vector<Normal, Eigen::aligned_allocator<Normal>> point_vector;

#ifdef __cplusplus  
extern "C" {  // only need to export C interface if  
			  // used by C++ source code  
#endif  

EXPORT(PointCloud<Normal>*) pointcloud_normal_ctor()
{
	return new PointCloud<Normal>();
}

EXPORT(PointCloud<Normal>*) pointcloud_normal_ctor_wh(uint32_t width, uint32_t height)
{
	return new PointCloud<Normal>(width, height);
}

EXPORT(PointCloud<Normal>*) pointcloud_normal_ctor_indices(PointCloud<Normal>* cloud, vector<int>* indices)
{
	if (indices == NULL)
		return new PointCloud<Normal>(*cloud);
	else
		return new PointCloud<Normal>(*cloud, *indices);
}

EXPORT(void) pointcloud_normal_delete(PointCloud<Normal>** ptr)
{
	delete *ptr;
	*ptr = NULL;
}

EXPORT(Normal*) pointcloud_normal_at_colrow(PointCloud<Normal>* ptr, int col, int row)
{
	return &ptr->at(col, row);
}

EXPORT(void) pointcloud_normal_add(PointCloud<Normal>* ptr, Normal* value)
{
	//the value needs to be aligned to be pushed into the cloud, so do that.
	Normal deref;
	memcpy(&deref, value, sizeof(Normal));
	ptr->push_back(deref);
}

EXPORT(size_t) pointcloud_normal_size(PointCloud<Normal>* ptr)
{
	return ptr->size();
}

EXPORT(void) pointcloud_normal_clear(PointCloud<Normal>* ptr)
{
	ptr->clear();
}

EXPORT(uint32_t) pointcloud_normal_width(PointCloud<Normal>* ptr)
{
	return ptr->width;
}

EXPORT(void) pointcloud_normal_width_set(PointCloud<Normal>* ptr, uint32_t width)
{
	ptr->width = width;
}

EXPORT(uint32_t) pointcloud_normal_height(PointCloud<Normal>* ptr)
{
	return ptr->height;
}

EXPORT(void) pointcloud_normal_height_set(PointCloud<Normal>* ptr, uint32_t height)
{
	ptr->height = height;
}

EXPORT(int32_t) pointcloud_normal_isOrganized(PointCloud<Normal>* ptr)
{
	return ptr->isOrganized();
}

EXPORT(point_vector*) pointcloud_normal_points(PointCloud<Normal>* ptr)
{
	return &ptr->points;
}

EXPORT(Normal*) pointcloud_normal_data(PointCloud<Normal>* ptr)
{
	return ptr->points.data();
}

EXPORT(void) pointcloud_normal_downsample(PointCloud<Normal>* ptr, int factor, PointCloud<Normal>* output)
{
	if (output->width != ptr->width/factor ||
		output->height != ptr->height/factor)
	{
		output->resize(ptr->width/factor * ptr->height/factor);
		output->width = ptr->width/factor;
		output->height = ptr->height/factor;
		output->is_dense = ptr->is_dense;
	}

	if (factor == 1)
	{
		output->points = ptr->points;
		return;
	}

	auto ow = output->width;
	auto oh = output->height;
	auto iw = ptr->width;

	auto oarr = output->points.data();
	auto iarr = ptr->points.data();

	for(size_t c = 0; c < ow; c++)
	{
		for(size_t r = 0; r < oh; r++)
		{
			oarr[r * ow + c] = iarr[r * factor * iw + c * factor];
		}
	}
}

EXPORT(void) pointcloud_normal_setIsDense(PointCloud<Normal>* ptr, int value)
{ ptr->is_dense = value; }
EXPORT(int) pointcloud_normal_getIsDense(PointCloud<Normal>* ptr)
{ return ptr->is_dense; }

#ifdef __cplusplus  
}
#endif  
