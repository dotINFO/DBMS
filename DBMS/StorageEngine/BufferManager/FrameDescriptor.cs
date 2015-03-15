﻿using System;

namespace DBMS.StorageEngine
{
	public class FrameDescriptor
	{
		public int FrameIndex;
		public bool Dirty = false;
		public int PinCount = 0;

		public FrameDescriptor (int frameIndex)
		{
			this.FrameIndex = frameIndex;
		}
	}
}

