using System;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading;

namespace HelloWorld {
    internal class Program {
        static void Main(string[] args) {
            string userDOB;
            string userBirthMonth;
            string userBirthDate;
            string userBirthYear;
            bool userBirthdayToday;
            int userDaysInMonth;
            int userAge;
            DateTime userBirthDay;
            DateTime userBirthdayThisYear;
            DateTime userBirthdayNextYear;
            TimeSpan userDaysUntilBirthday;
            while (true) {
                Console.Write("Enter your DOB (MM/DD/YYYY): ");
                userDOB = Console.ReadLine();
                userBirthMonth = userDOB.Substring(0, 2);
                userBirthDate = userDOB.Substring(3, 2);
                userBirthYear = userDOB.Substring(6, 4);
                userBirthdayToday = false;
                userDaysInMonth = 0;
                try {
                    if (int.Parse(userBirthMonth) == 2) {
                        if (DateTime.IsLeapYear(int.Parse(userBirthYear))) {
                            userDaysInMonth = 29;
                        }
                        else {
                            userDaysInMonth = 28;
                        }
                    }
                    else if (new int[] { 4, 6, 9, 11 }.Contains(int.Parse(userBirthMonth))) {
                        userDaysInMonth = 30;
                    }
                    else if (new int[] { 1, 3, 5, 7, 8, 10, 12 }.Contains(int.Parse(userBirthMonth))) {
                        userDaysInMonth = 31;
                    }
                    else {
                        Thread.Sleep(1000);
                        Console.WriteLine("Invalid date of birth.");
                        Thread.Sleep(1000);
                        continue;
                    }
                    if (int.Parse(userBirthDate) > userDaysInMonth || int.Parse(userBirthDate) < 1) {
                        Thread.Sleep(1000);
                        Console.WriteLine("Invalid date of birth.");
                        Thread.Sleep(1000);
                        continue;
                    }
                    userBirthDay = new DateTime(int.Parse(userBirthYear), int.Parse(userBirthMonth), int.Parse(userBirthDate));
                    userBirthdayThisYear = new DateTime(DateTime.Now.Year, int.Parse(userBirthMonth), int.Parse(userBirthDate));
                    userBirthdayNextYear = new DateTime((DateTime.Now.Year + 1), int.Parse(userBirthMonth), int.Parse(userBirthDate));
                    if (userBirthDay == DateTime.Now.Date) {
                        userBirthdayToday = true;
                    }
                    if (userBirthDay > DateTime.Now) {
                        Thread.Sleep(1000);
                        Console.WriteLine("Invalid date of birth.");
                        Thread.Sleep(1000);
                        continue;
                    }
                    Thread.Sleep(1000);
                    break;
                }
                catch (FormatException) {
                    Thread.Sleep(1000);
                    Console.WriteLine("Invalid date of birth.");
                    Thread.Sleep(1000);
                    continue;
                }
            }
            if (userBirthdayToday) {
                Console.WriteLine("Happy Birthday!");
            }
            else {
                if (userBirthdayThisYear < DateTime.Now.Date) {
                    userAge = DateTime.Now.Date.Year - userBirthDay.Year;
                    userDaysUntilBirthday = userBirthdayNextYear - DateTime.Now.Date;
                }
                else {
                    userAge = (DateTime.Now.Date.Year - userBirthDay.Year) - 1;
                    userDaysUntilBirthday = userBirthdayThisYear - DateTime.Now.Date;
                }
                Console.WriteLine("Days until birthday: " + userDaysUntilBirthday.Days);
                Thread.Sleep(500);
                Console.WriteLine("Age: " + userAge);
                Thread.Sleep(1000);
            }
        }
    }
}
