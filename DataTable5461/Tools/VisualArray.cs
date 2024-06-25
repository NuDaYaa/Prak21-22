using System.Data;

namespace DataTable5461.Tools
{ 
    static class VisualArray
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Тип данных элементов массива</typeparam>
        /// <param name="array">Одномерный массив для визуализации</param>
        /// <returns>Преобразованный одномерный массив</returns>
        //Метод для одномерного массива
        public static DataTable ToDataTable<T>(this T[] array)
        {
            var res = new DataTable();

            for (int i = 0; i < array.Length; i++)
            {                          
                res.Columns.Add("col" + (i+1), typeof(T));
            }

            var row = res.NewRow();

            for (int i = 0; i < array.Length; i++)
            {
                row[i] = array[i];
            }

            res.Rows.Add(row);

            return res;
        }
        //Метод для двухмерного массива
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Тип данных элементов массива</typeparam>
        /// <param name="matrix">Двухмерный массив для визуализации</param>
        /// <returns>Преобразованный двухмерный массив</returns>
        public static DataTable ToDataTable<T>(this T[,] matrix)
        {
            var res = new DataTable();

             for (int i = 0; i < matrix.GetLength(1); i++)
            {
                res.Columns.Add("col" + (i+1), typeof(T));
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var row = res.NewRow();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    row[j] = matrix[i, j];
                }

                res.Rows.Add(row);
            }

            return res;
        }


    }
}
