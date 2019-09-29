using System;

namespace Common
{
    public class Parameters
    {
        public const string _ConnectionString = "Server=LAPTOP-9LBNL0E3;Initial Catalog=KodotiSells;Integrated Security=true;";
        //public const string _ConnectionString = "Server=LAPTOP-9LBNL0E3;Initial Catalog=KodotiSells;User Id=sa;Password=123456";

        public static string ConnectionString
        {
            get { return _ConnectionString; }            
        }
}
}
