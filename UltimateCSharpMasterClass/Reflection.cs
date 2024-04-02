using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidateNumberEtc
{
    public class BlueConsoleWriter
    {
        [ValidateColor(AllowedConsoleColor = ConsoleColor.Blue)]
        public ConsoleColor MyColor { get; } = ConsoleColor.White;

        private IValidator Validator { get; }

        public BlueConsoleWriter(ConsoleColor color, IValidator validator)
        {
            MyColor = color;
            Console.ForegroundColor = MyColor;
            Validator = validator;
        }

        
        public void PrintInBlue(string stringtoprint)
        {
            if (Validator.IsValid(this))
            {
                Console.WriteLine(stringtoprint);
            }
            else;
            
        }
        
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class ValidateColorAttribute : Attribute
    {
        public ConsoleColor AllowedConsoleColor { get; set; }

    }

    public interface IValidator
    {
        public bool IsValid(object obj);
    }
    public class Validator: IValidator 
    {
        public bool IsValid(object obj)
        {
            var properties = obj.GetType().GetProperties()
                .Where(prop =>
                Attribute.IsDefined(prop, typeof(ValidateColorAttribute)));
            foreach (var prop in properties)
            {
                object? propertyVal = prop.GetValue(obj);
                var consolecolorval = (ConsoleColor)propertyVal;
                var attribute = (ValidateColorAttribute)prop.GetCustomAttributes(
                    typeof(ValidateColorAttribute), true).First();
                if (consolecolorval != attribute.AllowedConsoleColor)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    //throw new FormatException("Color of property must be blue to be able to print a property");
                    Console.WriteLine($"Attempt to Write Property to Console Failed, Color must be {attribute.AllowedConsoleColor} in order to print it.");
                    return false;
                }
            }
            return true;
                    
                    
        }
    }

    public sealed class Person
    {
        public int Age { get; init; }
    }
}
