
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonAidStand
{
    class Store
    {
        public double lemonPrice = 0.10;
        public double sugarPrice = 0.05;
        public double icePrice = 0.07;
        public double cupPrice = 0.06;


        public Store()
        {


        }
        public void storeFront(Player player, Game game)
        {
            Console.WriteLine("Please place your supply order.");
            Console.WriteLine("You currently have $" + player.money + ", " + player.lemonCount + " lemons, " + player.sugarCount + " servings of sugar, " + player.iceCount + " servings of ice, and " + player.cupCount + " cups.");
            Console.WriteLine("Press 1 to buy lemons, 2 to buy sugar, 3 to buy ice, 4 to buy cups, or 5 to return to the main menu.");
            int storeChoice = 0;

            try
            {

                storeChoice = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("That is not a valid option in this menu.");
                storeFront(player, game);
            }

            if (storeChoice == 1)
            {
                getLemons(player, game);

            }

            else if (storeChoice == 2)

            {
                getSugar(player, game);
            }

            else if (storeChoice == 3)

            {
                getIce(player, game);
            }

            else if (storeChoice == 4)

            {
                getCups(player, game);
            }

            else if (storeChoice == 5)

            {
                game.mainMenu(player, game);
            }

            else

            {
                Console.WriteLine("That is not a valid option in this menu.");
                storeFront(player, game);
            }

        }
        public double getLemons(Player player, Game game)
        {

            Console.WriteLine("Lemons cost .10 a piece.  How many lemons do you want?");
            int lemonsInCart = 0;


            try
            {

                lemonsInCart = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("That is not a valid option in this menu.");
                getLemons(player, game);
            }
            if (lemonsInCart < 0)
            {
                Console.WriteLine("That is not a valid option in this menu.");
                getLemons(player, game);
            }

            lemonCalc(player, lemonsInCart, game);
            return lemonsInCart;

        }

        public double getIce(Player player, Game game)
        {
            Console.WriteLine("Ice costs .07 a serving.  How much ice do you want?");
            double iceInCart = 0;


            try
            {

                iceInCart = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("That is not a valid option in this menu.");
                getIce(player, game);
            }
            if (iceInCart < 0)
            {
                Console.WriteLine("That is not a valid option in this menu.");
                getIce(player, game);
            }
            iceCalc(player, iceInCart, game);
            return iceInCart;

        }
        public double getSugar(Player player, Game game)
        {
            Console.WriteLine("Sugar costs .05 a serving.  How much sugar do you want?");
            double sugarInCart = 0;

            try
            {

                sugarInCart = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("That is not a valid option in this menu.");
                getSugar(player, game);
            }
            if (sugarInCart < 0)
            {
                Console.WriteLine("That is not a valid option in this menu.");
                getSugar(player, game);
            }

            sugarCalc(player, sugarInCart, game);
            return sugarInCart;

        }
        public double getCups(Player player, Game game)
        {
            Console.WriteLine("How many cups do you want?");
            double cupsInCart = 0;

            try
            {

                cupsInCart = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("That is not a valid option in this menu.");
                getCups(player, game);
            }
            if (cupsInCart < 0)
            {
                Console.WriteLine("That is not a valid option in this menu.");
                getCups(player, game);
            }

            cupCalc(player, cupsInCart, game);
            return cupsInCart;

        }

        public double lemonCalc(Player player, int lemonsInCart, Game game)
        {

            if ((lemonsInCart * lemonPrice) <= player.money)
            {

                player.lemonCount += lemonsInCart;
                player.money -= lemonsInCart * lemonPrice;
                Console.WriteLine("You now have " + player.lemonCount + " lemons and $" + player.money + ".");
                Console.WriteLine("Press 1 to return to store menu or any other key to return to main menu.");

                int returnChoice = 0;

                try
                {

                    returnChoice = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {

                    game.mainMenu(player, game);
                }

                if (returnChoice == 1)

                {

                    storeFront(player, game);

                }

                else

                {

                    game.mainMenu(player, game);

                }

                return player.lemonCount;
            }

            else
            {

                Console.WriteLine("You don't have enough money for this purchase.");
                storeFront(player, game);
                return player.lemonCount;
            }




        }
        public double iceCalc(Player player, double iceInCart, Game game)
        {
            if ((iceInCart * icePrice) <= player.money)
            {

                player.iceCount += iceInCart;
                player.money -= iceInCart * icePrice;
                Console.WriteLine("You now have " + player.iceCount + " servings of ice and $" + player.money + ".");
                Console.WriteLine("Press 1 to return to store menu or any other number to return to main menu.");
                int returnChoice = 0;

                try
                {

                    returnChoice = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {

                    game.mainMenu(player, game);
                }

                if (returnChoice == 1)

                {

                    storeFront(player, game);

                }

                else

                {

                    game.mainMenu(player, game);

                }

                return player.iceCount;
            }

            else
            {

                Console.WriteLine("You don't have enough money for this purchase.");
                storeFront(player, game);
                return player.iceCount;
            }




        }

        public double sugarCalc(Player player, double sugarInCart, Game game)
        {
            if ((sugarInCart * sugarPrice) <= player.money)
            {

                player.sugarCount += sugarInCart;
                player.money -= sugarInCart * sugarPrice;
                Console.WriteLine("You now have " + player.sugarCount + " servings of sugar and $" + player.money + ".");
                Console.WriteLine("Press 1 to return to store menu or any other number to return to main menu.");
                int returnChoice = 0;

                try
                {

                    returnChoice = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {

                    game.mainMenu(player, game);
                }

                if (returnChoice == 1)

                {

                    storeFront(player, game);

                }

                else

                {

                    game.mainMenu(player, game);

                }

                return player.sugarCount;
            }

            else
            {

                Console.WriteLine("You don't have enough money for this purchase.");
                storeFront(player, game);
                return player.sugarCount;
            }




        }
        public double cupCalc(Player player, double cupsInCart, Game game)
        {

            if ((cupsInCart * cupPrice) <= player.money)
            {

                player.cupCount += cupsInCart;
                player.money -= cupsInCart * cupPrice;
                Console.WriteLine("You now have " + player.cupCount + " cups and $" + player.money + ".");
                Console.WriteLine("Press 1 to return to store menu or any other number to return to main menu.");
                int returnChoice = 0;

                try
                {

                    returnChoice = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {

                    game.mainMenu(player, game);
                }



                if (returnChoice == 1)

                {

                    storeFront(player, game);

                }

                else

                {

                    game.mainMenu(player, game);

                }

                return player.cupCount;
            }

            else
            {

                Console.WriteLine("You don't have enough money for this purchase.");
                storeFront(player, game);
                return player.cupCount;
            }




        }
    }
}