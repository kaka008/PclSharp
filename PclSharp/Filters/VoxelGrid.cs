﻿// Code generated by a template
namespace PclSharp.Filters
{
	public abstract class VoxelGrid<PointT> : Filter<PointT>
	{
		public abstract (double min, double max) FilterLimits { get; set; }
		public abstract string FilterFieldName { get; set; }
		public abstract bool DownsampleAllData { get; set; }
		public abstract int MinimumPointsNumberPerVoxel { get; set; }
		public abstract Eigen.Vector3i MinBoxCoordinates { get; }
		public abstract Eigen.Vector3i MaxBoxCoordinates { get; }
		public abstract Eigen.Vector3i NrDivisions { get; }
		public abstract Eigen.Vector3i DivisionMultiplier { get; }
	}
}