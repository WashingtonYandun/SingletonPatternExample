using SingletonPatternExample.Models;
using SingletonPatternExample.Services.AirplaneService;
using SingletonPatternExample.Services.CarService;

var carService = CarService.Instance;
Random random = new Random();

for (int i = 0; i < 20; i++)
{
    string[] brands = { "Mercedes Benz", "BMW", "Audi", "Toyota", "Honda" };
    string[] models = { "1", "2", "3", "4", "5" };
    string[] colors = { "Red", "Blue", "Green", "Yellow", "Black" };

    string randomBrand = brands[random.Next(brands.Length)];
    string randomModel = models[random.Next(models.Length)];
    string randomColor = colors[random.Next(colors.Length)];

    int randomYear = random.Next(2000, 2023);

    Car newCar = new Car
    {
        Name = "C" + (i + 1),
        Brand = randomBrand,
        Year = randomYear,
        Model = randomModel,
        Color = randomColor
    };

    carService.Add(newCar);
}

carService.GetById(10);

var updatedCar = new Car { Id = 5, Name = "S pro Max", Brand = "Tesla Motors", Year = 2022, Model = "10", Color = "Yellow" };
carService.Update(5, updatedCar);

carService.GetById(5);

carService.Delete(7);

Console.WriteLine("*********************************************************************************************************");

for (int i = 0; i < 20; i++)
{
    string[] brands = { "Toyota", "KLM", "TATA", "Tesla", "Qatar" };
    string[] models = { "1A", "2A", "3G", "4G", "5H" };
    string[] colors = { "WHITE", "BLACK", "BLUE" };

    string randomBrand = brands[random.Next(brands.Length)];
    string randomModel = models[random.Next(models.Length)];
    string randomColor = colors[random.Next(colors.Length)];

    int randomYear = random.Next(1980, 2023);

    Airplane newAirplane = new Airplane
    {
        Name = "A" + (i + 1),
        Brand = randomBrand,
        Year = randomYear,
        Model = randomModel,
        Color = randomColor
    };

    AirplaneService.Instance.Add(newAirplane);
}

AirplaneService.Instance.GetById(5);

Airplane updatedPlane = new Airplane { Id = 1, Name = "Updated Plane", Brand = "Updated Brand", Year = 2023, Color = "GREY", Model = "NewFalcon" };
AirplaneService.Instance.Update(5, updatedPlane);

Airplane updatedRetrievedPlane = AirplaneService.Instance.GetById(5);

AirplaneService.Instance.Delete(11);