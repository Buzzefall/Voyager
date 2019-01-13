﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using OptiSolver.Data;
using OptiSolver.Algorithms;

namespace OptiSolver
{
    public class Application
    {
        public static void Main(string[] args)
        {
            using (var reader = new StreamReader("Input/Cities.txt", Encoding.UTF8, false))
            {
                if (reader.EndOfStream)
                {
                    TSPSolver.BranchAndBound();
                }
                else
                {
                    var matrix = new List<IEnumerable<int>>();
                    while (!reader.EndOfStream)
                    {
                        var row = reader.ReadLine()?.Split(' ').Select(int.Parse);
                        matrix.Add(new List<int>(row ?? throw new InvalidOperationException()));
                    }

                    var transportMatrix = matrix.Select(row => row.ToArray()).ToArray();
                    TSPSolver.BranchAndBound(transportMatrix);
                }
            }

        }
    }
}