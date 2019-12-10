using System;

namespace SortTriangles
{
    class Triangle: IShape, IComparable<Triangle>
    {
        private const int HALF_PERIMETER_DEVIDER = 2;

        public string Name { get; set; }
        public double LengthOfTheFirstSide { get; set; }
        public double LengthOfTheSecondSide { get; set; }
        public double LengthOfTheThirdSide { get; set; }
        public double Square { get;}

        public Triangle()
        {
            Name = "Name";
            LengthOfTheFirstSide = 1;
            LengthOfTheSecondSide = 1;
            LengthOfTheThirdSide = 1;
            Square = CountSquare();
        }

        public Triangle(string name, double lengthOfTheFirstSide, double lengthOfTheSecondSide, double lengthOfTheThirdSide)
        {
            Name = name;
            LengthOfTheFirstSide = lengthOfTheFirstSide;
            LengthOfTheSecondSide = lengthOfTheSecondSide;
            LengthOfTheThirdSide = lengthOfTheThirdSide;

            Square = CountSquare();
        }

        public bool IsExist()
        {
            bool result = false;

            if (LengthOfTheFirstSide + LengthOfTheSecondSide > LengthOfTheThirdSide 
                && LengthOfTheFirstSide + LengthOfTheThirdSide > LengthOfTheSecondSide
                && LengthOfTheSecondSide + LengthOfTheThirdSide > LengthOfTheFirstSide)
            {
                result = true;
            }

           result = false;

           return result;
        }

        public double CountSquare()
        {
            double halfPerimeter = (LengthOfTheFirstSide + LengthOfTheSecondSide + LengthOfTheThirdSide) / HALF_PERIMETER_DEVIDER;

            double square = Math.Sqrt(halfPerimeter * (halfPerimeter - LengthOfTheFirstSide) * (halfPerimeter - LengthOfTheSecondSide)
                                      * (halfPerimeter - LengthOfTheSecondSide));

            return square;
        }

        public int CompareTo(Triangle treangle)
        {
            int result = 0;

            if (Square > treangle.Square)
            {
                result = - 1;
            }
            else if (Square < treangle.Square)
            {
                result = 1;
            }
            else
            {
                result = 0;
            }

            return result;
        }

        public override string ToString()
        {
            string str = string.Format("Name of the triangle = " + Name + Environment.NewLine + "Square =  " + Square);

            return str;
        }

    }
}
