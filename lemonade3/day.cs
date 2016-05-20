using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LemonAidStand
{
    class Day
    {
        public int dayNumber;
        public Weather weather = new Weather();
        int customerTotal;
        List<Customer> potentialCustomerList = new List<Customer>();
        List<Customer> buyerList = new List<Customer>();
        List<Customer> actualSales = new List<Customer>();
        Random rndThirst = new Random(); //do I need this here?
        double totalDemand; // could not think of other way to access this
                            //double glassPrice;



        public Day()
        {

            dayNumber = 1;

        }

        public void printDayNumber(Game game)
        {
            if (dayNumber <= game.dayChoice)
            {
                Console.WriteLine("Today is day #" + dayNumber);

            }

        }

        public int getCustomerTotal()
        {
            customerTotal = weather.temperature;
            return customerTotal;
        }
        public List<Customer> getCustomers()
        {
            getCustomerTotal();
            for (int customerAmount = 0; customerAmount < customerTotal; customerAmount++)
            {
                //Random rndMood = new Random();
                Customer customer = new Customer(rndThirst.Next(0, 3));
                potentialCustomerList.Add(customer);
                //Thread.Sleep(200); why won't this work in debug?
            }

            return potentialCustomerList;
        }



        public double getTotalDemand(Player player)
        {



            double priceDemand = player.getGlassPrice();
            totalDemand = weather.weatherDemand / priceDemand;
            Console.WriteLine("total demand = " + totalDemand);
            return totalDemand;


        }

        public List<Customer> getBuyers(Player player)


        {
            foreach (Customer customer in potentialCustomerList)
            {
                double buyerIndex = customer.thirstNumber * totalDemand;


                if (buyerIndex >= 325)

                {
                    buyerList.Add(customer);

                }

            }
            return buyerList;
        }

        public void executeDay(Player player)
        {
            foreach (Customer buyer in buyerList)
            {
                if ((player.lemonCount > 0) && (player.sugarCount > 0) && (player.iceCount > 0) && (player.cupCount > 0))
                {
                    player.money += player.glassPrice;
                    player.lemonCount -= 1;
                    player.sugarCount -= 1;
                    player.iceCount -= 1;
                    player.cupCount -= 1;
                    actualSales.Add(buyer);


                }

                else

                {
                    Console.WriteLine("You ran out of supplies!");

                    break;


                }

            }
            Console.WriteLine("Today you sold " + actualSales.Count + " glasses of lemonade.  You made $" + actualSales.Count * player.glassPrice + ", giving you a total balance of $" + player.money + ". \nYou have " + player.lemonCount + " lemons, " + player.sugarCount + " sugar servings, " + player.iceCount + " ice servings, and " + player.cupCount + " cups remaining.");
            dayNumber++;
            actualSales.Clear();

        }

        /*  public void cycleToNextDay(Player player, Game game)
          {
              if (dayNumber <= game.dayChoice)
              {
                  game.mainMenu(player, game);
              }
              else
              {
                  Console.WriteLine("Game over.  You ended with a total balance of $" + player.money + ".");
              }
          }  */
        public void getNewGame(Game game)
        {
            Console.WriteLine("Press 1 to play again, press 2 to exit.");
            int endChoice = 0;

            try
            {

                endChoice = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("That is not a valid option in this menu.");
                getNewGame(game);

            }

            if (endChoice == 1)
            {
                game = new Game();
                game.startGame(game);
            }

            else if (endChoice == 2)
            {
                Console.WriteLine("Goodby!");
                Console.ReadKey();
                Environment.Exit(0);
            }


            else
            {
                Console.WriteLine("That is not a valid option in this menu.");
                getNewGame(game);

            }
        }
    }

}