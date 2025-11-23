using CustomMadeExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts
{
    public struct Contact
    {
        private int _officeNumber;



        public int OfficeNumber
        {
            get { return _officeNumber; }
            set
            {
                if (value == 0)
                {
                    throw new InValidWorkInfoException();
                }
                else
                {
                    _officeNumber = value;
                }
            }
        }

        private int _floor;

        public int Floor
        {
            get { return _floor; }

            set
            {
                if (value <= 0)
                {
                    throw new InValidWorkInfoException();
                }
                else
                {
                    _floor = value;
                }
            }
        }
        public Contact(int officenumber, int floor)
        {
            this.OfficeNumber = officenumber;
            this.Floor = floor;
        }
    }
}
