using System;

namespace Managment.Methods
{
    public class Informations
    {
        public static void PrintingDatas<T, TValue>(IQueryable<T> itemsOne, IQueryable<TValue> itemsTwo, string pieceOfSentence)
        {
            var itemOne = itemsOne.ToList();
            var itemTwo = itemsTwo.ToList();

            for(int i = 0; i < itemOne.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. {itemOne[i]} - {pieceOfSentence} - {itemTwo[i]}");
            }
        }
    }
}

