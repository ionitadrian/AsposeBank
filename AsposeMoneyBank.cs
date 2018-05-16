using System;
using System.Collections.Generic;
using static System.Console;

namespace AsposeMoneyBank
{
    public class AsposeMoneyBank
    {
        public class Change
        {
            private int dollars; // 100 cents
            private int quarters; // 25 cents
            private int dimes; // 10 cents
            private int nickels; // 5 cents
            private int cents; // 1 cent

            public int GetDollars() { return dollars; }
            public int GetQuarters() { return quarters; }
            public int GetDimes() { return dimes; }
            public int GetNickels() { return nickels; }
            public int GetCents() { return cents; }



            public Change(int dollars, int quarters, int dimes, int nickels, int cents)
            {
                this.dollars = dollars;
                this.quarters = quarters;
                this.dimes = dimes;
                this.nickels = nickels;
                this.cents = cents;
            }

        }

        /// <summary>
        /// Returns the plural of the provided currency value.
        /// </summary>
        /// <param name="amount">The amount of coins.</param>
        /// <param name="currency">The currency to use.</param>
        /// <returns>The amount in coins and currency</returns>
        private static string Plural(int amount, string currency)
        {
            if (amount > 1)
                currency = $"{amount} {currency}s, ";
            else
                currency = $"{amount} {currency}, ";
            return currency;
        }

        /// <summary>
        /// Checks if the amount of cents you wish to change is equal to the desired amount of coins 
        /// you want to receive.
        /// </summary>
        /// <param name="cents">The amount of cents you wish to change.</param>
        /// <param name="availableChange">The amount of coins you want to receive.</param>
        /// <returns>True if the two amounts are equal, otherwise false.</returns>
        private static bool CentsAmountsAreEqual(int cents, Change availableChange)
        {
            int amountInCents = (availableChange.GetDollars() * 100) +
                                (availableChange.GetQuarters() * 25) +
                                (availableChange.GetDimes() * 10) +
                                (availableChange.GetNickels() * 5) +
                                availableChange.GetCents();

            if (cents != amountInCents)
                return false;
            return true;
        }


        public static Change GetChange(int cents, Change availableChange)
        {
            int amountInCents = (availableChange.GetDollars() * 100) +
                                (availableChange.GetQuarters() * 25) +
                                (availableChange.GetDimes() * 10) +
                                (availableChange.GetNickels() * 5) +
                                availableChange.GetCents();

            #region Refactoring

            //if (cents != amountInCents)
            //{
            //    ForegroundColor = ConsoleColor.Cyan;
            //    WriteLine($"The cents you wish to change {cents} are not equal " +
            //        $"to the amount in cents, {amountInCents}.");
            //    ResetColor();
            //}

            //if (cents == amountInCents)
            //{
            //    ForegroundColor = ConsoleColor.Green;
            //    WriteLine("Congrats !!! The values provided are equal !!!");
            //    ResetColor();
            //}
            #endregion


            if (CentsAmountsAreEqual(cents, availableChange))
            {
                ForegroundColor = ConsoleColor.Green;
                WriteLine("Congrats !!! The values provided are equal !!!");
                ResetColor();
            }
            else
            {
                ForegroundColor = ConsoleColor.Cyan;
                WriteLine($"The {Plural(cents, "cent").TrimEnd(new char[] { ',', ' ' })} " +
                          $"you wish to change are not equal to the amount " +
                          $"{Plural(amountInCents, "cent").TrimEnd(new char[] { ',', ' ' })}" +
                          " you wish to receive.");
                ResetColor();
            }


            List<int> CoinsValue = new List<int>()
            {
                availableChange.GetDollars(), availableChange.GetQuarters(),
                availableChange.GetDimes(), availableChange.GetNickels(),
                availableChange.GetCents(),

            };
            List<string> NameOfCoins = new List<string>() { "dollar", "quarter", "dime", "nickel", "cent", };


            for (int i = 0; i < CoinsValue.Count;)
            {
                if (CoinsValue[i] == 0)
                {
                    CoinsValue.RemoveAt(i);
                    NameOfCoins.RemoveAt(i);
                    continue;
                }
                i++;
            }

            string whatCoinsIHave = "";
            if (CoinsValue.Count == 1)
                whatCoinsIHave = $"{Plural(CoinsValue[0], NameOfCoins[0]).Replace(',', '.')}";
            else
                for (int z = 0; z < CoinsValue.Count; z++)
                {
                    if (z == CoinsValue.Count - 1)
                    {
                        string finalValue = whatCoinsIHave.TrimEnd(new char[] { ',', ' ' });
                        string myValue = finalValue + $" and {Plural(CoinsValue[z], NameOfCoins[z]).Replace(',', '.')}";
                        whatCoinsIHave = myValue;
                    }
                    else
                        whatCoinsIHave += $"{Plural(CoinsValue[z], NameOfCoins[z])}";
                }

            WriteLine($"{amountInCents} cents = {whatCoinsIHave}");

            return availableChange;
        }



    }
}