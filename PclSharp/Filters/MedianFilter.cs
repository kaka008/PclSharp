﻿// Code generated by a template
using PclSharp.Std;
using PclSharp.Search;
namespace PclSharp.Filters
{
	public abstract class MedianFilter<PointT> : Filter<PointT>
	{
	    public abstract int WindowSize  { get; set; }
		public abstract float MaxAllowedMovement { get; set; }
	}
}
