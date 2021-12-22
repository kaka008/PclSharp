﻿// Code generated by a template
using PclSharp.SampleConsensus;
using PclSharp.Common;

namespace PclSharp.Segmentation
{
	public abstract class SACSegmentation<PointT> : PclBase<PointT>
	{
		public abstract SACModel ModelType { get; set; }
		public abstract int MaxIterations { get; set; }
		public abstract SACMethod MethodType { get; set; }
		public abstract double DistanceThreshold { get; set; }

		public abstract void Segment(PointIndices inliers, ModelCoefficients coefficients);
	}
}
