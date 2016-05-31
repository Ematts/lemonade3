using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonAidStand
{
    class Game
    {

        Store store = new Store();
        Day day = new Day();
        public int dayChoice; //should this be here?
        Player player = new Player();




        public void startGame(Game game)
        {
            startMenu();
            mainMenu(player, game);
        }
        public int startMenu()
        {

            Console.WriteLine("How many days do you want to play?");
            try
            {

                dayChoice = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("That is not a valid option in this menu.");
                startMenu();
            }
            if (dayChoice <= 0)
            {
                Console.WriteLine("That is not a valid option in this menu.");
                startMenu();
            }
            return dayChoice;


        }

        public void mainMenu(Player player, Game game)
        {
            day.printDayNumber(game);
            Console.WriteLine("Press 1 to go to the store to buy supplies, press 2 to check current money and supplies, press 3 to begin day.");
            int menuChoice = 0;
            try
            {

                menuChoice = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("That is not a valid option in this menu.");
                mainMenu(player, game);
            }

            if (menuChoice == 1)
            {
                store.storeFront(player, game);
            }

            else if (menuChoice == 2)
            {
                Console.WriteLine("You currently have $" + player.money + ", " + player.lemonCount + " lemons, " + player.sugarCount + " servings of sugar, " + player.iceCount + " servings of ice, and " + player.cupCount + " cups.");
                mainMenu(player, game);
            }

            else if (menuChoice == 3)
            {

                day.weather.getWeatherDemand();
                day.getTotalDemand(player);
                day.getCustomers();
                day.getBuyers(player);
                day.executeDay(player);

                if (day.dayNumber <= game.dayChoice)
                {
                    game.mainMenu(player, game);
                }

                else
                {
                    Console.WriteLine("Game over.  You ended with a total balance of $" + player.money + ".");
                }

                day.getNewGame(game);
            }

            else



                Console.WriteLine("That is not a valid option in this menu.");
            mainMenu(player, game);

        }
    }




}
