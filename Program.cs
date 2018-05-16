using System;
using System.Collections.Generic;
using static System.Console;



namespace AsposeMoneyBank
{
    internal class Program
    {
        private static void Main()
        {

            {

                WriteLine("How much cents do you wish to change ???");
                int chosenValue = Convert.ToInt32(ReadLine());

                WriteLine("Mow, tell me the coin's values for dollars, quarters, dimes, nickels and cents you wish to " +
                          "change.");
                string[] Coins = { "Dollar", "Quarter", "Dime", "Nickel", "Cent", };


                int Dollars = Convert.ToInt32(ReadLine());
                int Quarters = Convert.ToInt32(ReadLine());
                int Dimes = Convert.ToInt32(ReadLine());
                int Nickels = Convert.ToInt32(ReadLine());
                int Cents = Convert.ToInt32(ReadLine());

                int[] CoinsValues = new int[] { Dollars, Quarters, Dimes, Nickels, Cents, };
                string whatCoinsIHave = InsertTheAndKeyword(CoinsValues, Coins);

                WriteLine($"The value you have chosen is {chosenValue} and the following coins are:\r\n" +
                          $"{whatCoinsIHave}");

                AsposeMoneyBank.Change myChange = new AsposeMoneyBank.Change(CoinsValues[0], CoinsValues[1],
                                                             CoinsValues[2], CoinsValues[3], CoinsValues[4]);
                AsposeMoneyBank.GetChange(chosenValue, myChange);

                Environment.Exit(0);


                #region Enumerating through any collection with commas and inserting the AND word before the last element

                /*
                 * Creating any type collection, remove any non-value elements, 
                 * enumerating the elements with a comma between them 
                 * and inserting the word AND before the last element in the collection
                 */
                /*
               List<int> MyLovelyPets = new List<int>() { 0, 1, 2, 11, 0, };
               for (int i = 0; i < MyLovelyPets.Count; i++)
                   if (MyLovelyPets[i] == 0)
                       MyLovelyPets.RemoveAt(i);

               string whatIHave = "";
               for (int z = 0; z < MyLovelyPets.Count; z++)
               {
                   if (z == MyLovelyPets.Count - 1)
                   {
                       string finalValue = whatIHave.TrimEnd(new char[] { ',', ' ', });
                       whatIHave = finalValue + $" and {MyLovelyPets[z]}.";
                       break;
                   }
                   else
                       whatIHave += $"{MyLovelyPets[z]}, ";
               }
               Write(whatIHave); */
                #endregion

                /*RIGID CHANGE ALGORITHM
                 * The reason I called RIGIG is that it changes exactly each coin 
                  value into its corresponding currency. It is not as flexible as Change object constructor.*/
                #region Convert cents into dollars, quarters, dimes, nickels, cents and backward

                //int cent = 1;
                //int nickel = 5;
                //int dime = 10;
                //int quarter = 25;
                //int dollar = 100;


                //string description = "";

                //int howManyDollars = 0;
                //int howManyQuarters = 0;
                //int howManyDimes = 0;
                //int howManyNickels = 0;
                //int howManyCents = 0;

                //int lastValue = 0;

                //int myValue = 167;
                //int finalValue = myValue;
                //for (int i = 0; i <= myValue; i++)
                //{

                //    if (finalValue >= dollar)
                //    {
                //        finalValue -= dollar;
                //        howManyDollars++;
                //        continue;
                //    }

                //    if (finalValue >= quarter)
                //    {
                //        finalValue -= quarter;
                //        howManyQuarters++;
                //        continue;
                //    }

                //    if (finalValue >= dime)
                //    {
                //        finalValue -= dime;
                //        howManyDimes++;
                //        continue;
                //    }

                //    if (finalValue >= nickel)
                //    {
                //        finalValue -= nickel;
                //        howManyNickels++;
                //        continue;
                //    }

                //    if (finalValue >= cent)
                //    {
                //        finalValue -= cent;
                //        howManyCents++;
                //        continue;
                //    }

                //    description = InsertTheAndKeyword(new List<int> { howManyDollars, howManyQuarters, howManyDimes, howManyNickels, howManyCents },
                //                                      new List<string>() { "dollar", "quarter", "dime", "nickel", "cent", });

                //    lastValue = (howManyDollars * dollar) + (howManyQuarters * quarter) +
                //                (howManyDimes * dime) + (howManyNickels * nickel) + (howManyCents * cent);
                //    break;
                //}

                //Write($"{Plural(lastValue, "cent").TrimEnd(new char[] { ',', ' ', })} means {description}");
                #endregion


            }
        }

        private static void KeepConsoleOpen() { ReadKey(); }

        /// <summary>
        /// Returns the plural of the provided currency value.
        /// </summary>
        /// <param name="amount">The amount of coins.</param>
        /// <param name="currency">The currency to use.</param>
        private static string Plural(int amount, string currency)
        {
            if (amount > 1)
                currency = $"{amount} {currency}s, ";
            else
                currency = $"{amount} {currency}, ";

            return currency;
        }

        /// <summary>
        /// Checks for zero values in the coins collection, removes those values and their correspondinng description from the names collection.
        /// </summary>
        /// <param name="CurrencyValueCollection">The values of coins.</param>
        /// <param name="CurrencyNamesCollection">The description of each coin.</param>
        /// <returns>Returns a description of each coin.</returns>
        private static string InsertTheAndKeyword(IEnumerable<int> CurrencyValueCollection, IEnumerable<string> CurrencyNamesCollection)
        {
            /*Creates two separate lists, one for name of the coins and the other one with their corresponding values.
             Then fill each list with any string and int collection.*/
            List<string> CurrencyNamesList = new List<string>(CurrencyNamesCollection);
            List<int> CurrencyList = new List<int>(CurrencyValueCollection);

            /*If there is any zero values removes from both the int and string collection.
             E.g. 0 dollar, 1, quarter, 0 dime, 0 nickel, 1 cent  = 1 quarter, 1 cent*/
            for (int i = 0; i < CurrencyList.Count;)
            {
                if (CurrencyList[i] == 0)
                {
                    CurrencyList.RemoveAt(i);
                    CurrencyNamesList.RemoveAt(i);
                    continue;
                }
                i++;
            }

            //string whatCoinsIHave = CreateFinalCoinsList(CurrencyList, CurrencyNamesList);
            #region Original code

            //if (CurrencyList.Count == 1)
            //{
            //    whatCoinsIHave = $"{Plural(CurrencyList[0], CurrencyNamesList[0]).Replace(',', '.')}";
            //}
            //else
            //    for (int z = 0; z < CurrencyList.Count; z++)
            //    {
            //        if (z == CurrencyList.Count - 1)
            //        {
            //            string finalValue = whatCoinsIHave.TrimEnd(new char[] { ',', ' ' });
            //            string myValue = finalValue + $" and {Plural(CurrencyList[z], CurrencyNamesList[z]).Replace(',', '.')}";
            //            whatCoinsIHave = myValue;
            //            //whatCoinsIHave = finalValue + $" and {Plural(CurrencyList[z], CurrencyNamesList[z]).Replace(',', '.')}";
            //        }
            //        else
            //            whatCoinsIHave += $"{Plural(CurrencyList[z], CurrencyNamesList[z])} ";
            //    }
            #endregion

            //return whatCoinsIHave;

            /*REFACTORING*/
            return CreateFinalCoinsList(CurrencyList, CurrencyNamesList);
        }

        /// <summary>
        /// Takes the coin's values and their corresponding names and describe the coins you have chosen to change.
        /// </summary>
        /// <param name="CoinsCollection">The coin's values collection.</param>
        /// <param name="CurrencyNameCollection">The coin's names collection.</param>
        /// <returns>The description of each coin.</returns>
        private static string CreateFinalCoinsList(IEnumerable<int> CoinsCollection, IEnumerable<string> CurrencyNameCollection)
        {
            string whatCoinsIHave = "";
            List<int> CoinsList = new List<int>(CoinsCollection);
            List<string> CurrencyNameList = new List<string>(CurrencyNameCollection);
            if (CoinsList.Count == 1)
            {
                whatCoinsIHave = $"{Plural(CoinsList[0], CurrencyNameList[0]).Replace(',', '.')}";
            }
            else
                for (int z = 0; z < CoinsList.Count; z++)
                {
                    if (z == CoinsList.Count - 1)
                    {
                        string finalValue = whatCoinsIHave.TrimEnd(new char[] { ',', ' ' });
                        string myValue = finalValue + $" and {Plural(CoinsList[z], CurrencyNameList[z]).Replace(',', '.')}";
                        whatCoinsIHave = myValue;
                        //whatCoinsIHave = finalValue + $" and {Plural(CurrencyList[z], CurrencyNamesList[z]).Replace(',', '.')}";
                    }
                    else
                        whatCoinsIHave += $"{Plural(CoinsList[z], CurrencyNameList[z])} ";
                }
            return whatCoinsIHave;
        }
    }
}
