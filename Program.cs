﻿// 72. Есть два массива info и data.
// Массив data состоит из нулей и единиц хранящий числа в двоичном представлении.
// Числа идут друг за другом без разделителей.
// Массив info состоит из чисел, которые представляют колличество бит чисел из массива data.
// Составить массив десятичных представлений чисел массива data с учётом информации из массива info.
// входные данные:
// data = {0, 1, 1, 1, 1, 0, 0, 0, 1 }
// info = {2, 3, 3, 1 }

// выходные данные:
// 1, 7, 0, 1

/* int[] data = { 0, 1, 1, 1, 1, 0, 0, 0, 1 };
int[] info = { 2, 3, 3, 1 };
int[] result = new int[info.Length]; // новый массив для сбора десятичныого представления числа
int k = 0; // счетчик количества цифр в data

for (int i = 0; i < info.Length; i++) // разбиваем data на числа в двоичном коде на основе количества бит из info
{
    for (int j = 0; j < info[i]; j++) // и проходим циклом столько шагов, какая цифра стоит в инфо (2 шага, 3 шага, 3 шага)
    {
        Console.Write(data[k + j] + " "); //выводя в консоль всё, что встретили из массива data
    }
    k += info[i]; // когда дошли все шаги, делаем переход по инфо
    Console.Write("; "); // и отделяем получившийся ряд точкой с запятой
}
k = 0; // обнуляем счётчик, он нам понадобиться ещё раз при конвертации

for (int i = 0; i < info.Length; i++) // преобразуем получившиеся числа из 2-ой в 10-ую. пока в размере массива инфо
{
    for (int j = 0; j < info[i]; j++) // и пока шагов (чисел) меньше, чем в инстуркции
    {
        result[i] += data[k + j] * (int)Math.Pow(2, info[i] - 1 - j); // записываем в новый массив с 0 позиции суммы степени двойки всех разрядов
    }
    k += info[i];
}
Console.WriteLine(); // печать

for (int i = 0; i < result.Length; i++)
{
    Console.Write(result[i] + " ");
} */

/*Задача 73: Есть число N. Сколько групп M, можно получить при разбиении всех
чисел на группы, так чтобы в одной группе все числа были взаимно просты (все
числа в группе друг на друга не делятся)? Найдите M при заданном N и получите
одно из разбиений на группы N ≤ 10²⁰. */

System.Console.WriteLine("Введите число");
int n = int.Parse(Console.ReadLine());

int[] tempArray = new int[n];
for (int i = 0; i < tempArray.GetLength(0); i++)
{
    tempArray[i] = i + 1;
}

CreateRows(tempArray);

void CreateRows(int[] arrayCheck)
{
    int[] arrayTemp = new int[arrayCheck.Length];
    int m = 1;
    int count = 0;
    int tempNumber = 0;
    int tempNumber2 = 0;
    int tempSwitch = 0;

    for (int i = 0; i < arrayCheck.Length; i++)
    {
        Array.Clear(arrayTemp); // сбрасываем значение переменных в массиве
        count = 0; // счётчик в 0
        if (arrayCheck[i] != 0) // если элемент массива не нулевой
        {
            arrayTemp[count] = arrayCheck[i]; // записываем его 
            tempNumber2 = arrayCheck[i]; 

            for (int j = i; j < arrayCheck.Length; j++) // идём по массиву
            {
                if (arrayCheck[j] % tempNumber2 != 0 || arrayCheck[j] / tempNumber2 == 1) // проверяем на "простоту" число
                {
                    tempSwitch = 0;
                    tempNumber = arrayCheck[j];
                    for (int k = 0; k < count; k++)
                    {
                        if (tempNumber % arrayTemp[k] == 0) tempSwitch++;
                    }
                    if (tempSwitch == 0)
                    {
                        arrayTemp[count] = arrayCheck[j];
                        count++;
                        arrayCheck[j] = 0;
                    }
                }
            }
            Console.WriteLine($"Группа {m++}: {PrintIntArray(arrayTemp)}");
        }
    }
}


string PrintIntArray(int[] array)
{
    string result = string.Empty;
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] != 0) result += $"{array[i],1} ";
    }
    return result;
}