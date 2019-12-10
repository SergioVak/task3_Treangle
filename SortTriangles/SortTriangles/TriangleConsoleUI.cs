using System;
using System.Collections.Generic;


namespace SortTriangles
{
    class TriangleConsoleUI
    {
        private const int COUNT_START_ARGS = 0;
        private const int POSITIVE_COUNT_OF_ARGS = 4;

        private TriangleValidator validator = new TriangleValidator();

        private List<Triangle> triangleList = new List<Triangle>();

        public void ShowMenu(string[] args)
        {
            if(args.Length == COUNT_START_ARGS)
            {
                bool startAgain = false;

                do
                {
                    try
                    {
                        startAgain = false;

                        Console.WriteLine("Enter name and three sides for a new triangle(separ '.'):");

                        string[] input = Console.ReadLine().Split(new char[] {'.' });

                        if (input.Length == POSITIVE_COUNT_OF_ARGS)
                        {
                            string name = input[0].ToLower();
                            float lengthOfTheFirstSide = float.Parse(input[1]);
                            float lengthOfTheSecondSide = float.Parse(input[2]);
                            float lengthOfTheThirdSide = float.Parse(input[3]);

                            Triangle triangle = new Triangle(name, lengthOfTheFirstSide, lengthOfTheSecondSide, lengthOfTheThirdSide);

                            if (validator.Validate(triangle).IsValid)
                            {
                                triangleList.Add(triangle);
                            }
                            else
                            {
                                Console.WriteLine("Incorrect sides for triangle");
                                //log
                            }
                        }
                        else
                        {
                            Console.WriteLine("Not enough parameters for building triangle!");
                            //log
                        }
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.ToString());

                        //log
                    }

                    catch (NullReferenceException ex)
                    {
                        Console.WriteLine(ex.ToString());

                        //log
                    }

                    catch (IndexOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.ToString());

                        //log
                    }
                    finally
                    {
                        SortTriangles();
                        ShowTriangles();
                        startAgain = IsContinueRunningProgramm();
                    }
                }
                while (startAgain);
            }
        
        }

        private void SortTriangles()
        {
            triangleList.Sort();
        }

        private void ShowTriangles()
        {
            Console.WriteLine("============= Triangles list: ===============");

            foreach (var triangle in triangleList)
            {
                Console.WriteLine(triangle.ToString());
                Console.WriteLine();
            }
        }

        private static bool IsContinueRunningProgramm()
        {
            Console.WriteLine("For continue print y or yes:");

            string answer = Console.ReadLine().ToLower();

            bool result = false;

            if(answer == "y" | answer == "yes")
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }
    }
}
