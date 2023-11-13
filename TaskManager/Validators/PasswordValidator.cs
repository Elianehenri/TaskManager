﻿using System.Text.RegularExpressions;

namespace TaskManager.Validators
{
    public static class PasswordValidator
    {
        public static bool IsValidPassword(string password)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,16}$";
            return Regex.IsMatch(password, pattern);
        }
    }
}
