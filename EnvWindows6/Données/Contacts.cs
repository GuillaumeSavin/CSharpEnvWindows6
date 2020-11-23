using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvWindows6.Données
{
    class Contacts : ObservableCollection<Contact>
    {
        public void chargementContacts()
        {
            this.Add(new Contact("Savin", "Guillaume", "00000000"));
            this.Add(new Contact("Kayser/Calderon", "Peggy", "00000001"));
            this.Add(new Contact("Lecat", "Rosa", "00000002"));
        }

        public Contact this[Contact contactGiven]
        {
            get
            {
                Contacts cont = this;

                foreach(Contact c in cont)
                {
                    if(c == contactGiven)
                    {
                        return c;
                    }
                }

                return null;
            }
        }   
    }
}
