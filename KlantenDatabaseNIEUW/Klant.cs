namespace KlantenDatabaseNIEUW
{
    internal class Klant
    {
        public Klant(string aName, int anAge, string anEmail, bool isAuthorized, string aPassword, int anID)
        {
            name = aName;
            age = anAge;
            Email = anEmail;
            Authorization = isAuthorized;
            Password = aPassword;
            ID = anID;

        }
        public string name = "exampleName";
        public int age = 23;
        public string Email = "example@ramancooporation.com";
        public bool Authorization = false;
        public string Password = "password";
        public int ID = 000;
    }
}
