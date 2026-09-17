(double a, int n)[] numbersTest =
{
            (2, 2),
            (2, 0),
            (-2, 3),
            (2, -3),
            (-2, -3),
            (0, 2),
            (0, -1),
        };

foreach (var test in numbersTest)
{
    try
    {
        double resultPower = Power(test.a, test.n);
        Console.WriteLine($"a = {test.a}, n = {test.n} = {resultPower:0.000}");
    }
    catch (DivideByZeroException e)
    {
        Console.WriteLine($"a = {test.a}, n = {test.n} = {e.Message}");
    }
}
Console.WriteLine();

string[] passwordsTests =
{
            "Qwerty17$",
            "Qwerty17",
            "qwerty17$",
            "QWERTY17$",
            "Qwertyuio$",
            "Qwer17$",
            "Qwerty17$38924fdjkasfsd@493asdfksdfa;hjfgdhk",
            "йцукен17$",
            ""
        };

foreach (var test in passwordsTests)
{
    try
    {
        string resultPassword = Checking(test);
        Console.WriteLine(resultPassword);
    }
    catch (DivideByZeroException e)
    {
        Console.WriteLine(e.Message);
    }
}

static double Power(double a, int n)
{
    if (a == 0 && n < 0)
        throw new DivideByZeroException("Деление на 0 невозможно");

    if (n == 0)
        return 1.0;

    double result = 1.0;
    int nAbs = Math.Abs(n);

    for (int i = 0; i < nAbs; i++)
        result *= a;

    if (n < 0)
        result = 1.0 / result;

    return Math.Round(result, 3);
}
static string Checking(string password)
{
    string specialSymbols = "!@#$%^&*(),.";

    if (password == null)
        return "Пустая строка";

    return "Надёжный пароль";
}
