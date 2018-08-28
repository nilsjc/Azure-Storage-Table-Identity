using AzureStorageTableIdentity.Interfaces;
using AzureStorageTableIdentity.Models;
using AzureStorageTableIdentity.Statics;
using System;
using System.Collections.ObjectModel;

namespace AzureStorageTableIdentity
{
    public class Client
    {
        private readonly IUserFactory _userFactory;
        private readonly IListUsers _listUsers;

        public Client(IUserFactory userFactory, IListUsers listUsers)
        {
            _userFactory = userFactory;
            _listUsers = listUsers;
        }

        public void Start()
        {

            SetColor.Ink(Colors.Cyan);
            Console.WriteLine("Welcome,");
            bool running = true;
            while (running)
            {
                Console.WriteLine();

                SetColor.Ink(Colors.Yellow);

                Console.WriteLine("What do you want me to do?");
                Console.WriteLine("--------------------------");

                SetColor.Ink(Colors.Green);

                Console.WriteLine("1:Register a new user");
                Console.WriteLine("2:Delete a user");
                Console.WriteLine("3:List all users");
                Console.WriteLine("4:Exit program");

                SetColor.Ink(Colors.White);

                var select = int.Parse(Console.ReadLine());

                switch (select)
                {
                    case 1:
                        SetColor.Ink(Colors.Cyan);
                        Console.WriteLine("Create a new user. Write '.' for escape");
                        string[] values = new string[3];
                        var i = 0;
                        foreach (var text in new Collection<string> { "Name:", "Id:", "Password:" })
                        {
                            SetColor.Ink(Colors.Yellow);
                            Console.WriteLine(text);
                            SetColor.Ink(i == 2 ? Colors.Black : Colors.White);
                            var value = Console.ReadLine();
                            if (value == ".") break;
                            values[i] = value;
                            i++;
                        }
                        if (i > 2)
                        {
                            var model = new RegisterModel()
                            {
                                UserName = values[0],
                                Id = values[1],
                                Password = values[2]
                            };
                            var result = _userFactory.RegisterAsync(model);
                            SetColor.Ink(Colors.Cyan);
                            Console.WriteLine(result.Result);
                        }
                        break;
                    case 2:
                        break;
                    case 3:
                        SetColor.Ink(Colors.Yellow);
                        Console.WriteLine("Id? ...for example '1', '1-10', ' '(all users)");
                        SetColor.Ink(Colors.White);
                        var id = Console.ReadLine();
                        var results = _listUsers.ListAllById(id);

                        Console.WriteLine();
                        SetColor.Ink(Colors.Yellow);
                        if (results.Count < 1)
                        {
                            Console.WriteLine("No user exists");
                            break;
                        }

                        Console.WriteLine($"This is all users with id:{id}");
                        Console.WriteLine();
                        SetColor.Ink(Colors.Cyan);
                        foreach (var siteUser in results)
                        {
                            Console.WriteLine($"{siteUser.Name}: {siteUser.PasswordHash}");
                        }
                        break;
                    case 4:
                        running = false;
                        break;
                    default:
                        SetColor.Ink(Colors.Yellow);
                        Console.WriteLine("Can you say it again, please?");
                        break;
                }
            }
        }
    }
}