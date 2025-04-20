using System;
using System.Globalization;
using System.Threading.Channels;
using Course.Entities;
using Course.UI;

namespace Course
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var userMenu = new UserMenu();
            userMenu.MainMenu();
        }
    }
}