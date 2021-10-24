using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioVeicoli
{
    class Veicolo
    {
        /*
         * In c#, Inheritance is one of the primary concepts of object-oriented 
         * programming (OOP), and it is used to inherit the properties from one 
         * class (base) to another (child) class.
         * The inheritance will enable us to create a new class by inheriting 
         * the properties from other classes to reuse, extend, and modify other 
         * class members' behavior based on our requirements. 
         * In c# inheritance, the class whose members are inherited is called 
         * a base (parent) class, and the class that inherits the members of the 
         * base (parent) class is called a derived (child) class.
         * 
         * <access_modifier> class <base_class_name>
         * {
         *      // Base class Implementation
         * }
         * 
         * <access_modifier> class <derived_class_name> : <base_class_name>
         * {
         *      // Derived class implementation
         * }
         * 
         */
        public String Targa { get; set; }
        public String Modello { get; set; }
        public double TariffaGiornaliera { get; set; }
        public Veicolo()
        {

        }

        public Veicolo(String t, String m, double tG)
        {
            this.Targa = t;
            this.Modello = m;
            this.TariffaGiornaliera = tG;
        }
    }
}
