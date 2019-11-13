using System;

namespace Common
{
    public class Parameters
    {
        private const string _ConnectionString = "Server=LAPTOP-9LBNL0E3;Initial Catalog=KodotiSells;Integrated Security=true;";
        //public const string _ConnectionString = "Server=LAPTOP-9LBNL0E3;Initial Catalog=KodotiSells;User Id=sa;Password=123456";

        private static decimal _Iva = 0.15m;
        public static decimal IvaRate
        {
            get { return _Iva; }
            set { _Iva = value; }
        }

        public static string ConnectionString
        {
            get { return _ConnectionString; }            
        }


}
}
