using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace plannerProject
{
    internal class Program
    {
        static int ShowMenu()
        {
            int menuSelectedOption = 0;

            Console.Clear();
            Console.WriteLine("1.Exibir contato");
            Console.WriteLine("2.Inserir contato");
            Console.WriteLine("3.Alterar contato");
            Console.WriteLine("4.Excluir contato");
            Console.WriteLine("5.Localizar contato");
            Console.WriteLine("6.Sair");
            Console.Write("Digite o número correspondente à opção desejada: ");
            menuSelectedOption = Convert.ToInt32(Console.ReadLine());

            return menuSelectedOption;
        }

        static void ShowContacts(string[] names, string[] emails, int totalRecordsCount)
        {
            try 
            {
                Console.Clear();
                for (int contactLocal = 0; contactLocal < totalRecordsCount; contactLocal++)
                {
                    Console.WriteLine("{0}.Nome: {1} | E-mail: {2}", (contactLocal+1), names[contactLocal], emails[contactLocal]);
                    
                }
            } catch(Exception error)
            {
                Console.WriteLine("ERROR: não há contatos salvos" + error);
                Console.Write("Pressione qualquer tecla para sair: ");
                Console.ReadKey();
            }
            Console.Write("Pressione qualquer tecla para sair: ");
            Console.ReadKey();

        }

        static void CreateContact(ref string[] names, ref string[] emails, ref int totalRecordsCount)
        {
            try
            {
                int createContactVerification = 0;
                
               
                Console.Clear();
                Console.WriteLine("Vamos inserir um novo contato");
                Console.Write("Nome: ");
                names[totalRecordsCount] = Console.ReadLine();
                Console.Write("E-mail: ");
                emails[totalRecordsCount] = Console.ReadLine();
                createContactVerification = SearchContacts(emails, totalRecordsCount, emails[totalRecordsCount]);

                if (createContactVerification == -1)
                {
                    totalRecordsCount++;
                    Console.WriteLine("Contato adicionado com sucesso");
                } else
                {
                    Console.WriteLine("Esse contato já existe, ou o e-mail já está cadastrado em outro contato");
                }
                    Console.Write("Pressione qualquer tecla para sair: ");
                Console.ReadKey();
            }
            catch (Exception error)
            {
                Console.WriteLine("ERROR: " + error.Message);
                Console.Write("Pressione qualquer tecla para sair: ");
                Console.ReadKey();
            }

        }

        static int SearchContacts(string[] emails, int totalRegistersCount, string email)
        {
            int positionContact = -1;
            int searchContactPosition = 0;

            Console.Clear();

            while (searchContactPosition < totalRegistersCount && emails[searchContactPosition] != email)
            {

                searchContactPosition++;

            }

            if(searchContactPosition < totalRegistersCount)
            {
                positionContact = searchContactPosition;
            } 
                return positionContact;
        }

        static void UpdateContacts(string[] emails, string[]names,int totalRegistersCount, string oldEmail)
        {
            int optionMenu = 0;
            int searchContactPosition = 0;

            string newName = "";
            string newEmail = ""; 
            
            searchContactPosition = SearchContacts(emails, totalRegistersCount, oldEmail);

            if(searchContactPosition != -1)
            {
                Console.WriteLine("Contato encontrado");
                Console.WriteLine($"Email: {emails[searchContactPosition]} | Nome: {names[searchContactPosition]}");

                Console.WriteLine("Selecione uma opção:");
                Console.WriteLine("1.Editar o nome");
                Console.WriteLine("2.Editar o e-mail");
                Console.WriteLine("3.Editar o nome e o e-mail");
                Console.Write("Digite o número correspondente à opção de sua escolha: ");
                optionMenu = Convert.ToInt32(Console.ReadLine());

                switch (optionMenu)
                {
                    case 1:
                        Console.Write("Insira o novo nome para o contato: ");
                        newName = Console.ReadLine();
                        names[searchContactPosition] = newName;
                        Console.WriteLine("Contato alterado com sucesso");
                        Console.WriteLine($"Email: {emails[searchContactPosition]} Nome: {names[searchContactPosition]}");
                        break;
                    case 2:
                        Console.Write("Insira o novo e-mail do contato: ");
                        newEmail = Console.ReadLine();
                        emails[searchContactPosition] = newEmail;
                        Console.WriteLine("Contato alterado com sucesso");
                        Console.WriteLine($"Email: {emails[searchContactPosition]} | Name: {names[searchContactPosition]}");

                        break;
                    case 3:
                        Console.Write("Insira o novo nome para o contato: ");
                        newName = Console.ReadLine();
                        names[searchContactPosition] = newName;
                        Console.Write("Insira o novo e-mail do contato: ");
                        newEmail = Console.ReadLine();
                        emails[searchContactPosition] = newEmail;
                        Console.WriteLine("Contato alterado com sucesso");
                        Console.WriteLine($"Email: {emails[searchContactPosition]} Nome: {names[searchContactPosition]}");
                        break;
                }

            } else
            {
                Console.WriteLine($"Contato não encontrado, verifique se o e-mail passado está correto: {oldEmail}");
            }
        }

        static bool DeleteContact(string[] emails, string[] names, int totalRecordsCount, string emailToDelete)
        {
            bool sucessOnDelete = false;
            int contactPosition = 0;

            try
            {
                Console.WriteLine("Procurando contato...");

                contactPosition = SearchContacts(emails, totalRecordsCount, emailToDelete);

                if (contactPosition != -1)
                {
                    for (int i = contactPosition; i <= totalRecordsCount; i++)
                    {
                        emails[contactPosition] = emails[contactPosition + 1];
                        names[contactPosition] = names[contactPosition + 1];
                    }

                    if (SearchContacts(emails, totalRecordsCount, emailToDelete) == -1)
                    {
                       
                        sucessOnDelete = true;
                        return sucessOnDelete;
                    }
                }
               
            } catch(Exception e)
            {
                Console.WriteLine(e);
      
            }

            return sucessOnDelete;

            
        }


        static void Main(string[] args)
        {
            string[] names = new String[200];
            string[] emails = new String[200];
            string searchEmail = "";
            string oldEmail = "";
            string emailToDelete = "";
            

            int menuSelectedOption = 0;
            int totalRecordsCount = 0;
            int positionContact = 0;

            bool contactWasDeleted = false;

            while (menuSelectedOption != 6)
            {
                menuSelectedOption = ShowMenu();

                switch (menuSelectedOption)
                {
                    case 1:
                        ShowContacts(names, emails, totalRecordsCount);
                        break;
                    case 2:
                        CreateContact(ref names, ref emails, ref totalRecordsCount);
                        break;
                    case 3:
                        Console.WriteLine("Vamos atualizar alguns contatos");
                        ShowContacts(names, emails, totalRecordsCount);
                        Console.Write("Insira o e-mail do contato que você deseja atualizar:");
                        oldEmail = Console.ReadLine();
                        UpdateContacts(emails, names, totalRecordsCount,oldEmail);
                        Console.Write("Pressione qualquer tecla para sair ");
                        Console.ReadKey();
                            break;
                    case 4:
                        Console.WriteLine("Vamos deletar um contato");

                        ShowContacts(names, emails, totalRecordsCount);

                        Console.Write("Insira o e-mail do contato que você deseja deletar: ");
                        emailToDelete = Console.ReadLine();
                        contactWasDeleted = DeleteContact(emails, names, totalRecordsCount, emailToDelete);


                        if (contactWasDeleted)
                        {
                            Console.WriteLine("Contato deletado com sucesso");
                            ShowContacts(names, emails, totalRecordsCount);
                            totalRecordsCount--;
                        } else
                        {
                            Console.WriteLine("Não foi possível localizar o contato selecionado");
                        }
                        Console.Write("Pressione qualquer tecla para sair: ");
                        Console.ReadKey();

                            break;
                    case 5:
                        Console.Write("Insira o e-mail do contato que você quer procurar: ");
                        searchEmail = Console.ReadLine();
                        positionContact = SearchContacts(emails, totalRecordsCount, searchEmail);
                        if (positionContact != -1)
                        {
                            Console.WriteLine("Nome: {0} | E-mail: {1}", names[positionContact], emails[positionContact]);
                            
                        }
                        else
                        {
                            Console.WriteLine("Contato não encontrado");
                        }


                        Console.Write("Pressione qualquer tecla para sair: ");
                        Console.ReadKey();

                        break;
                }

            }

            Backup.SetData(ref emails, ref names, ref totalRecordsCount);

        }
   
    }
}
