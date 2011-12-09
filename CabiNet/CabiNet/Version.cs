
namespace CabiNet
{
    class Version
    {

        public const string Author = "Bruno Lara Tavares";
        public const string License = "LGPL";
        public const int Major = 0;
        public const int Medio = 1;
        public const int Minor = 0;


        public override string ToString()
        {
            return string.Format("{0}.{1}.{2}", Major, Medio, Minor);
        }
    }

}
