using NAudio.Wave;


/*Things to be fixed
 */

namespace KlantenDatabaseNIEUW
{
    internal class Program
    {
        static bool isPlaying = false;
        static List<Klant> KlantList = new List<Klant>();
        static List<Klant> KlantenList = new List<Klant>();
        static int sts = 1000; // System Threading Sleep, for faster running. Original: 1000
        static int sts2 = 500; // System Threading Sleep, for faster running, Original: 500.

        static string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        static async Task Main()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "RamanCooporation_Log.txt")))
            {
                await outputFile.WriteLineAsync("# Action Logger made by /bambito =))");
                await outputFile.WriteLineAsync($"# Started logging at: {DateTime.Now}");
                await outputFile.WriteLineAsync("");

            }
            Klant Raman = new Klant("Ramandeep Singh", 16, "bamba@ramanmail.com", true, "ramannoodles", 001);
            Klant sudo = new Klant("/root/", 0, "root", true, "root", 000); // uncomment if debugging finished 
            Klant Jan = new Klant("Jan Pannenkoek", 35, "janpannenkoek@ramanmail.com", false, "wachtwoord", 002);
            Klant Aykan = new Klant("Aykan", 17, "Aykan@ramanmail.com", false, "wachtwoord", 003);
            Klant aurėja = new Klant("aurėja", 17, "madebyGenAI@ramanmail.com", false, "wachtwoord", 069);
            Klant Ozan = new Klant("Ozan", 24, "Ozan@ramanmail.com", false, "wachtwoord", 004);
            Klant Trevor = new Klant("Trevor kinyanjui", 17, "Trevor@ramanmail.com", false, "wachtwoord", 005);
            Klant Julian = new Klant("Julian Caeser", 17, "Julian@ramanmail.com", false, "wachtwoord", 006);
            Klant Aman = new Klant("Aman Prithipsl", 16, "AmanYaeger@gmail.com", false, "wachtwoord", 007);
            Klant Calvin = new Klant("Calvin Kuik", 16, "Calvin@ramanmail.com", false, "wachtwoord", 008);
            Klant Eliza = new Klant("Eliza Mohamed", 16, "eliza@ramanmail.com", false, "wachtwoord", 009);
            Klant Dasha = new Klant("Dasha Postma", 19, "Dasha@ramanmail.com", false, "wachtwoord", 010);
            Klant Ruben = new Klant("Ruben Veringa", 47, "Ruben@ramanmail.com", false, "wachtwoord", 011);
            Klant Nohmi = new Klant("Nohmi Jaguar", 22, "Nohmi@ramanmail.com", false, "wachtwoord", 012);
            Klant Dani = new Klant("Dani Jaguar", 65, "Dani@ramanmail.com", false, "wachtwoord", 013);
            Klant pookie = new Klant("Pookie.IO", 16, "pookiebear.io@gmail.com", false, "wachtwoord", 014);



            KlantList.Add(Raman);   //KlantList is the list for admins!!
            KlantList.Add(sudo);
            KlantenList.Add(Raman); //KlantenList is the regular list to add any user to.
            KlantenList.Add(Jan);
            KlantenList.Add(Aykan);
            KlantenList.Add(Ozan);
            KlantenList.Add(Trevor);
            KlantenList.Add(Julian);
            KlantenList.Add(Aman);
            KlantenList.Add(Calvin);
            KlantenList.Add(Eliza);
            KlantenList.Add(Dasha);
            KlantenList.Add(Ruben);
            KlantenList.Add(Nohmi);
            KlantenList.Add(Dani);
            KlantenList.Add(pookie);




            while (true) // This loop is to ensure the user cannot break out the menu.
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("Welcome in the Customer Database of Raman Cooperation.");
                Console.WriteLine("");
                Console.WriteLine("1 - View Users");
                Console.WriteLine("2 - Edit Users");
                Console.WriteLine("3 - Add Users");
                Console.WriteLine("4 - Remove Users");
                Console.WriteLine("5 - Exit");
                Console.WriteLine("");


                Console.WriteLine("Enter Choice");
                string keuze = Console.ReadLine();
                int choice = 0;
                int.TryParse(keuze, out choice);

                switch (choice)
                {
                    case 0:

                        break;
                    case 1:
                        ViewRegisteredUsers();
                        break;
                    case 2:
                        EditRegisteredUsers();
                        break;
                    case 3:
                        AddRegisteredUsers();
                        break;
                    case 4:
                        RemoveRegisteredUsers();
                        break;
                    case 5:
                        using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "RamanCooporation_Log.txt"), true))
                        {
                            await outputFile.WriteLineAsync($"{DateTime.Now} - Terminal Exited.");
                        }
                        Console.WriteLine("Actions logged to My Documents.");
                        Environment.Exit(0);
                        break;

                }
                Console.Clear();

            }




        }

        #region viewusers
        static async void ViewRegisteredUsers()
        {
            Console.Clear();
            Console.WriteLine("View users.");
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "RamanCooporation_Log.txt"), true))
            {
                await outputFile.WriteLineAsync($"{DateTime.Now} - Users have been viewed.");
            }


            foreach (var klant in KlantenList)
            {
                Console.WriteLine($"Name: {klant.name}, Age: {klant.age}, Email: {klant.Email}");
            }

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }

        #endregion


        #region edituser
        static async void EditRegisteredUsers()
        {
            bool emailAuthenticated = false;
            bool passwordAuthenticated = false;
            Console.Clear();
            Console.WriteLine("You have pressed to Edit the registered users.");
            Console.WriteLine("You must require admin permissions to edit a user. Please authorize.");

            string emailAuthorize;
            string passwordAuthorize;

            while (true)
            {
                Console.WriteLine();
                Console.Write("Email: ");
                emailAuthorize = Console.ReadLine();
                System.Threading.Thread.Sleep(sts2);

                for (int i = 0; i < KlantList.Count; i++)
                {
                    if (emailAuthorize == KlantList[i].Email)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine($"Welcome {emailAuthorize}.");

                        emailAuthenticated = true;
                    }
                }



                if (emailAuthenticated)
                {

                    break;
                }

                Console.WriteLine("Invalid email. Please try again.");


            }


            while (true)
            {
                Console.WriteLine();
                Console.Write("Password: ");
                passwordAuthorize = Console.ReadLine();
                System.Threading.Thread.Sleep(sts2);
                for (int i = 0; i < KlantList.Count; i++)
                {
                    if (passwordAuthorize == KlantList[i].Password)
                    {

                        Console.WriteLine($"Welcome {passwordAuthorize}. Please input your Password.");
                        passwordAuthenticated = true;
                    }
                }



                if (passwordAuthenticated)
                {
                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "RamanCooporation_Log.txt"), true))
                    {
                        await outputFile.WriteLineAsync($"{DateTime.Now} - {emailAuthorize} has authenticated to edit users.");
                    }
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    break;
                }

                Console.WriteLine("Invalid password. Please try again.");
            }

            Console.Clear();
            Console.WriteLine("Welcome in the user database.");
            Console.WriteLine($"Successfully authorized as: {emailAuthorize}");
            var url = "https://github.com/Bambaclad1/test-website/raw/main/mario%20kart%20wii%20loading%20sound%20effect%20when%20you%20go%20on%20nintendo%20WFC.mp3";
            using (var mf = new MediaFoundationReader(url))
            using (var wo = new WasapiOut())
            {
                wo.Init(mf);
                wo.Play();
                while (wo.PlaybackState == PlaybackState.Playing)
                {
                    System.Threading.Thread.Sleep(sts2);
                    Console.Write(".");
                    System.Threading.Thread.Sleep(sts2);
                    Console.Write(".");
                    System.Threading.Thread.Sleep(sts2);
                    Console.Write(".");
                    System.Threading.Thread.Sleep(sts2);
                }
            }
            // ... (previous code remains unchanged)

            bool check1 = false;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Which user to edit? Specify their name.");
                foreach (var klant in KlantenList)
                {
                    Console.WriteLine($"Name: {klant.name}, Age: {klant.age}, Email: {klant.Email}");
                }
                Console.WriteLine("Edit who?");
                string edit = Console.ReadLine();
                int newAge;

                for (int i = 0; i < KlantenList.Count; i++)
                {
                    if (edit == KlantenList[i].name)
                    {
                        Console.Clear();
                        Console.WriteLine($"Editing user: {KlantenList[i].name}, please input the user's new name.");
                        string newName = Console.ReadLine();

                        if (!string.IsNullOrEmpty(newName))
                        {
                            check1 = true;
                            Console.WriteLine("Enter new age: ");
                            string newAge1 = Console.ReadLine();

                            if (int.TryParse(newAge1, out newAge) && newAge > 0 && newAge < 100)
                            {
                                Console.WriteLine("Enter new email (@ramanmail will be added at the end)");
                                string newEmail = Console.ReadLine() + "@ramanmail.com";

                                if (!string.IsNullOrEmpty(newEmail))
                                {
                                    KlantenList[i].name = newName;
                                    KlantenList[i].age = newAge;
                                    KlantenList[i].Email = newEmail;
                                    Console.WriteLine("User information updated successfully.");
                                    Console.WriteLine("\nPress Enter to continue...");
                                    Console.ReadLine();
                                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "RamanCooporation_Log.txt"), true))
                                    {
                                        await outputFile.WriteLineAsync($"{DateTime.Now} - {emailAuthorize} edited user {edit}.");
                                    }
                                    return; // Exit the method after successful update
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Invalid email input. Please retry.");
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid age input. Please retry.");
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid or empty name. Please retry.");
                        }
                    }
                }
                if (!check1)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input or name not found in the database. Please retry.");
                    Console.WriteLine("\nPress Enter to continue...");
                    Console.ReadLine();
                }
            }
        }
        #endregion






        #region addUser
        static async void AddRegisteredUsers()
        {
            List<Klant> Customer = new List<Klant>();
            bool emailAuthenticated = false;
            bool passwordAuthenticated = false;

            Console.Clear();
            Console.WriteLine("You must require admin permissions to add users. Please authorize.");
            string emailAuthorize;
            string passwordAuthorize;

            while (true)
            {
                Console.WriteLine();
                Console.Write("Email: ");
                emailAuthorize = Console.ReadLine();
                System.Threading.Thread.Sleep(sts2);

                for (int i = 0; i < KlantList.Count; i++)
                {
                    if (emailAuthorize == KlantList[i].Email)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine($"Welcome {emailAuthorize}.");

                        emailAuthenticated = true;
                    }
                }



                if (emailAuthenticated)
                {

                    break;
                }
                Console.Clear();
                Console.WriteLine("Invalid email. Please try again.");


            }


            while (true)
            {
                Console.WriteLine();
                Console.Write("Password: ");
                passwordAuthorize = Console.ReadLine();
                System.Threading.Thread.Sleep(sts2);
                for (int i = 0; i < KlantList.Count; i++)
                {
                    if (passwordAuthorize == KlantList[i].Password)
                    {

                        Console.WriteLine($"Welcome {passwordAuthorize}. Please input your Password.");
                        passwordAuthenticated = true;
                    }
                }



                if (passwordAuthenticated)
                {
                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "RamanCooporation_Log.txt"), true))
                    {
                        await outputFile.WriteLineAsync($"{DateTime.Now} - {emailAuthorize} has authenticated to add users.");
                    }
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    break;
                }
                Console.Clear();
                Console.WriteLine("Invalid password. Please try again.");
            }

            Console.Clear();
            Console.WriteLine("Welcome in the user database.");
            Console.WriteLine($"Successfully authorized as: {emailAuthorize}");
            var url2 = "https://github.com/Bambaclad1/test-website/raw/main/mario%20kart%20wii%20loading%20sound%20effect%20when%20you%20go%20on%20nintendo%20WFC.mp3";
            using (var mf = new MediaFoundationReader(url2))
            using (var wo = new WasapiOut())
            {
                wo.Init(mf);
                wo.Play();
                while (wo.PlaybackState == PlaybackState.Playing)
                {
                    Console.Write(".");
                    System.Threading.Thread.Sleep(sts2);
                    Console.Write(".");
                    System.Threading.Thread.Sleep(sts2);
                    Console.Write(".");
                    System.Threading.Thread.Sleep(sts2);
                }
            }
            Console.Clear();
            isPlaying = true;
            int count = 0;

            var url = "https://github.com/Bambaclad1/test-website/raw/main/youtube_wlfxjNeViHk_audio.mp3";
            using (var mf = new MediaFoundationReader(url))
            using (var wo = new WasapiOut())
                if (isPlaying)
                {
                    {

                        wo.Init(mf);
                        wo.Play();
                        while (wo.PlaybackState == PlaybackState.Playing)
                        {
                            while (true)
                            {

                                string fullName;
                                System.Threading.Thread.Sleep(sts2);
                                Console.WriteLine("Welcome to the add a new user setup!");
                                Console.WriteLine("");
                                Console.WriteLine("Enter the new person's full name:");
                                fullName = Console.ReadLine();

                                Klant newCustomer = new Klant(fullName, 0, "", false, "", 0);

                                if (!string.IsNullOrEmpty(fullName) && fullName.Equals(newCustomer.name))

                                {
                                    Console.WriteLine("Username set!");
                                    System.Threading.Thread.Sleep(sts2);
                                    Console.Clear();

                                    int aAge;
                                    Console.WriteLine("Enter the new person's age.");
                                    string age = Console.ReadLine();
                                    int.TryParse(age, out aAge);
                                    newCustomer.age = aAge;

                                    if (newCustomer.age > 0 && newCustomer.age < 100)
                                    {
                                        Console.WriteLine("Age set!");
                                        System.Threading.Thread.Sleep(sts2);
                                        Console.Clear();
                                        Console.WriteLine("Please make a email for this person. The domain @ramanmail.com will be automatically added.");
                                        string email = Console.ReadLine();
                                        newCustomer.Email = email + "@ramanmail.com";

                                        if (!string.IsNullOrEmpty(email))

                                        {
                                            KlantenList.Add(newCustomer);

                                            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "RamanCooporation_Log.txt"), true))
                                            {
                                                await outputFile.WriteLineAsync($"{DateTime.Now} - {emailAuthorize} has added user {fullName}.");
                                            }

                                            char aChar = '?';
                                            string action = "null";
                                            Console.Clear();
                                            System.Threading.Thread.Sleep(sts2);
                                            Console.WriteLine("Successfully made user!");
                                            Console.WriteLine();
                                            Console.WriteLine("Would you like to make another user?");
                                            Console.WriteLine("Y/N");
                                            action = Console.ReadLine();
                                            char.TryParse(action, out aChar);

                                            if (aChar == 'y' || aChar == 'Y')
                                            {
                                                System.Threading.Thread.Sleep(sts);
                                                count = count + 1;
                                                Console.Clear();
                                                Console.WriteLine("You have registered " + count + " user(s)! =)))");
                                                Console.WriteLine("");
                                            }
                                            else if (aChar == 'n' || aChar == 'N')
                                            {
                                                Console.Clear();
                                                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "RamanCooporation_Log.txt"), true))
                                                {
                                                    await outputFile.WriteLineAsync($"{DateTime.Now} - {emailAuthorize}, deauthenticated.");
                                                }
                                                isPlaying = false;
                                                break;

                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Invalid input, please try again.");
                                            }



                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Invalid input, please try again.");
                                        }


                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Invalid input, please try again.");
                                    }

                                }
                            }
                            break;
                        }
                    }
                }
        }
        #endregion





        #region removeusers
        static async void RemoveRegisteredUsers()
        {
            bool emailAuthenticated = false;
            bool passwordAuthenticated = false;
            Console.Clear();
            Console.WriteLine("You must require admin permissions to remove users. Please authorize.");
            string emailAuthorize;
            string passwordAuthorize;

            while (true)
            {
                Console.WriteLine();
                Console.Write("Email: ");
                emailAuthorize = Console.ReadLine();
                System.Threading.Thread.Sleep(sts2);

                for (int i = 0; i < KlantList.Count; i++)
                {
                    if (emailAuthorize == KlantList[i].Email)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine($"Welcome {emailAuthorize}.");

                        emailAuthenticated = true;
                    }
                }



                if (emailAuthenticated)
                {
                    break;
                }

                Console.WriteLine("Invalid email. Please try again.");


            }


            while (true)
            {
                Console.WriteLine();
                Console.Write("Password: ");
                passwordAuthorize = Console.ReadLine();
                System.Threading.Thread.Sleep(sts2);
                for (int i = 0; i < KlantList.Count; i++)
                {
                    if (passwordAuthorize == KlantList[i].Password)
                    {
                        using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "RamanCooporation_Log.txt"), true))
                        {
                            await outputFile.WriteLineAsync($"{DateTime.Now} - {emailAuthorize} has authenticated to remove users.");
                        }
                        Console.WriteLine($"Welcome {passwordAuthorize}. Please input your Password.");
                        passwordAuthenticated = true;
                    }
                }



                if (passwordAuthenticated)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    break;
                }
                Console.WriteLine("Invalid password. Please try again.");
            }
            bool removed = false;

            Console.Clear();
            Console.WriteLine("Welcome in the user database.");
            Console.WriteLine($"Successfully authorized as: {emailAuthorize}");
            var url = "https://github.com/Bambaclad1/test-website/raw/main/mario%20kart%20wii%20loading%20sound%20effect%20when%20you%20go%20on%20nintendo%20WFC.mp3";
            using (var mf = new MediaFoundationReader(url))
            using (var wo = new WasapiOut())
            {
                wo.Init(mf);
                wo.Play();
                while (wo.PlaybackState == PlaybackState.Playing)
                {
                    System.Threading.Thread.Sleep(sts2);
                    Console.Write(".");
                    System.Threading.Thread.Sleep(sts2);
                    Console.Write(".");
                    System.Threading.Thread.Sleep(sts2);
                    Console.Write(".");
                    System.Threading.Thread.Sleep(sts2);
                }
            }
            Console.Clear();
            Console.WriteLine("Which user to remove? (Specify their Name to remove them.)");
            while (true)
            {
                removed = false;
                bool invalid = true;
                foreach (var klant in KlantenList)
                {
                    Console.WriteLine($"Name: {klant.name}, Age: {klant.age}, Email: {klant.Email}");
                }

                Console.WriteLine("Remove who?");
                string remove = Console.ReadLine();

                for (int i = 0; i < KlantenList.Count; i++)
                {
                    if (remove == KlantenList[i].name)
                    {
                        Console.Clear();
                        Console.WriteLine($"{remove} will be removed.");
                        var url2 = "https://github.com/Bambaclad1/test-website/raw/main/1190422069888946357.mp3";
                        using (var mf = new MediaFoundationReader(url2))
                        using (var wo = new WasapiOut())
                        {
                            wo.Init(mf);
                            wo.Play();
                            while (wo.PlaybackState == PlaybackState.Playing)
                            {
                            }
                        }

                        using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "RamanCooporation_Log.txt"), true))
                        {
                            await outputFile.WriteLineAsync($"{DateTime.Now} - {emailAuthorize} has removed user {remove}.");
                        }

                        KlantenList.Remove(KlantenList[i]);

                        invalid = true;
                        string action = "null";
                        char aChar = '?';

                        Console.WriteLine("Would you like to remove another user?");
                        Console.WriteLine("Y/N");
                        action = Console.ReadLine();
                        char.TryParse(action, out aChar);

                        if (aChar == 'y' || aChar == 'Y')
                        {
                            System.Threading.Thread.Sleep(sts2);

                            Console.Clear();
                            invalid = false;
                            Console.WriteLine("");
                        }
                        else if (aChar == 'n' || aChar == 'N')
                        {
                            removed = true;
                            break;

                        }
                    }
                }

                if (removed)
                {
                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "RamanCooporation_Log.txt"), true))
                    {
                        await outputFile.WriteLineAsync($"{DateTime.Now} - {emailAuthorize}, deauthenticated.");
                    }
                    break;
                }
                else if (invalid == true)
                {
                    Console.Clear();
                    Console.WriteLine("Incorrect username. Try again.");
                }
            }



        }
    }


}
#endregion



    

