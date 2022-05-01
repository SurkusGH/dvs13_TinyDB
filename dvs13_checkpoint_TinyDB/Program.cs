using dvs13_checkpoint_TinyDB.Functions;
using System;

namespace dvs13_checkpoint_TinyDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("dvs13_checkpoint_TinyDB!");
            #region Problem/Task

            //          Studentų informacinė sistema:
            // ENTITIES:
            // (1.1) Departamentas. Turi: Daug studentų, daug paskaitų;
            // (1.2) Paskaita. Turi: Daug departamentų;
            // (1.3) Studentas. Turi: Daug paskaitų, vieną departamentą.

            // FUNKCIONALUMAI:
            // (2.1) Sukurti departamentą ir į jį pridėti studentus, paskaitas(papildomi points
            //       jei pridedamos paskaitos jau egzistuojančios duomenų bazėje);
            // (2.2) Pridėti studentus / paskaitas į jau egzistuojantį departamentą;
            // (2.3) Sukurti paskaitą ir ją priskirti prie departamento;
            // (2.4) Sukurti studentą, jį pridėti prie egzistuojančio departamento ir priskirti jam
            //       egzistuojančias paskaitas;
            // (2.5) Perkelti studentą į kitą departamentą(bonus points jei pakeičiamos ir jo paskaitos);
            // (2.6) Atvaizduoti visus departamento studentus;
            // (2.7) Atvaizduoti visas departamento paskaitas;
            // (2.8) Atvaizduoti visas paskaitas pagal studentą.

            #endregion

            #region ConsoleCommands

            // Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 5.0.10
            // Install-Package Microsoft.EntityFrameworkCore.Tools -Version 5.0.10

            // Add-Migration InitialCreate
            // Update-Database

            #endregion

            Root.Menu();

        }
    }
}
