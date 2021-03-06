﻿using System;
using System.Collections.Generic;
using System.IO;


namespace GraphicsEditor.Commands.Data
{
    class IndexHelper
    {
        protected static char[] Borders = {'[', ']'};
        protected static char Delimiter = ':';
        
       
        protected static uint[] ValidateIndexesOrFail(string[] parameters)
        {
            try
            {
                List<uint> indexes = new List<uint>();

                foreach (string parametr in parameters)
                {
                    int index = int.Parse(parametr);

                    if (index < 0)
                    {
                        throw new ArgumentException("Параметр " + index + " в Индексе" + parametr + " не может быть отрицательным");
                    }

                    indexes.Add((uint) index);
                }
                return indexes.ToArray();
            }
            catch (FormatException )
            {
                Console.WriteLine("Вы ввели индексы в неверном формате");
            }
            catch (OverflowException)
            {              
                Console.WriteLine("Вы ввели слишком большое число в качестве индекса");
            }
            return null;
        }
        

        public static uint[][] StringArrayToIndexesOrFail(string[] parameters)
        {
            try
            {
                List<uint[]> indexesMain = new List<uint[]>();
                foreach (string parameter in parameters) {
                    string[] stringIndexes = parameter.Split(Delimiter);

                    uint[] indexes = ValidateIndexesOrFail(stringIndexes);

                    if (indexes == null) {
                        return null;
                    }

                    if (indexesMain.Exists(item => Equals(item, indexes))) {
                        throw new InvalidDataException("Индекс " + IndexesToString(indexes) + " повторяется");
                    }
                    indexesMain.Add(indexes);
                }
                return indexesMain.ToArray();
            } catch (InvalidDataException error) {
                Console.WriteLine(error.Message);
            }
            return null;
        }

        public static uint[] StringToIndexesOrFail(string parameter) {
            try {
                    string[] stringIndexes = parameter.Split(Delimiter);

                  
                return ValidateIndexesOrFail(stringIndexes);
            } catch (InvalidDataException error) {
                Console.WriteLine(error.Message);
            }
            return null;
        }

        public static string IndexToString(uint index)
        {
            return Borders[0] + index.ToString() + Borders[1];

        }

        public static string IndexesToString(uint[] indexes)
        {
            return Borders[0] + String.Join(Delimiter.ToString(), indexes) + Borders[1];
        }

        public static bool Equals(uint[] x, uint[] y) {
            if (x.Length == y.Length) {
                for (int count = 0; count < x.Length; count++) {
                    if (x[count] != y[count]) {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}