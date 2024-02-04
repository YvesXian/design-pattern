using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherData weatherData = new WeatherData();

            CurrentConditionsDisplay currentDisplay = new CurrentConditionsDisplay(weatherData);
            SecondDisplay secondDisplay = new SecondDisplay(weatherData);
            weatherData.setMeasurements(80, 65, 30.4);
            weatherData.setMeasurements(82, 70, 29.3);
            weatherData.setMeasurements(78, 90, 29.2);
        }
    }

    public interface Subject
    {
        public void registerObserver(Observer o);
        public void removeObserver(Observer o);
        public void notifyObserver();
    }

    public interface Observer
    {
        public void update(double temperature, double humidity, double pressure);
    }

    public interface DisplayElement
    {
        public void display();
    }

    public class WeatherData : Subject
    {
        private List<Observer> observers;
        private double temperature;
        private double humidity;
        private double pressure;

        public WeatherData()
        {
            observers = new List<Observer>();
        }

        public void notifyObserver()
        {
            foreach (Observer observer in observers)
            {
                observer.update(this.temperature, this.humidity, this.pressure);
            }
        }

        public void registerObserver(Observer o)
        {
            observers.Add(o);
        }

        public void removeObserver(Observer o)
        {
            observers.Remove(o);
        }

        public void measurementsChanged()
        {
            this.notifyObserver();
        }

        public void setMeasurements(double temperature, double humidity, double pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            measurementsChanged();
        }
    }

    public class CurrentConditionsDisplay : Observer, DisplayElement
    {
        private double temperature;
        private double humidity;
        private WeatherData weatherData;

        public CurrentConditionsDisplay(WeatherData weatherData)
        {
            this.weatherData = weatherData;
            this.weatherData.registerObserver(this);
        }

        public void display()
        {
            Console.WriteLine("Current conditions: " + temperature.ToString()
            + "F degree and " + humidity.ToString() + "humiduty");
            Console.ReadKey();
        }

        public void update(double temperature, double humidity, double pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            display();
        }
    }

    public class SecondDisplay : Observer, DisplayElement
    {
        private double temperature;
        private double humidity;
        private WeatherData weatherData;

        public SecondDisplay(WeatherData weatherData)
        {
            this.weatherData = weatherData;
            this.weatherData.registerObserver(this);
        }

        public void display()
        {
            Console.WriteLine("SecondDisplay: " + temperature.ToString()
            + "F degree and " + humidity.ToString() + "humiduty");
            Console.ReadKey();
        }

        public void update(double temperature, double humidity, double pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            display();
        }
    }
}
