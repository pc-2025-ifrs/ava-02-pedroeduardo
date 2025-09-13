static class Matematica
{
    public static int MDC(int Num1, int Num2)
    {
        int Menor;
        int Resultado = 1;
        if (Num1 < Num2)
        {
            Menor = Num1;
        }
        else
        {
            Menor = Num2;
        }
        for (int i = 1; i <= Menor; i++)
        {
            if (Num1 % i == 0 && Num2 % i == 0)
            {
                Resultado = i;
            }
        }
        return Resultado;
    }

    public static int MMC(int Num1, int Num2)
    {
        int Maior;
        if (Num1 > Num2)
        {
            Maior = Num1;
        }
        else
        {
            Maior = Num2;
        }
        int Resultado = Maior;
        while (Resultado % Num1 != 0 || Resultado % Num2 != 0)
        {
            Resultado += Maior;
        }
        return Resultado;
    }
}