public class Fracao
{
    private int _numerador;
    private int _denominador;

    public Fracao(int Numerador, int Denominador)
    {
        ArgumentOutOfRangeException.ThrowIfZero(Denominador);
        int Divisor = Matematica.MDC(Numerador, Denominador);
        _numerador = Numerador / Divisor;
        _denominador = Denominador / Divisor;
    }

    public Fracao(int Inteiro)
    {
        _numerador = Inteiro;
        _denominador = 1;
    }

    public Fracao(string Expressao)
    {
        string[] Numeros = Expressao.Split("/");
        int Divisor = Matematica.MDC(int.Parse(Numeros[0]), int.Parse(Numeros[1]));
        _numerador = int.Parse(Numeros[0]) / Divisor;
        _denominador = int.Parse(Numeros[1]) / Divisor;
    }

    public Fracao(double Double)
    {
        string String = Double.ToString();
        double Casas = String.Split(",")[1].Length;
        int Inteiro = (int)(Double * Math.Pow(10, Casas));
        int Divisor = Matematica.MDC(Inteiro, (int)Math.Pow(10, Casas));
        _numerador = Inteiro / Divisor;
        _denominador = ((int)Math.Pow(10, Casas)) / Divisor;
    }

    public override string ToString()
    {
        return _numerador + "/" + _denominador;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Fracao Fracao)
        {
            return _numerador == Fracao.Numerador && _denominador == Fracao.Denominador;
        }
        return false;
    }

    public Fracao Somar(Fracao Fracao)
    {
        int Denominador = Matematica.MMC(_denominador, Fracao.Denominador);
        int Numerador = (Denominador / _denominador * _numerador) + (Denominador / Fracao.Denominador * Fracao.Numerador);
        return new Fracao(Numerador, Denominador);
    }

    public Fracao Somar(int Num1, int Num2)
    {
        return this.Somar(new Fracao(Num1, Num2));
    }

    public Fracao Somar(string Expressao)
    {
        return this.Somar(new Fracao(Expressao));
    }

    public Fracao Somar(int Inteiro)
    {
        return this.Somar(new Fracao(Inteiro));
    }

    public Fracao Somar(double Double)
    {
        return this.Somar(new Fracao(Double));
    }

    public static Fracao operator +(Fracao a, Fracao b)
    {
        return a.Somar(b);
    }

    public static Fracao operator +(Fracao a, int b)
    {
        return a.Somar(b);
    }

    public static Fracao operator +(Fracao a, string b)
    {
        return a.Somar(b);
    }

    public static Fracao operator +(Fracao a, double b)
    {
        return a.Somar(b);
    }

    public static bool operator ==(Fracao a, Fracao b)
    {
        return a.Equals(b);
    }

    public static bool operator !=(Fracao a, Fracao b)
    {
        return !a.Equals(b);
    }

    public static bool operator <(Fracao a, Fracao b)
    {
        return a.Double < b.Double;
    }

    public static bool operator >(Fracao a, Fracao b)
    {
        return a.Double > b.Double;
    }

    public static bool operator >=(Fracao a, Fracao b)
    {
        return a.Double > b.Double || a.Equals(b);
    }

    public static bool operator <=(Fracao a, Fracao b)
    {
        return a.Double < b.Double || a.Equals(b);
    }

    public int Numerador => _numerador;
    public int Denominador => _denominador;
    public double Double => ((double)_numerador) / ((double)_denominador);
    public bool IsImpropria => _numerador >= _denominador;
    public bool IsPropria => _numerador < _denominador;
    public bool IsAparente => _denominador == 1;
    public bool IsUnitaria => _numerador == 1;
    
}
