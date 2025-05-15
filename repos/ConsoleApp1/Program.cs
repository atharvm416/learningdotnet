using System;
using ConsolerefDI;

var Extensionfile = new Extensionfile();

Console.WriteLine(Extensionfile);

var config = Extensionfile.GetMainBaseConfig();

string jwtKey = config["Jwt:Key"];
string issuer = config["Jwt:Issuer"];
string audience = config["Jwt:Audience"];

Console.WriteLine("Jwt:Key     = " + jwtKey);
Console.WriteLine("Jwt:Issuer  = " + issuer);
Console.WriteLine("Jwt:Audience= " + audience);