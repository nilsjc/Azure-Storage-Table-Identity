using AzureStorageTableIdentity.Models;
using System;

namespace AzureStorageTableIdentity.Statics
{
    public static class SetColor
    {
        public static void Paper(Colors color)
        {
            Console.BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color.ToString());
        }

        public static void Ink(Colors color)
        {
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color.ToString());
        }
    }
}
