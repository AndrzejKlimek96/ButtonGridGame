using ButtonGridGame.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ButtonGridGame.Controllers
{
    public class ButtonController : Controller
    {
        static List<ButtonModel> buttons = new List<ButtonModel>();
        Random rand = new Random();
        const int Grid_size = 25;


        public IActionResult Index()
        {
            buttons = new List<ButtonModel>();


            if (buttons.Count < Grid_size)
            {
                for (int i = 0; i < Grid_size; i++)
                {
                    buttons.Add(new ButtonModel { Id = i, ButtonState = rand.Next(4) });
                }
            }





            return View("Index", buttons);
        }


        public IActionResult HandleButtonClick(string buttonNumber, bool buttonsAreTheSameColor)
        {
            int bn = int.Parse(buttonNumber);

            buttons.ElementAt(bn).ButtonState = ((buttons.ElementAt(bn).ButtonState + 1)%4);

            buttonsAreTheSameColor = true;

            foreach(var item in buttons)
            {
                if(item.ButtonState == buttons.ElementAt(bn).ButtonState)
                {

                }
                else
                {
                    buttonsAreTheSameColor = false;
                    break;
                }
            }

            ViewBag.buttonsAreTheSameColor = buttonsAreTheSameColor;

            return View("Index", buttons);
        }
         
        public IActionResult ShowOneButton(int buttonNumber)
        {
            //add one to status of button
            buttons.ElementAt(buttonNumber).ButtonState = (buttons.ElementAt(buttonNumber).ButtonState + 1) % 4;

            return PartialView(buttons.ElementAt(buttonNumber));
        }

        public IActionResult CheckIfWin(int buttonNumber, bool AreYouWinningSon)
        {
            AreYouWinningSon = true;
            foreach(var item in buttons)
            {
                if(buttons.ElementAt(0).ButtonState != item.ButtonState)
                {
                    AreYouWinningSon = false;
                }
            }

            ViewBag.AreYouWinningSon = AreYouWinningSon;

            return PartialView("CheckIfWin");
        }







    }
}
