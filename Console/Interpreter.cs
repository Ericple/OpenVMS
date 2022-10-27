/**
 * Created at 2022/10/24 by Guo Ting jin
 */

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenVMS.Models.Enums;
using OpenVMS.Security;

namespace OpenVMS.Console;

public class Interpreter
{
    public static ApiKeyAuthenticationService Service = new(); 
    public Interpreter()
    {
    }

    public void Welcome(string version)
    {
        System.Console.WriteLine(" _______  _______  _______  __    _  __   __  __   __  _______ ");
        System.Console.WriteLine("|       ||       ||       ||  |  | ||  | |  ||  |_|  ||       |");
        System.Console.WriteLine("|   _   ||    _  ||    ___||   |_| ||  |_|  ||       ||  _____|");
        System.Console.WriteLine("|  | |  ||   |_| ||   |___ |       ||       ||       || |_____ ");
        System.Console.WriteLine("|  |_|  ||    ___||    ___||  _    ||       ||       ||_____  |");
        System.Console.WriteLine("|       ||   |    |   |___ | | |   | |     | | ||_|| | _____| |");
        System.Console.WriteLine("|_______||___|    |_______||_|  |__|  |___|  |_|   |_||_______|\n");
        System.Console.WriteLine("Author:Guo Tingjin\tMail:dev@peercat.cn\tGithub:https://github.com/Ericple\tVersion:{0}",version);
        System.Console.WriteLine("Welcome to OpenVMS Console, application is not started yet, type \"service start\" to launch the service");
    }

    public void Get(string[] appStartArgs)
    {
        System.Console.Write("\nOpenVMS ~> ");
        var command = System.Console.ReadLine();
        Decode(command, appStartArgs);
    }

    private static void Decode(string? command, string[] appStartArgs)
    {
        if (command != null)
        {
            var mainArg = command.Split(" ")[0];
            var args = command.Split(" ")[new Range(1,command.Split(" ").Length)];
            Compile(mainArg, args, appStartArgs);
        }
    }

    private static void Compile(string mainArg, string[] args, string[] appStartArgs)
    {
        switch (mainArg.ToLower())
        {
            case "service":
            {
                if (args.Contains("start"))
                {
                    RunApp(appStartArgs);
                }
                break;
            }
            case "exit":
            case "quit":
                System.Environment.Exit(0);
                break;
            case "apikey":
            {
                if (args.Contains("add") && args.Length > 2)
                {
                    try
                    {
                        Service.Create(args[1], int.Parse(args[2]));
                        PrintResult("key added");
                    }
                    catch (Exception e)
                    {
                        PrintError("\nBroken argument(s), add -help to get help list.",HelpList.ApiKeyAdd());
                    }
                }
                else if (args.Contains("del") && args.Length > 1)
                {
                    try
                    {
                        Service.Delete(args[0]);
                    }
                    catch (Exception e)
                    {
                        PrintError("\nBroken argument(s), add -help to get help list.", HelpList.ApiKeyDel());
                    }
                }
                else if (args.Contains("gen") && args.Length > 1)
                {
                    try
                    {
                        var value = Service.Generate(int.Parse(args[1]));
                        if (value == "false")
                        {
                            PrintError("Fail: an unknown error occured",null);
                        }
                        PrintResult("Apikey generated with value - " + value);
                    }
                    catch (Exception e)
                    {
                        PrintError("\n"+e.ToString()+"\n add -help to get help list.",HelpList.ApiKeyGen());
                    }
                }
                else if (args.Contains("l"))
                {
                    Service.Get();
                }
                break;
            }
            case "api":
            {
                if (args.Contains("l")) 
                {
                    
                }
                break;
            }
        }
    }

    private static void RunApp(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddControllersWithViews();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseRouting();

        app.UseAuthorization();

        app.MapControllers();
        app.Run();
    }
    private static void Help(string funcName)
    {
        
    }

    private static void PrintError(string error,string? usage)
    {
        System.Console.ForegroundColor = ConsoleColor.Red;
        System.Console.Write("\nError: \n");
        System.Console.ResetColor();
        System.Console.WriteLine(error);
        if (usage != null)
        {
            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.Write("\nUsage: \n");
            System.Console.ResetColor();
            System.Console.WriteLine(usage);
        }
    }

    private static void PrintResult(string result)
    {
        System.Console.ForegroundColor = ConsoleColor.Green;
        System.Console.Write("\nSuccess: \n");
        System.Console.ResetColor();
        System.Console.WriteLine(result);
    }
}