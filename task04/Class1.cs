namespace task04;

public interface ISpaceship
{
    void MoveForward();      // Движение вперед
    void Rotate(int angle);  // Поворот на угол (градусы)
    void Fire();             // Выстрел ракетой
    int Speed { get; }       // Скорость корабля
    int FirePower { get; }   // Мощность выстрела
}

public class Fighter : ISpaceship
{
    private int _speed = 100;
    private int _firePower = 50;
    public int Speed
    {
        get { return _speed; }
        set { _speed = 100; }
    }
    public int FirePower
    {
        get { return _firePower; }
        set { _firePower = 10; }
    }

    public void Fire()
    {
        Console.WriteLine("Стреляет");
    }

    public void MoveForward()
    {
        Console.WriteLine("Летит вперед");
    }

    public void Rotate(int angle)
    {
        Console.WriteLine( "Поворачивает на {angle}");
    }
}
public class Cruiser : ISpaceship
{
    private int _speed = 50;
    private int _firePower = 100;
    public int Speed
    {
        get { return _speed; }
        set { _speed = 50; }
    }
    public int FirePower
    {
        get { return _firePower; }
        set { _firePower = 100; }
    }

    public void Fire()
    {
        Console.WriteLine("Не стреляет");
    }

    public void MoveForward()
    {
        Console.WriteLine("Летит назад");
    }

    public void Rotate(int angle)
    {
        Console.WriteLine("Поворачивает на {angle}");
    }
}
