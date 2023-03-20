using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Text.RegularExpressions;

namespace ConsoleApp2
{
    internal class Program
    {
        
        private static string[] proxyList;


        static async Task Main(string[] args)
        {
            drawLogo();
            string selectedFile = "";
            int count = 0;
            Console.Title = $"nglSpammer made with <3 by ChatGPT (and coazy) |  questions sent {count}";
            string[] proxyList = null; // Declare the variable outside the thread block
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(" w");
            Thread.Sleep(60);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("e");
            Thread.Sleep(60);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("l");
            Thread.Sleep(60);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("c");
            Thread.Sleep(60);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("o");
            Thread.Sleep(60);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("m");
            Thread.Sleep(60);
            Console.Write("e, ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(Environment.UserName);
            Thread.Sleep(60);
            Console.Write(" :");
            Thread.Sleep(60);
            Console.Write(")");
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(" ");
            Console.Write(" p");
            Thread.Sleep(40);
            Console.Write("l");
            Thread.Sleep(40);
            Console.Write("e");
            Thread.Sleep(40);
            Console.Write("a");
            Thread.Sleep(40);
            Console.Write("s");
            Thread.Sleep(40);
            Console.Write("e");
            Thread.Sleep(40);
            Console.Write(" ");
            Thread.Sleep(40);
            Console.Write("s");
            Thread.Sleep(40);
            Console.Write("e");
            Thread.Sleep(40);
            Console.Write("l");
            Thread.Sleep(40);
            Console.Write("e");
            Thread.Sleep(40);
            Console.Write("c");
            Thread.Sleep(10);
            Console.Write("t");
            Thread.Sleep(40);
            Console.Write(" ");
            Thread.Sleep(40);
            Console.Write("y");
            Thread.Sleep(40);
            Console.Write("o");
            Thread.Sleep(40);
            Console.Write("u");
            Thread.Sleep(40);
            Console.Write("r");
            Thread.Sleep(40);
            Console.Write(" ");
            Thread.Sleep(40);
            Console.Write("p");
            Thread.Sleep(40);
            Console.Write("r");
            Thread.Sleep(40);
            Console.Write("o");
            Thread.Sleep(40);
            Console.Write("x");
            Thread.Sleep(40);
            Console.Write("i");
            Thread.Sleep(40);
            Console.Write("e");
            Thread.Sleep(40);
            Console.Write("s..");
            Thread.Sleep(40);
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.White;
            var thread = new Thread(() =>
            {
                var openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Text files (*.txt)|*.txt";
                openFileDialog.Title = "select proxies";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFile = openFileDialog.FileName;
                    proxyList = File.ReadAllLines(openFileDialog.FileName);
                    Console.WriteLine(" ");
                    Console.WriteLine($" loaded {proxyList.Length} proxies.");
                }
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            if (proxyList != null && proxyList.Length > 0)
            {
                Console.WriteLine($" cleaning {proxyList.Length} proxies...");
                CleanProxyList(selectedFile);
            }
            else
            {
                Console.WriteLine(" no proxies loaded. exiting program.");
            }
            Thread.Sleep(1000);


            // Wait for the thread to finish
            while (thread.IsAlive)
            {
                Thread.Sleep(40);
            }






            var clientHandler = new HttpClientHandler()
            {
                Proxy = new WebProxy(proxyList[0], false),
                UseProxy = true
            };

            // Generates a random deviceId

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[25];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var randomString = new String(stringChars);
            string deviceID = randomString;
            Console.ForegroundColor = ConsoleColor.Green;
            Thread.Sleep(1000);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            drawLogo();
            // Strings for the spamming
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(" ngl username:");
            Console.ForegroundColor = ConsoleColor.White;
            string username = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(" question:");
            Console.ForegroundColor = ConsoleColor.White;
            string question = Console.ReadLine();

            //the loop for spam
            bool continueLooping = true;
            while (continueLooping)
            {

                foreach (var proxy in proxyList)
                {
                    var httpClientHandler = new HttpClientHandler()
                    {
                        Proxy = new WebProxy(proxy, false),
                        UseProxy = true
                    };
                    var parameters = new Dictionary<string, string>
                    {
                        { "username", username },
                        { "question", question },
                        { "deviceId", "github.com/coazyy" + deviceID },
                        { "gameSlug", "" },
                        { "referrer", "" }
                    };
                    
                    var httpClient = new HttpClient(httpClientHandler);
                    var content = new FormUrlEncodedContent(parameters);
                    try
                    {
                        var response = await httpClient.PostAsync("https://ngl.link/api/submit", content);
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            // The request was successful, do something with the response
                            var responseContent = await response.Content.ReadAsStringAsync();
                            dynamic responseObject = JsonConvert.DeserializeObject(responseContent);
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine(" [+] sent!");
                            count++;
                            Console.Title = $"nglSpammer made with <3 by coazy |  questions sent {count}";

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" [-] failed! Error Code: " + response.StatusCode + " | Trying again...");
                            Thread.Sleep(500);
                        }
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" [-] Failed! Error: Proxy Error");

                    }


                }
            }
        }
        static void CleanProxyList(string filePath)
        {
            try
            {
                var lines = File.ReadAllLines(filePath);
                var workingProxies = lines.AsParallel()
                    .Where(proxy => TestProxy(proxy))
                    .ToList();

                Console.WriteLine($" removed {lines.Length - workingProxies.Count} non working proxies. {workingProxies.Count} working proxies remaining.");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" done!");

                // Write the working proxies back to the file
                File.WriteAllLines(filePath, workingProxies);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($" error cleaning proxies: {ex.Message}");
            }
        }

        static bool TestProxy(string proxy)
        {
            try
            {
                var request = WebRequest.Create("https://www.google.com");
                request.Proxy = new WebProxy(proxy);
                request.Timeout = 10000;
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        Console.WriteLine($" proxy {proxy} works!");
                        return true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($" proxy {proxy} returned status code {response.StatusCode}");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($" proxy {proxy} failed. Exception message: {ex.Message}");
                return false;
            }
        }

        public static void drawLogo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" " +
                "    _   __________       ____  ____  ______\r\n" +
                "    / | / / ____/ /      / __ )/ __ \\/_  __/\r\n" +
                "   /  |/ / / __/ /      / __  / / / / / /   \r\n" +
                "  / /|  / /_/ / /___   / /_/ / /_/ / / /    \r\n" +
                " /_/ |_/\\____/_____/  /_____/\\____/ /_/     \r\n" +
                "                                            \r\n" +
                " made by coazy#1337\r\n" +
                " github.com/coazyy\r\n" +
                " "); 
                
        }
    }
}

