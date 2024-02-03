#region
#endregion

Point.PointsFactory.NewCartesianPoint(3, 2);


public class Point
{
	private double _x, _y;

	private Point(double y, double x)
	{
		_y = y;
		_x = x;
	}
	
	public override string ToString()
	{
		return $"{nameof(_x)}: {_x}, {nameof(_y)}: {_y}";
	}
	
	public class PointsFactory //Factory
	{
		public static Point NewCartesianPoint(double x, double y) //Factory method
		{
			return new Point(x, y);
		}

		public static Point NewPolarPoint(double rho, double theta) //Factory method
		{
			return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
		}
	}
}

