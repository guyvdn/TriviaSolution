using System;
using System.Linq;

namespace Trivia
{
    public static class IntExtension
    {
         public static void Times(this int number, Action<int> action)
         {
             for (var i = 0; i < number; i++)
             {
                 action(i);
             }
         }
    }
}