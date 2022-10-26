using System;

namespace Managment.ExtensionMethods
{
    public static class ExtensionMethods
    {
        public static double NetPaymantCalculation(this int brutto)
        {
            // Punkt 1 - Ustalenie wysokości składek na ubezpieczenia społeczne finansowanych przez pracownika, tj. 13,71 % i odjecie ich
            // od wynagrodzenia brutto
            double ubezpieczeniaSpoleczne = (double)brutto * 0.1371;

            // Punkt 2 - Podstawa wymiaru skladki zdrowotnej => brutto - ubezpieczeniaSpoleczne
            double podstawaSkaldkiZdrowotnej = brutto - ubezpieczeniaSpoleczne;

            // Punkt 3 - Skladka zdrowotna - 9% ZUS
            double zdrowotnaZUS = podstawaSkaldkiZdrowotnej * 0.09;

            // Punkt 4 - Skladka zdrowotna odliczenie - 7,75%
            double zdrowotnaOdliczenie = podstawaSkaldkiZdrowotnej * 0.0775;

            // Punkt 5 - Podstawa zaliczki do Urzedu Skarbowego( podstawa-250 )
            double podstawaUrzadSkarbowy = podstawaSkaldkiZdrowotnej - 250;

            // Punkt 6 - Zalicznka na podatek w wysokosci 17% przychodzu minus 43,76(koszt zmniejszajacy podatek)
            double zaliczkaPodatek = (podstawaUrzadSkarbowy  * 0.17) - 43.76;

            // Punkt 7 - Wysokos zaliczki do US => zaliczka na podatek - skladka zdrowotna odliczenie
            double zaliczkaUrzadSkarbowy = zaliczkaPodatek - zdrowotnaOdliczenie;

            // Punkt 8 - Ustalenie kwoty netto => brutto - 
            double netto = brutto - ubezpieczeniaSpoleczne - zdrowotnaZUS - zaliczkaUrzadSkarbowy;

            return netto;
        }
    }
}

