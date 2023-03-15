using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2_Marushchak
{
    /// <summary>
    /// Клас для роботи з двовимірними масивами
    /// </summary>
    class CharacteristicMatrix
    {
        #region поля
        int[,] matrix;
        int[] absolutRowsSum;
        #endregion

        #region властивості та індексатори
        /// <summary>
        /// Кількість рядків матриці
        /// </summary>
        public int RowCount { get; set; }
        /// <summary>
        /// Кількість стовпців матриці
        /// </summary>
        public int ColCount { get; set; }
        /// <summary>
        /// Масив зі значеннями абсолютної суми елементів кожного рядка
        /// </summary>
        public int[] AbsolutRowsSum
        {
            get
            {
                if (absolutRowsSum == null)
                    СomputeAbsolutRowsSum();
                return absolutRowsSum;
            }
        }
        /// <summary>
        /// Індексатор для отримання значення елементів масиву за індексом
        /// </summary>
        public int this[int i, int j]
        {
            get
            {
                if (i < RowCount && i >= 0 && j < ColCount && j >= 0)
                    return matrix[i, j];
                else throw new IndexOutOfRangeException("Індекс виходить за межі масиву!");
            }
        }
        #endregion
        #region конструктори
        /// <summary>
        /// Конструктор класу
        /// </summary>
        public CharacteristicMatrix(int rows, int cols)
        {
            matrix = new int[rows, cols];
            RowCount = matrix.GetLength(0);
            ColCount = matrix.GetLength(1);
        }
        #endregion
        #region методи
        /// <summary>
        /// Заповнює елементи масиву випадковими числами
        /// </summary>
        /// <param name="min">мінімальне значення елементу</param>
        /// <param name="to">максимальне значення елементу</param>
        public void FillElementsRandom(int min, int max)
        {
            Random rand = new Random();
            for (int i = 0; i < RowCount; i++)
                for (int j = 0; j < ColCount; j++)
                    matrix[i, j] = rand.Next(min, max + 1);
        }
        /// <summary>
        /// Шукає перший стовпець, що не містять відємних елементів
        /// </summary>
        /// <returns>повертає індекс стовпця або -1, якщо такого стовпця не знайдено</returns>
public int IndexOfFirstPositiveColumn()
        {
            for (int i = 0; i < ColCount; i++)
            {
                int positiveElementsCount = 0;
                for (int j = 0; j < RowCount; j++)
                {
                    if (matrix[j, i] >= 0)
                        positiveElementsCount++;
                    else
                        break;
                }
                if (positiveElementsCount == RowCount)
                    return i;
            }
            return -1;
        }
        /// <summary>
        /// Сортування рядків матриці за зростанням
        /// суми абсолютних значень елементів рядків
        /// </summary>
        public void SortRowsByCharacteristic()
        {
            if (absolutRowsSum == null)
                СomputeAbsolutRowsSum();
            for (int i = 0; i < RowCount; i++)
                for (int j = i + 1; j < RowCount; j++)
                    if (absolutRowsSum[i] > absolutRowsSum[j])

                    {

                        for (int k = 0; k < ColCount; k++)
                            Swap(ref matrix[i, k], ref matrix[j, k]);
                        Swap(ref absolutRowsSum[i], ref absolutRowsSum[j]);
                    }
        }
        /// <summary>
        /// Обчислення абсолютної суми елементів кожного рядка
        /// </summary>
        /// <returns>повертає одновимірний масив зі значенням суми від'ємних непарних у кожному рядку</returns>
        public void СomputeAbsolutRowsSum()
        {
            absolutRowsSum = new int[RowCount];
            for (int i = 0; i < RowCount; i++)
                for (int j = 0; j < ColCount; j++)
                    if (matrix[i, j] < 0 && matrix[i, j] % 2 != 0) 
                    {
                        absolutRowsSum[i] += Math.Abs(matrix[i, j]);
                    }
                   
        }
        /// <summary>
        /// Міняє місцями значення двох змінних
        /// </summary>
        private void Swap(ref int firstElement, ref int secondElement)
        {
            int tempElement = firstElement;

            firstElement = secondElement;
            secondElement = tempElement;
        }
        #endregion
    }
}
