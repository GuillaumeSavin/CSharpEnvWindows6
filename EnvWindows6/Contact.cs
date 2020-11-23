using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvWindows6
{
    class Contact
    {
        private String nom;
        private String prenom;
        private String numero;

        public Contact(String _nom, String _prenom, String _numero)
        {
            this.nom = _nom;
            this.prenom = _prenom;
            this.numero = _numero;
        }

        public String Nom
        {
            get => nom;
            set => nom = value;
        }

        public String Prénom
        {
            get => prenom;
            set => prenom = value;
        }

        public String Numéro
        {
            get => numero;
            set => numero = value;
        }

        public String ContactString
        {
            get
            {
                return nom + " " + prenom;
            }
        }
    }
}
