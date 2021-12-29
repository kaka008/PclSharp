// Code generated by a template
#pragma once
#include "..\export.h"
#include <pcl/io/ply_io.h>
#include <pcl/point_types.h>

using namespace pcl;
using namespace std;

#ifdef __cplusplus
extern "C" {
#endif

EXPORT(PLYWriter*) io_plywriter_ctor()
{
	return new PLYWriter();
}

EXPORT(void) io_plywriter_delete(PLYWriter** ptr)
{
	delete *ptr;
	*ptr = NULL;
}

EXPORT(int32_t) io_plywriter_write_xyz(PLYWriter* ptr, const char* str, PointCloud<PointXYZ>* cloud, bool binary)
{
	return ptr->write(string(str), *cloud, binary);
}
EXPORT(int32_t) io_plywriter_write_xyzrgba(PLYWriter* ptr, const char* str, PointCloud<PointXYZRGBA>* cloud, bool binary)
{ 
	return ptr->write(string(str), *cloud, binary);
}


#ifdef __cplusplus  
}
#endif
