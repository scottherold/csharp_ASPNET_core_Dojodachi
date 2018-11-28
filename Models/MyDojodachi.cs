using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dojodachi.Models
{
    public class MyDojodachi
    {
        public string Name { get; set; }
        public int Fullness { get; set; }
        public int Happiness { get; set; }
        public int Meals { get; set; }
        public int Energy { get; set; }
        Random rand = new Random();

        public MyDojodachi(string name)
        {
            // sets base stats. Added name for personalization.
            Name = name;
            Fullness = 20;
            Happiness = 20;
            Meals = 3;
            Energy = 50;
        }
        public MyDojodachi(string name, int fullness, int happiness, int meals, int energy)
        {
            // sets base stats. Added name for personalization.
            Name = name;
            Fullness = fullness;
            Happiness = happiness;
            Meals = meals;
            Energy = energy;
        }
        public string Feed()
        {
            // the dislike event handler gives a 25% that the method will not work.
            int dislike = rand.Next(1,5);
            // meals must be over 0 for the method to work.
            if (this.Meals > 0)
            {
                int adjuster = rand.Next(5,11);
                
                if (dislike > 1)
                {
                    // if 'dislike' isn't tiggered, runs the method and returns a string to be used in the controller.
                    this.Fullness += adjuster;
                    this.Meals -= 1;
                    string message = $"You fed your Dojodachi! Fullness +{adjuster}, Meals -1";
                    return message;
                }
                else
                {
                    this.Meals -= 1;
                    string message = "Your Dojodachi did not like the food... Fullness +0, Meals -1";
                    return message;
                }
            }
            else
            {
                string message = "You do not have enough Meals to feed your Dojodachi!";
                return message;
            }
        }
        public string Play()
        {
            // the dislike event handler gives a 25% that the method will not work.
            int dislike = rand.Next(1,5);
            // checks to see if Energy levels are okay to perform the task -- they should be, but this is a redunancy
            if (this.Energy >= 5)
            {
                // if 'dislike' isn't tiggered, runs the method and returns a string to be used in the controller.
                int adjuster = rand.Next(5,11);
                if (dislike > 1)
                {
                    this.Happiness += adjuster;
                    this.Energy -= 5;
                    string message = $"You played with your Dojodachi! Happiness +{adjuster}, Energy -5";
                    return message;
                }
                else
                {
                    this.Energy -= 5;
                    string message = "Your Dojodachi decided to loaf around instead... Happiness +0, Energy -5";
                    return message;
                }
            }
            else
            {
                string message = "Your Dojodachi does not have enough energy to play!";
                return message;
            }
        }
        public string Work()
        {
            // checks to see if Energy levels are okay to perform the task -- they should be, but this is a redunancy
            if (this.Energy >= 5)
            {
                int adjuster = rand.Next(1,4);
                this.Meals += adjuster;
                this.Energy -=5;
                string message = $"You made your Dojodachi Work! Meals +{adjuster}, Energy -5";
                return message;
            }
            else
            {
                string message = "Your Dojodachi is too tired to work!";
                return message;
            }
        }
        public string Sleep()
        {
            if (this.Fullness >= 5 && this.Happiness >=5)
            {
                this.Energy += 15;
                this.Fullness -= 5;
                this.Happiness -= 5;
                string message = $"You let your Dojodachi sleep! Energy +15, Fullness -5, Happiness -5";
                return message;
            }
            else
            {
                string message = "Your Dojodachi is too hunry or unhappy to sleep!";
                return message;
            }
        }
    }
}