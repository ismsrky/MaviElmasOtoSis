using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaviElmasOtoSis.Araclar
{
    public class Cevirici
    {
        public static double CelsiusToFahrenheit(string temperatureCelsius)
        {
            double celsius = System.Double.Parse(temperatureCelsius);
            return (celsius * 9 / 5) + 32;
        }
        public static double CelsiusToFahrenheit(double temperatureCelsius)
        {
            return (temperatureCelsius * 9 / 5) + 32;
        }

        public static double FahrenheitToCelsius(string temperatureFahrenheit)
        {
            double fahrenheit = System.Double.Parse(temperatureFahrenheit);
            return (fahrenheit - 32) * 5 / 9;
        }
        public static double FahrenheitToCelsius(double temperatureFahrenheit)
        {
            return (temperatureFahrenheit - 32) * 5 / 9;
        }
    }
}