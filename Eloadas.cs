using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloadasProject
{
    public class Eloadas
    {
        private bool[,] foglalasok;

        public Eloadas(int sorokSzama, int helyekSzama)
        {

            if (sorokSzama < 1 || helyekSzama < 1)
            {

                throw new ArgumentException("A megadott paramétereknek 0-nál nagyobbnak kell lenniük!!");
            }
            foglalasok = new bool[sorokSzama, helyekSzama];
        }

        public bool Lefoglal()
        {
            bool foglalt = false;

            for (int i = 0; i < this.foglalasok.GetLength(0); i++)
            {

                for (int j = 0; j < this.foglalasok.GetLength(1); j++)
                {

                    if (this.foglalasok[i, j] == false)
                    {

                        this.foglalasok[i, j] = true;
                        foglalt = true;
                        break;
                    }
                }
                if (foglalt == true)
                {
                    break;
                }
            }
            return foglalt;
        }

        public int SzabadHelyek
        {
            get
            {
                int szabadHely = 0;
                for (int i = 0; i < this.foglalasok.GetLength(0); i++)
                {

                    for (int j = 0; j < this.foglalasok.GetLength(1); j++)
                    {

                        if (this.foglalasok[i, j] == false)
                        {
                            szabadHely++;
                        }
                    }
                }
                return szabadHely;
            }
        }

        public bool Teli
        {

            get
            {

                return SzabadHelyek == 0;
            }
        }

        public bool Foglalt(int sorSzam, int helySzam)
        {
            if (sorSzam < 1 || helySzam < 1)
            {

                throw new ArgumentException("A megadott paramétereknek 0-nál nagyobbnak kell lenniük!!");
            }
            return foglalasok[sorSzam - 1, helySzam - 1];
        }
    }
}

