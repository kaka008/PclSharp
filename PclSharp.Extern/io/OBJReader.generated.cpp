// Code generated by a template
#pragma once
#include "..\export.h"
#include <pcl/io/obj_io.h>

using namespace pcl;
using namespace std;

#ifdef __cplusplus
extern "C" {
#endif

EXPORT(OBJReader*) io_objreader_ctor()
{
	return new OBJReader();
}

EXPORT(void) io_objreader_delete(OBJReader** ptr)
{
	delete *ptr;
	*ptr = NULL;
}

EXPORT(int32_t) io_objreader_read_xyz(OBJReader* ptr, const char* str, PointCloud<PointXYZ>* cloud, int offset)
{
	return ptr->read(string(str), *cloud, offset);
}
EXPORT(int32_t) io_objreader_read_xyzrgba(OBJReader* ptr, const char* str, PointCloud<PointXYZRGBA>* cloud, int offset)
{ return ptr->read(string(str), *cloud, offset); }


#ifdef __cplusplus  
}
#endif