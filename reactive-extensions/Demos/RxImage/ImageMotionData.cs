using System;
using CoreGraphics;

namespace RxImage
{
	public class ImageMotionData
	{
		public CGPoint ParentCoordinate {
			get;
			set;
		}
			
		public CGPoint ImageCoordinate {
			get;
			set;
		}
			
		public CGPoint PreviousParentCoordinate {
			get;
			set;
		}
			
		public CGPoint PreviousImageCoordinate {
			get;
			set;
		}
	}
}

