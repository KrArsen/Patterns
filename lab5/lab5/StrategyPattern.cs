using System;
using System.Collections.Generic;

namespace lab5
{
    /// <summary>
    /// Патерн "Стратегія" (Strategy) у функціональному стилі.
    /// Замість класичного визначення інтерфейсу IStrategy та створення окремих класів-реалізацій
    /// для кожної стратегії сортування, ми використовуємо вбудований делегат Comparison<T> або Func<T, T, int>.
    /// Стратегія поведінки передається як чиста функція (лямбда-вираз).
    /// </summary>
    public static class StrategyPattern
    {
        /// <summary>
        /// Метод сортування, який приймає список чисел та стратегію порівняння.
        /// </summary>
        /// <param name="list">Вхідний список чисел.</param>
        /// <param name="strategy">Функція порівняння (стратегія).</param>
        /// <returns>Новий відсортований список.</returns>
        public static List<int> Sort(List<int> list, Comparison<int> strategy)
        {
            // Створюємо копію списку, щоб забезпечити незмінність (immutability) оригінальних даних
            var sortedList = new List<int>(list);
            sortedList.Sort(strategy);
            return sortedList;
        }
    }
}
