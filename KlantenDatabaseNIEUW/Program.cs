using NAudio.Wave;


/* Commenter notes
 * Hi hi! this code was written by bamba. now, this code seems like ALOT to take in but do not worry, its actually quite simple if you understand it
 * with a small code cleanup.
 * Here is some MUST KNOWS
 * 
 * boolean isPlaying is for the Internet 3DS Remix music to play during the add user interface. wouldn't change values otherwise no playing music :(
 * 
 * static int sts, basically, i use the command System.Threading.Thread.Sleep(); to generate a fake delay, for example
 * while logging in, it delays it so it is realistic like its actually checking and for some *STYLE!*
 * If you'd like to proceed debugging faster, just give those numbers a 5! put them on default if showing it off to others.
 * 
 * thats all you need to know for now fam
 * 
 * This code has been written and given a MIT license. 
 * 
 * i won't comment anything, but only the confusing part, the rest is up to you.
 * 
 * side notes: the authentication process could be a seperate method
 */

namespace KlantenDatabaseNIEUW
{
    internal class Program
    {
        static bool isPlaying = false;

        static List<Klant> KlantList = new List<Klant>();
        static List<Klant> KlantenList = new List<Klant>();

        static int sts = 1000; // long delay generator integer?default: 1000
        static int sts2 = 500; // short delay generator integer? default: 500.

        // make a document appear on your desktop where i funnily enough log what you are doing on my database =))
        static string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); 

        static async Task Main() // pluh!
        {
            // writing text to the document, at the moment you run this program it will log it.
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "RamanCooporation_Log.txt"))) // ignore typo, and i do NOT recommend changing this or you break the whole document thing, only if you know what you're doing your gonna have to make the changes everywhere in the code and that means changing the text to the new text in every part, but vs has a cool function for this and that is if you press CTRL+F you can mass rename a old name to a new name. Convenient.
            {
                await outputFile.WriteLineAsync("# Action Logger made by /bambito =))"); // bamba was here
                await outputFile.WriteLineAsync($"# Started logging at: {DateTime.Now}");
                await outputFile.WriteLineAsync("");

            }
            
            // okay, this is gonna sound complicated, but listen good.
            // This will be the basic list everytime you "run" the program. those users will be PERMANENT.
            // the parameters go like, ("String(name))", (int(age)), (string(email)), *(bool(authorized)), (string(password)), (int(ID)).
            // for more depth informationm, head to the file Klant.cs.
            // bare in mind, that the bool: authorized (true or false), does NOT do anything. it is broken, but it does nothing. Removing it makes things complicated for you and me.
            // for me to keep the code running again so we keep it there. visual studio will cry about it, go ahead and try.
            // also the lack of time like jeez i only have a week left and so much shit left to do, i mean it works it works so yuh uh
            Klant Raman = new Klant("Ramandeep Singh", 16, "bamba@ramanmail.com", true ,"ramannoodles", 001);
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
          


            // This list is dedicated to users with Admin access. if you add a user above, also add a user below as klantlist.
            // if you add them into klantlist, you can login with them. if you add them into klantenlist, you can view them in a list
            // for a regular user, just a klantenlist.add would be fine.
            // feel free to try to add users, but make sure to add them to the list too, otherwise you will get a buncho errors
            KlantList.Add(Raman);
            KlantList.Add(sudo);
            KlantenList.Add(Raman);
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


            while (true) // This loop is to ensure the user cannot break out the menu. a requirement for the project itself.
            {
                Console.BackgroundColor = ConsoleColor.Black; // usually the color goes blue after going to the menu, i think this is a visual studio bug
                Console.BackgroundColor = ConsoleColor.Black; // tbf, so just keep it there.

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
                int.TryParse(keuze, out choice); //parse string to int blah blah

                switch (choice) // pretty self-explainatory.
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
                        Environment.Exit(0);
                        break;
                }
                Console.Clear();
            }
        }

        static async void ViewRegisteredUsers()
        {
            Console.Clear();
            Console.WriteLine("View users.");
            
            // its snitching you when you viewed the users.
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "RamanCooporation_Log.txt"), true))
            {
                await outputFile.WriteLineAsync($"{DateTime.Now} - Users have been viewed.");
            }

            //printing the users out. now you can extend this, if you'd actually like to, but you also need to add that to the addusers method.
            foreach (var klant in KlantenList)
            {
                Console.WriteLine($"Name: {klant.name}, Age: {klant.age}, Email: {klant.Email}");
            }

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
        static async void EditRegisteredUsers()
        {
            bool emailAuthenticated = false; // dont you dare change this value
            bool passwordAuthenticated = false; // or ill kidnap your parents (you break the code this way)
            string emailAuthorize;
            string passwordAuthorize;

            Console.Clear();
            Console.WriteLine("You have pressed to Edit the registered users.");
            Console.WriteLine("You must require admin permissions to edit a user. Please authorize.");

            while (true) // loop to ensure your not breaking out the login process
            {
                Console.WriteLine();
                Console.Write("Email: ");
                emailAuthorize = Console.ReadLine();
                System.Threading.Thread.Sleep(sts2); // delay

                for (int i = 0; i < KlantList.Count; i++) // im telling the computer to look up every user in the admin list to see if the email matches
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

                    break; // if it does, you break out of the loop like a successfull prisoner
                }

                Console.WriteLine("Invalid email. Please try again."); // if it doesn't, it tells you to try again. smooth right?
            }

            while (true) // this is the same process, but only for password
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
                    // bro is snitching you edited users :moyai: basically writes text, i think this is obvious already now
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
            // you can change the sound it is playing HOWEEEVEEER how longer the sound is the more you make it "load"
            var url = "https://github.com/Bambaclad1/test-website/raw/main/mario%20kart%20wii%20loading%20sound%20effect%20when%20you%20go%20on%20nintendo%20WFC.mp3";
            using (var mf = new MediaFoundationReader(url))
            using (var wo = new WasapiOut())
            {
                wo.Init(mf);
                wo.Play();
                while (wo.PlaybackState == PlaybackState.Playing) // delay while playing sound effect.
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
            bool check1 = false; // check om te zien of input invalid is of niet
            int newAge;


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

                for (int i = 0; i < KlantenList.Count; i++)
                {
                    if (edit == KlantenList[i].name) // if console.readline corrosponds with klantenlist thing proceed if not retry
                    {
                        Console.Clear();
                        Console.WriteLine($"Editing user: {KlantenList[i].name}, please input the user's new name.");
                        string newName = Console.ReadLine();

                        if (!string.IsNullOrEmpty(newName)) // if new name is NOT empty or null continue
                        {
                            check1 = true;
                            Console.WriteLine("Enter new age: ");
                            string newAge1 = Console.ReadLine();

                            if (int.TryParse(newAge1, out newAge) && newAge > 0 && newAge < 100) // if string fits int between 1/99
                            {
                                Console.WriteLine("Enter new email (@ramanmail will be added at the end)");
                                string newEmail = Console.ReadLine() + "@ramanmail.com";

                                if (!string.IsNullOrEmpty(newEmail))
                                {
                                    // final touches, actually making the list update
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
                                    return; 
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

        static async void AddRegisteredUsers()
        {
            //if you would like a small documentation on this, check the Edit Users method, i already explained this once
            bool emailAuthenticated = false;
            bool passwordAuthenticated = false;
            string emailAuthorize;
            string passwordAuthorize;

            Console.Clear();
            Console.WriteLine("You must require admin permissions to add users. Please authorize.");

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
            // plays a 3ds tune hosted on my github
            var url = "https://github.com/Bambaclad1/test-website/raw/main/youtube_wlfxjNeViHk_audio.mp3";
            using (var mf = new MediaFoundationReader(url))
            using (var wo = new WasapiOut())
                if (isPlaying)
                {
                    {

                        wo.Init(mf);
                        wo.Play();
                        while (wo.PlaybackState == PlaybackState.Playing) // while playing execute code
                        {
                            while (true)
                            {
                                string fullName;

                                System.Threading.Thread.Sleep(sts2);
                                Console.WriteLine("Welcome to the add a new user setup!");
                                Console.WriteLine("");
                                Console.WriteLine("Enter the new person's full name:");
                                fullName = Console.ReadLine();

                                //dummy customer to modify contents later
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

                                            char aChar = '?'; // exit or not bla bla vs reads if you want to exit the add user method or not
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

        static async void RemoveRegisteredUsers()
        {
            bool emailAuthenticated = false;
            bool passwordAuthenticated = false;
            string emailAuthorize;
            string passwordAuthorize;
            Console.Clear();
            Console.WriteLine("You must require admin permissions to remove users. Please authorize.");


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




    
