using BullsAndCows.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BullsAndCows.Controllers
{
    public class GameController : Controller
    {
        GameModel gameModelData = new GameModel();
        string won = "";
        string msg = "";
        int bull = 0;
        int cow = 0;

        [HttpGet]
        public IActionResult Index()
        {
            
            
            
            return View(gameModelData);
        }
        [HttpPost]
        public IActionResult Index(GameModel gameModel)
        {
            
            DateTime dateTime = DateTime.Now;
            gameModelData.secretNum = dateTime.Day.ToString("00.##") + dateTime.Hour.ToString("00.##");
            gameModelData.userInput = gameModel.userInput;
            Calculate(gameModelData.secretNum, gameModelData.userInput);
            ViewBag.bull = bull;
            ViewBag.cow = cow;
            ViewBag.won = won;
            ViewBag.msg = msg;
            return View(gameModelData);
        }
        public void Calculate(string secNum, string userInput)
        {
            bull = 0;
            cow = 0;
            if (userInput == null || secNum.Length != userInput.Length)
                msg = $"Enter Valid Input. Hint: The Secret number has {secNum.Length} digits";
            else
            {
                for (int i = 0; i < secNum.Length; i++)
                {
                    for (int j = 0; j < userInput.Length; j++)
                    {
                        if (i == j && userInput[i] == secNum[j])
                        {
                            bull++;
                            break;
                        }
                        else
                        {
                            if (userInput[i] == secNum[j])
                            {
                                cow++;
                            }

                        }
                    }
                }
            }
            if(bull == secNum.Length)
            {
                won = "You Won";
            }
            
        }
        
    }
}
