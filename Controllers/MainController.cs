using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dojodachi
{
    public class MainController : Controller
    {
        [HttpGet("")]
        public IActionResult Index() 
        {
            // Checks to see if there is a current Dojodachi, and if there is not one its creates a default
            string DojodachiName = HttpContext.Session.GetString("Name");
            {
                if (DojodachiName == null)
                {
                    // creates the active Dojodachi
                    Models.MyDojodachi dojodachi = new Models.MyDojodachi("Dojodachi");

                    // stores Dojodachi fields in the session.
                    HttpContext.Session.SetString("Name", dojodachi.Name);
                    HttpContext.Session.SetInt32("Fullness", dojodachi.Fullness);
                    HttpContext.Session.SetInt32("Happiness", dojodachi.Happiness);
                    HttpContext.Session.SetInt32("Meals", dojodachi.Meals);
                    HttpContext.Session.SetInt32("Energy", dojodachi.Energy);
                    HttpContext.Session.SetString("Message", "Welcome to Dojodachi! Choose a task to perform with your new pet!");
                    
                    ViewBag.Message = HttpContext.Session.GetString("Message");
                    // sets the status for dynamic buttons on the template
                    ViewBag.Status = "Active";
                    return View("Index", dojodachi);
                }
                else
                {
                    // creates a new dojodachi, using session data, if a dojodachi exists in session
                    string Name = HttpContext.Session.GetString("Name");
                    
                    // need to convert the int? to int to be applied to the model properly
                    int? fullness = HttpContext.Session.GetInt32("Fullness");
                    int Fullness = Convert.ToInt32(fullness);
                    int? happiness = HttpContext.Session.GetInt32("Happiness");
                    int Happiness = Convert.ToInt32(happiness);
                    int? meals = HttpContext.Session.GetInt32("Meals");
                    int Meals = Convert.ToInt32(meals);
                    int? energy = HttpContext.Session.GetInt32("Energy");
                    int Energy = Convert.ToInt32(energy);

                    // applies the session data to a new dojodachi model since there is no storage in a DB.
                    Models.MyDojodachi dojodachi = new Models.MyDojodachi(Name, Fullness, Happiness, Meals, Energy);

                    // checks to if dojodachi loss conditions are met, if so trigger restart
                    if (dojodachi.Fullness == 0 || dojodachi.Happiness == 0)
                    {
                        ViewBag.Message = "Your Dojodachi has passed away";
                        
                        // sets the status for dynamic buttons on the template
                        ViewBag.Status = "Restart";
                        return View("Index", dojodachi);
                    }
                    else if (dojodachi.Energy > 100 && dojodachi.Fullness > 100 && dojodachi.Happiness > 100)
                    {
                        ViewBag.Message = "Congratulations! You won!";
                        
                        // sets the status for dynamic buttons on the template
                        ViewBag.Status = "Restart";
                        return View("Index", dojodachi);
                    }
                    else
                    {
                        ViewBag.Message = HttpContext.Session.GetString("Message");
                        
                        // sets the status for dynamic buttons on the template
                        ViewBag.Status = "Active";
                        return View("Index", dojodachi);
                    }
                }
            }

        }
        [HttpGet("food")]
        public IActionResult FeedAction()
        {
            // creates a temporary dojodachi, using session data, if a dojodachi exists in session
            string Name = HttpContext.Session.GetString("Name");
            
            // need to convert the int? to int to be applied to the model properly
            int? fullness = HttpContext.Session.GetInt32("Fullness");
            int Fullness = Convert.ToInt32(fullness);
            int? happiness = HttpContext.Session.GetInt32("Happiness");
            int Happiness = Convert.ToInt32(happiness);
            int? meals = HttpContext.Session.GetInt32("Meals");
            int Meals = Convert.ToInt32(meals);
            int? energy = HttpContext.Session.GetInt32("Energy");
            int Energy = Convert.ToInt32(energy);
            
            // applies the session data to a new dojodachi model since there is no storage in a DB.
            Models.MyDojodachi dojodachi = new Models.MyDojodachi(Name, Fullness, Happiness, Meals, Energy);

            // runs the Feed method
            string message = dojodachi.Feed();

            //updates applicable fields in the session
            HttpContext.Session.SetInt32("Fullness", dojodachi.Fullness);
            HttpContext.Session.SetInt32("Meals", dojodachi.Meals);
            HttpContext.Session.SetString("Message", message);
            
            return RedirectToAction("Index");
        }
        [HttpGet("play")]
        public IActionResult PlayAction()
        {
            // creates a temporary dojodachi, using session data, if a dojodachi exists in session
            string Name = HttpContext.Session.GetString("Name");
            
            // need to convert the int? to int to be applied to the model properly
            int? fullness = HttpContext.Session.GetInt32("Fullness");
            int Fullness = Convert.ToInt32(fullness);
            int? happiness = HttpContext.Session.GetInt32("Happiness");
            int Happiness = Convert.ToInt32(happiness);
            int? meals = HttpContext.Session.GetInt32("Meals");
            int Meals = Convert.ToInt32(meals);
            int? energy = HttpContext.Session.GetInt32("Energy");
            int Energy = Convert.ToInt32(energy);
            
            // applies the session data to a new dojodachi model since there is no storage in a DB.
            Models.MyDojodachi dojodachi = new Models.MyDojodachi(Name, Fullness, Happiness, Meals, Energy);

            // runs the Play method
            string message = dojodachi.Play();

            //updates applicable fields in the session
            HttpContext.Session.SetInt32("Happiness", dojodachi.Happiness);
            HttpContext.Session.SetInt32("Energy", dojodachi.Energy);
            HttpContext.Session.SetString("Message", message);
            
            return RedirectToAction("Index");
        }
        [HttpGet("work")]
        public IActionResult WorkAction()
        {
            // creates a temporary dojodachi, using session data, if a dojodachi exists in session
            string Name = HttpContext.Session.GetString("Name");
            
            // need to convert the int? to int to be applied to the model properly
            int? fullness = HttpContext.Session.GetInt32("Fullness");
            int Fullness = Convert.ToInt32(fullness);
            int? happiness = HttpContext.Session.GetInt32("Happiness");
            int Happiness = Convert.ToInt32(happiness);
            int? meals = HttpContext.Session.GetInt32("Meals");
            int Meals = Convert.ToInt32(meals);
            int? energy = HttpContext.Session.GetInt32("Energy");
            int Energy = Convert.ToInt32(energy);
            
            // applies the session data to a new dojodachi model since there is no storage in a DB.
            Models.MyDojodachi dojodachi = new Models.MyDojodachi(Name, Fullness, Happiness, Meals, Energy);

            // runs the Work method
            string message = dojodachi.Work();

            //updates applicable fields in the session
            HttpContext.Session.SetInt32("Meals", dojodachi.Meals);
            HttpContext.Session.SetInt32("Energy", dojodachi.Energy);
            HttpContext.Session.SetString("Message", message);
            
            return RedirectToAction("Index");
        }
        [HttpGet("sleep")]
        public IActionResult SleepAction()
        {
            // creates a temporary dojodachi, using session data, if a dojodachi exists in session
            string Name = HttpContext.Session.GetString("Name");
            
            // need to convert the int? to int to be applied to the model properly
            int? fullness = HttpContext.Session.GetInt32("Fullness");
            int Fullness = Convert.ToInt32(fullness);
            int? happiness = HttpContext.Session.GetInt32("Happiness");
            int Happiness = Convert.ToInt32(happiness);
            int? meals = HttpContext.Session.GetInt32("Meals");
            int Meals = Convert.ToInt32(meals);
            int? energy = HttpContext.Session.GetInt32("Energy");
            int Energy = Convert.ToInt32(energy);
            
            // applies the session data to a new dojodachi model since there is no storage in a DB.
            Models.MyDojodachi dojodachi = new Models.MyDojodachi(Name, Fullness, Happiness, Meals, Energy);

            // runs the Sleep method
            string message = dojodachi.Sleep();

            //updates applicable fields in the session
            HttpContext.Session.SetInt32("Energy", dojodachi.Energy);
            HttpContext.Session.SetInt32("Fullness", dojodachi.Fullness);
            HttpContext.Session.SetInt32("Happiness", dojodachi.Happiness);
            HttpContext.Session.SetString("Message", message);
            
            return RedirectToAction("Index");
        }
        [HttpGet("restart")]
        public IActionResult RestartAction()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}