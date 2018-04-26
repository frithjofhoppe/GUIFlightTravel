using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace GUITravel
{
    static class RegexLib
    {

        public static bool IsEmailValid(String text)
        {
            if (Regex.IsMatch(text, @"[a-zA-Z]+\.?[a-zA-Z]+\@[a-zA-Z]{2,}\.[a-zA-Z]{2,3}"))
            {
                return true;
            }
            return false;
        }

        public static bool IsNameValid(String name)
        {
            if (Regex.IsMatch(name, @"^[a-zA-Zäöü]{2,}\s?[a-zA-Zäöü]*$"))
            {
                return true;
            }
            return false;
        }

        public static bool IsLocationValid(String name)
        {
            if (Regex.IsMatch(name, @"^[a-zA-Zäöü\-]{3,}$"))
            {
                return true;
            }
            return false;
        }

        public static bool AreStarsValid(String name)
        {
            if (Regex.IsMatch(name, @"^[1-7]$"))
            {
                return true;
            }
            return false;
        }

        public static bool IsManageValid(String name)
        {
            if (Regex.IsMatch(name, @"^[a-zA-Zäöü]{2,}\s[a-zA-Zäöü]{2,}$"))
            {
                return true;
            }
            return false;
        }

        public static bool IsCountOfRoomsValid(String name)
        {
            if (Regex.IsMatch(name, @"^[0-9]+$"))
            {
                if (Int32.Parse(name.Trim()) > 2)
                {
                    return true;
                }

            }
            return false;
        }

        public static bool IsDailyPriceValid(String text)
        {
            if (Regex.IsMatch(text, @"^\d{1,}\.+\d+$"))
            {
                return true;
            }
            return false;
        }

        public static bool IsTelephonenumberValid(String text)
        {
            if (Regex.IsMatch(text, @"\d{3}\s\d{3}\s\d{4}$"))
            {
                return true;
            }
            return false;
        }

        public static bool IsURLValid(String text)
        {
            //if (Regex.IsMatch(text, @"http[s]+\:\/\/www+[a-zA-Zäöü]{1,}\.[a-zA-Z]{2,3}"))
            //{
            //    return true;
            //}
            //return false;
            return true;
        }

        public static bool RegexMatcher(Func<string, bool> matcher, String content, Control item)
        {
            if (content.Trim().Length != 0)
            {
                if (matcher(content))
                {
                    item.Background = Brushes.Green;
                    return true;
                }
                else
                {
                    item.Background = Brushes.Red;
                }
            }
            else
            {
                item.Background = Brushes.White;
            }
            return false;
        }
    }
}
