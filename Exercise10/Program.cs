Console.BackgroundColor = ConsoleColor.DarkCyan;
Console.Clear();
bool next;
    int  route, numberTrips, numberPassengers, package10, package1020, package20;
decimal incomePassengers, incomePackages, incomeTotals, valueAssistant, valueInsurance, valueGasoline;
do
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"*** Input Data ***");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("If you do not comply with the assigned case, enter 0!!");
    route = RequestInt("Route? [1] [2] [3] [4].....: ");
    numberTrips = RequestInt("Number Trips?..............: ");
    numberPassengers = RequestInt("Number Passengers?.........: ");
    package10 = RequestInt("package 10 Kg?.............: ");
    package1020 = RequestInt("package 10-20 Kg?..........: ");
    package20 = RequestInt("package 20 kg?.............: ");
    incomePassengers = CalculateIncomePassangers(route, numberTrips, numberPassengers);
    incomePackages = CalculateIncomePackages(route, package10, package1020, package20);
    incomeTotals = incomePassengers + incomePackages;
    valueAssistant = CalculateValueAssistant(incomeTotals);
    valueInsurance = CalculateValueInsurance(incomeTotals);
    valueGasoline = CalculateValueGasoline(route, numberTrips, numberPassengers, package10, package1020, package20);
    ShowResults(incomePassengers, incomePackages, valueAssistant, valueGasoline, valueInsurance);
    next = RequestBool("Do you want to calculate another value [y/n]? ");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("=========================================");

} while (next);

static int RequestInt(string message)
{
    Console.Write(message);
    var inputString = Console.ReadLine();
    try
    {
        return Convert.ToInt32(inputString);
    }
    catch (Exception)
    {
        throw new Exception("You must enter a valid integer number.");
    }

}

static decimal CalculateIncomePassangers(int route, int numberTrips, int numberPassengers)
{
    decimal value;
    if (route == 1)
    {
        value = numberTrips * 500000;
        if (numberPassengers < 50) return value;
        if (numberPassengers < 100) return value * 1.05M;
        if (numberPassengers < 150) return value * 1.06M;
        if (numberPassengers < 200) return value * 1.07M;
        return value * 1.07M + (numberPassengers - 200) * 50;
    }
    else if (route == 2) 
    {
        value = numberTrips * 600000;
        if (numberPassengers < 50) return value;
        if (numberPassengers < 100) return value * 1.07M;
        if (numberPassengers < 150) return value * 1.08M;
        if (numberPassengers < 200) return value * 1.09M;
        return value * 1.09M + (numberPassengers - 200) * 60;
    }
    else if(route == 3)
    {
        value = numberTrips * 800000;
        if (numberPassengers < 50) return value;
        if (numberPassengers < 100) return value * 1.10M;
        if (numberPassengers < 150) return value * 1.13M;
        if (numberPassengers < 200) return value * 1.15M;
        return value * 1.15M + (numberPassengers - 200) * 100;
    }
    else
    {
        value = numberTrips * 1000000;
        if (numberPassengers < 50) return value;
        if (numberPassengers < 100) return value * 1.125M;
        if (numberPassengers < 150) return value * 1.15M;
        if (numberPassengers < 200) return value * 1.17M;
        return value * 1.17M + (numberPassengers - 200) * 150;
    }
}

static decimal CalculateIncomePackages(int route, int package10, int package1020, int package20)
{
    decimal value;   
    if (route == 1 || route == 2)
    {
        if (package10 < 50) value = package10 * 100;
        else if (package10 < 100) value = package10 * 120;
        else if (package10 < 130) value = package10 * 150;
        else value = package10 * 160;
        if (package1020 + package20 < 50) value = value * 120;
        else if (package1020 + package20 < 100) value = value * 140;
        else if (package1020 + package20 < 130) value = value * 160;
        else value = value * 180;
    }
    else 
    {
        if (package10 < 50) value = package10 * 130;
        else if (package10 < 100) value = package10 * 160;
        else if (package10 < 130) value = package10 * 175;
        else value = package10 * 200;
        if (package1020 < 50) value = value * 140;
        else if (package1020 < 100) value = value * 180;
        else if (package1020 < 130) value = value * 200;
        else value = value * 250;
        if (package20 < 50) value = value * 170;
        else if (package20 < 100) value = value * 210;
        else if (package20 < 130) value = value * 250;
        else value = value * 300;
    }
    return value;
}

static decimal CalculateValueAssistant(decimal incomeTotals)
{
    if (incomeTotals < 1000000) return incomeTotals * 0.05M;
    if (incomeTotals < 2000000) return incomeTotals * 0.08M;
    if (incomeTotals < 4000000) return incomeTotals * 0.10M;
    return incomeTotals * 0.13M;
}

static decimal CalculateValueInsurance(decimal incomeTotals)
{
    if (incomeTotals < 1000000) return incomeTotals * 0.03M;
    if (incomeTotals < 2000000) return incomeTotals * 0.04M;
    if (incomeTotals < 4000000) return incomeTotals * 0.6M;
    return incomeTotals * 0.9M; 
}

static decimal CalculateValueGasoline(int route, int numberTrips, int numberPassengers, int package10, int package1020, int package20)
{
    decimal valueGallon = 8860M;
    decimal performance = 39M;
    decimal kilometres;
    if (route == 1) kilometres = numberTrips * 150;
    else if (route == 2) kilometres = numberTrips * 167;
    else if (route == 3) kilometres = numberTrips * 184;
    else kilometres = numberTrips * 204;

    decimal value = kilometres / performance * valueGallon;
    decimal weight= 76 * numberPassengers + package10 * 10 + package1020 * 15 + package20 * 20;
    if (weight <= 5000) return value * 0.75M;
    else if (weight <= 10000) return value * 1.1M * 0.75M;
    else return value * 1.25M * 0.75M;
}

static void ShowResults(decimal incomePassengers, decimal incomePackages,decimal  valueAssistant, decimal valueGasoline, decimal valueInsurance)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("*** CALCULATIONS ***");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Revenue per passenger............: ${0,12:N2} ", incomePassengers);
    Console.WriteLine("Revenue per Packages.............: ${0,12:N2} ", incomePackages);
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("                                 : ____________");
    Console.ForegroundColor = ConsoleColor.White;
    decimal totalIncome = incomePassengers + incomePackages;
    Console.WriteLine("Total revenues ..................: ${0,12:N2}\n ", totalIncome);
    Console.WriteLine("Payment to assistant.............: ${0,12:N2}", valueAssistant);
    Console.WriteLine("Payment Insurance................: ${0,12:N2}", valueInsurance);
    Console.WriteLine("Payment Gasoline.................: ${0,12:N2}", valueGasoline);
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("                                 : ____________");
    Console.ForegroundColor = ConsoleColor.White;
    decimal totalexpenses = valueAssistant + valueGasoline + valueInsurance;
    Console.WriteLine("Total expenses...................:  ${0,12:N2}\n ", totalexpenses);
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("                                 : ____________");
    Console.ForegroundColor = ConsoleColor.White;
    decimal totalToPay = totalexpenses + totalIncome;
    Console.WriteLine("Total deductions.................:  ${0,12:N2}\n", totalToPay);
    
}

bool RequestBool(string message)
{
    Console.Write(message);
    var response = Console.ReadLine();
    if (response!.ToLower() == "y")
    {
        return true;
    }
    return false;
}
