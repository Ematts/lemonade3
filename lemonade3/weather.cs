using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace LemonAidStand
{
    class Weather
    {
        public int temperature;
        public int condition;
        public string weatherCondition;
        public double sunnyAddition = 1.5;
        public double cloudyNeutral = 1;
        public double rainySubtraction = 0.5;
        public double weatherDemand; //do I want this here??



        public Weather()
        {




        }

        public string getWeatherCondition()

        {
            Random rndCondition = new Random();
            condition = rndCondition.Next(1, 4);



            if (condition == 1)

            {

                weatherCondition = ("Sunny");

            }

            else if (condition == 2)

            {

                weatherCondition = ("Cloudy");

            }

            else

            {

                weatherCondition = ("Rainy");

            }

            Thread.Sleep(123);
            return weatherCondition;

        }

        public double getTemperature()

        {
            Random rndTemp = new Random();
            temperature = rndTemp.Next(60, 100);
            return temperature;

        }

        public double getWeatherDemand()

        {
            getWeatherCondition();
            getTemperature();


            if (weatherCondition == "Sunny")


            {
                Console.WriteLine("Today's weather is " + temperature + " degrees and " + weatherCondition + ".");
                weatherDemand = sunnyAddition * temperature;
                return weatherDemand;

            }


            else if (weatherCondition == "Cloudy")

            {
                Console.WriteLine("Today's weather is " + temperature + " degrees and " + weatherCondition + ".");
                weatherDemand = cloudyNeutral * temperature;
                return weatherDemand;


            }

            else

            {
                Console.WriteLine("Today's weather is " + temperature + " degrees and " + weatherCondition + ".");
                weatherDemand = rainySubtraction * temperature;
                return weatherDemand;

            }
        }
    }
}