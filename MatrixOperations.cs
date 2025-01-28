using System;
using Microsoft.Extensions.Logging;

namespace OpenTelemetryConsoleApp
{
    public class MatrixOperations
    {
        private readonly ILogger _logger;

        public MatrixOperations(ILogger logger)
        {
            _logger = logger;
        }

        public int[,] SumMatrices(int[,] matrix1, int[,] matrix2)
        {
            int rows = matrix1.GetLength(0);
            int cols = matrix1.GetLength(1);
            int[,] result = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            _logger.LogError("Matrices have been summed.");

            return result;
        }

        public void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }

            _logger.LogWarning("Matrix has been printed.");
        }
    }
}
