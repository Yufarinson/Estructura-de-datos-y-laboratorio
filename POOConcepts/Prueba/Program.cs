using System;

class Program
{
    static void Main()
    {
        // Lectura de datos de entrada
        Console.WriteLine("*** DATOS DE ENTRADA ***");
        Console.Write("Ruta [1][2][3][4]: ");
        int ruta = int.Parse(Console.ReadLine());
        Console.Write("Número de viajes: ");
        int viajes = int.Parse(Console.ReadLine());
        Console.Write("Número de pasajeros total: ");
        int pasajeros = int.Parse(Console.ReadLine());
        Console.Write("Número de encomiendas de menos de 10Kg: ");
        int encomMenos10 = int.Parse(Console.ReadLine());
        Console.Write("Número de encomiendas entre 10Kg y menos de 20Kg: ");
        int encomEntre10y20 = int.Parse(Console.ReadLine());
        Console.Write("Número de encomiendas de más de 20Kg: ");
        int encomMas20 = int.Parse(Console.ReadLine());

        // 1. Calcular ingresos por pasajeros.
        double baseRuta = 0;
        double tasaComision = 0;
        double extraFijo = 0; // monto extra por cada pasajero adicional a 200
        switch (ruta)
        {
            case 1:
                baseRuta = 500000;
                if (pasajeros < 50)
                    tasaComision = 0;
                else if (pasajeros <= 100)
                    tasaComision = 0.05;
                else if (pasajeros <= 150)
                    tasaComision = 0.06;
                else if (pasajeros <= 200)
                    tasaComision = 0.07;
                else
                {
                    tasaComision = 0.07;
                    extraFijo = 50;
                }
                break;
            case 2:
                baseRuta = 600000;
                if (pasajeros < 50)
                    tasaComision = 0;
                else if (pasajeros <= 100)
                    tasaComision = 0.07;
                else if (pasajeros <= 150)
                    tasaComision = 0.08;
                else if (pasajeros <= 200)
                    tasaComision = 0.09;
                else
                {
                    tasaComision = 0.09;
                    extraFijo = 60;
                }
                break;
            case 3:
                baseRuta = 800000;
                if (pasajeros < 50)
                    tasaComision = 0;
                else if (pasajeros <= 100)
                    tasaComision = 0.10;
                else if (pasajeros <= 150)
                    tasaComision = 0.13;
                else if (pasajeros <= 200)
                    tasaComision = 0.15;
                else
                {
                    tasaComision = 0.15;
                    extraFijo = 100;
                }
                break;
            case 4:
                baseRuta = 1000000;
                if (pasajeros < 50)
                    tasaComision = 0;
                else if (pasajeros <= 100)
                    tasaComision = 0.125;
                else if (pasajeros <= 150)
                    tasaComision = 0.15;
                else if (pasajeros <= 200)
                    tasaComision = 0.17;
                else
                {
                    tasaComision = 0.17;
                    extraFijo = 150;
                }
                break;
        }
        double ingresoBasePasajeros = viajes * baseRuta;
        double comisionPasajeros = 0;
        if (pasajeros <= 50)
            comisionPasajeros = 0;
        else if (pasajeros <= 200)
            comisionPasajeros = ingresoBasePasajeros * tasaComision;
        else
            comisionPasajeros = ingresoBasePasajeros * tasaComision + (pasajeros - 200) * extraFijo;
        double ingresosPasajeros = ingresoBasePasajeros + comisionPasajeros;

        // 2. Calcular ingresos por encomiendas.
        double ingresosEncomiendas = 0;
        if (ruta == 1 || ruta == 2)
        {
            // Para rutas 1 y 2: se tienen dos categorías.
            double precioMenos10 = (encomMenos10 < 50) ? 100 :
                                    (encomMenos10 <= 100) ? 120 :
                                    (encomMenos10 <= 130) ? 150 : 160;
            // Para los paquetes que pesan 10Kg o más (se suman ambas categorías)
            int totalEncomiendasMayorIgual10 = encomEntre10y20 + encomMas20;
            double precioMayorIgual10 = (totalEncomiendasMayorIgual10 < 50) ? 120 :
                                        (totalEncomiendasMayorIgual10 <= 100) ? 140 :
                                        (totalEncomiendasMayorIgual10 <= 130) ? 160 : 180;
            ingresosEncomiendas = (encomMenos10 * precioMenos10) +
                                  (totalEncomiendasMayorIgual10 * precioMayorIgual10);
        }
        else if (ruta == 3 || ruta == 4)
        {
            // Para rutas 3 y 4: tres categorías
            double precioMenos10 = (encomMenos10 < 50) ? 130 :
                                    (encomMenos10 <= 100) ? 160 :
                                    (encomMenos10 <= 130) ? 175 : 200;
            double precioEntre10y20 = (encomEntre10y20 < 50) ? 140 :
                                       (encomEntre10y20 <= 100) ? 180 :
                                       (encomEntre10y20 <= 130) ? 200 : 250;
            double precioMas20 = (encomMas20 < 50) ? 170 :
                                 (encomMas20 <= 100) ? 210 :
                                 (encomMas20 <= 130) ? 250 : 300;
            ingresosEncomiendas = (encomMenos10 * precioMenos10) +
                                  (encomEntre10y20 * precioEntre10y20) +
                                  (encomMas20 * precioMas20);
        }
        double totalIngresos = ingresosPasajeros + ingresosEncomiendas;

        // 3. Calcular el pago por combustible.
        // Distancia según la ruta:
        double distancia = (ruta == 1) ? 150 :
                           (ruta == 2) ? 167 :
                           (ruta == 3) ? 184 : 203;
        double costoGalon = 8860;
        double rendimiento = 39; // km/galón

        // Consumo de combustible (costo total) para una vía:
        double costoCombustiblePorViaje = (distancia / rendimiento) * costoGalon;
        // El conductor paga el 75% (subsidio del 25%)
        double costoCombustibleDriverPorViaje = costoCombustiblePorViaje * 0.75;
        // Suponiendo que se gasta combustible en cada viaje:
        double costoCombustibleTotal = costoCombustibleDriverPorViaje * viajes;

        // Calcular el peso total en el bus:
        double pesoPasajeros = pasajeros * 60; // 60Kg por pasajero
        // Asumimos pesos promedio para las encomiendas:
        double pesoPromMenos10 = 8.0;    // Kg promedio para paquetes <10Kg
        double pesoPromEntre10y20 = 15.0; // Kg promedio para paquetes entre 10 y <20Kg
        double pesoPromMas20 = 25.0;      // Kg promedio para paquetes ≥20Kg
        double pesoEncomiendas = (encomMenos10 * pesoPromMenos10) +
                                 (encomEntre10y20 * pesoPromEntre10y20) +
                                 (encomMas20 * pesoPromMas20);
        double pesoTotal = pesoPasajeros + pesoEncomiendas;
        double factorPeso = 1.0;
        if (pesoTotal <= 5000)
            factorPeso = 1.0;
        else if (pesoTotal <= 10000)
            factorPeso = 1.10;
        else
            factorPeso = 1.25;
        double pagoCombustible = costoCombustibleTotal * factorPeso;

        // 4. Calcular deducciones: Pago al ayudante y seguro, en función del total de ingresos.
        double pagoAyudante = 0;
        double pagoSeguro = 0;
        if (totalIngresos < 1000000)
        {
            pagoAyudante = totalIngresos * 0.05;
            pagoSeguro = totalIngresos * 0.03;
        }
        else if (totalIngresos <= 2000000)
        {
            pagoAyudante = totalIngresos * 0.08;
            pagoSeguro = totalIngresos * 0.04;
        }
        else if (totalIngresos <= 4000000)
        {
            pagoAyudante = totalIngresos * 0.10;
            pagoSeguro = totalIngresos * 0.06;
        }
        else
        {
            pagoAyudante = totalIngresos * 0.13;
            pagoSeguro = totalIngresos * 0.09;
        }
        double totalDeducciones = pagoAyudante + pagoSeguro + pagoCombustible;
        double totalLiquidar = totalIngresos - totalDeducciones;

        // 5. Mostrar resultados
        Console.WriteLine("\n*** CALCULOS ***");
        Console.WriteLine("Ingresos por Pasajeros: " + ingresosPasajeros);
        Console.WriteLine("Ingresos por Encomiendas: " + ingresosEncomiendas);
        Console.WriteLine("TOTAL INGRESOS: " + totalIngresos);
        Console.WriteLine("Pago Ayudante: " + pagoAyudante);
        Console.WriteLine("Pago Seguro: " + pagoSeguro);
        Console.WriteLine("Pago Combustible: " + pagoCombustible);
        Console.WriteLine("TOTAL DEDUCCIONES: " + totalDeducciones);
        Console.WriteLine("TOTAL A LIQUIDAR: " + totalLiquidar);
        Console.WriteLine("\nValor a liquidar al conductor: " + totalLiquidar);
        Console.WriteLine("Valor a liquidar al ayudante: " + pagoAyudante);
    }
}
