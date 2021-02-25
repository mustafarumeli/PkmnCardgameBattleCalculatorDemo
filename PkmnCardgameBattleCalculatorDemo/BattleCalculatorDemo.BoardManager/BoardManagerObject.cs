using System;
using BattleCalculatorDemo.AbstractionLayer;

namespace BattleCalculatorDemo.BoardManager
{
   public class BoardManagerObject : IBoardManager 
   {
      private int _turnTimer = 0;
      public void Write(string text)
      {
         Console.WriteLine(text);
      }
   }
}