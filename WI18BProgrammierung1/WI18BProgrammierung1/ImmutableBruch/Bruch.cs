using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmutableBruch
{
    public sealed class Bruch : IBruchMethoden, IOrdnung
    {

        //Attribute
        private readonly long zähler;
        private readonly long nenner;

        public Bruch(long zähler, long nenner)
        {
            this.zähler = zähler;
            this.nenner = nenner;
        }

        public Bruch Add(Bruch b)
        {
            long gemeinsamerNenner = this.nenner * b.nenner;
            long neuerZähler = this.zähler * b.nenner + b.zähler * this.nenner;
            Bruch c = new Bruch(neuerZähler, gemeinsamerNenner);

            return c.Kürze();
        }

        public Bruch Divi(Bruch b)
        {
            return new Bruch(this.zähler * b.nenner, this.nenner * b.zähler);
        }

        public bool IsEqual(Bruch b)
        {
            b.Kürze();
            
            if(this.zähler == b.zähler && this.nenner == b.nenner)
            {
                return true;
            }
            return false; 
        }

        public Bruch KehrWert()
        {
            return new Bruch(this.nenner, this.zähler);
        }

        public Bruch Kürze()
        {
            long teiler = GrößterGemeinsamerTeiler(this.zähler, this.nenner);
            return new Bruch(this.zähler/teiler, this.nenner/teiler);
        }

        public Bruch Multi(Bruch b)
        {
            return new Bruch(this.zähler * b.zähler, b.nenner * this.nenner);
        }

        public Bruch Negiere()
        {
            return new Bruch(-this.zähler, -this.nenner);
        }

        public Bruch Potenz(int p)
        {
            int a = (int)Math.Pow(this.zähler, p);
            int b = (int)Math.Pow(this.nenner, p);

            return new Bruch(a,b).Kürze();
        }

        public Bruch Sub(Bruch b)
        {
            return (this.Add(b.Negiere())).Kürze();
        }

        public override String ToString()
        {
            return this.zähler + "/" + this.nenner;
        }

        public double Betrag()
        {
            return (double)(this.zähler / this.nenner);
        }


        private long GrößterGemeinsamerTeiler(long a, long b)
        {

            if (a < 0)
            {
                a = -a;
            }

            if (b < 0)
            {
                b = -b;
            }

            if (a == 0)
            {
                return b;
            }

            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }

                else
                {
                    b -= a;
                }
            }
            return a;
        }

        public bool Ordnung(object o)
        {
            if(o.GetType() == typeof(Bruch) )
            {
                Bruch b = (Bruch)o;
                return this.Betrag() < b.Betrag();
            }

            return false;


        }
    }
}
