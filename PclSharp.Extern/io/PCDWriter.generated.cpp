// Code generated by a template
#pragma once
#include "..\export.h"
#include <pcl/io/pcd_io.h>

using namespace pcl;
using namespace std;

#ifdef __cplusplus
extern "C" {
#endif

EXPORT(PCDWriter*) io_pcdwriter_ctor()
{
	return new PCDWriter();
}

EXPORT(void) io_pcdwriter_delete(PCDWriter** ptr)
{
	delete *ptr;
	*ptr = NULL;
}

EXPORT(int32_t) io_pcdwriter_write_xyz(PCDWriter* ptr, const char* str, PointCloud<PointXYZ>* cloud, int* indices)
{
	return ptr->write(string(str), *cloud, *indices);
}
EXPORT(int32_t) io_pcdwriter_write_xyzrgba(PCDWriter* ptr, const char* str, PointCloud<PointXYZRGBA>* cloud, int* indices)
{ 
	return ptr->write(string(str), *cloud, *indices);
}


#ifdef __cplusplus  
}
#endif
