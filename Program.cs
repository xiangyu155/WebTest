﻿
using System.Text;
// Generated by Selenium IDE
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
//write txt
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            TESTTest tEST1 = new TESTTest();
            tEST1.SetUp();
            tEST1.tEST();
            tEST1.TearDown();
        }
    }


    public class TESTTest
    {
        private IWebDriver driver;
        public IDictionary<string, object> vars { get; private set; }
        private IJavaScriptExecutor js;
        public void SetUp()
        {
            driver = new ChromeDriver();
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
        }
        public void TearDown()
        {
            driver.Quit();
        }
        public string waitForWindow(int timeout)
        {
            try
            {
                Thread.Sleep(timeout);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            var whNow = ((IReadOnlyCollection<object>)driver.WindowHandles).ToList();
            var whThen = ((IReadOnlyCollection<object>)vars["WindowHandles"]).ToList();
            if (whNow.Count > whThen.Count)
            {
                return whNow.Except(whThen).First().ToString();
            }
            else
            {
                return whNow.First().ToString();
            }
        }
        public void tEST()
        {
            // Test name: TEST
            // Step # | name | target | value
            // 1 | open | / | 
            driver.Navigate().GoToUrl("https://www.baidu.com/");
            // 2 | setWindowSize | 1266x1060 | 
            driver.Manage().Window.Size = new System.Drawing.Size(1266, 1060);
            // 3 | click | id=virus-2020 | 
            vars["WindowHandles"] = driver.WindowHandles;
            // 4 | selectWindow | handle=${win5935} | 
            driver.FindElement(By.Id("virus-2020")).Click();
            // 5 | click | css=.VirusSummarySix_1-1-258_123ZxM > .VirusSummarySix_1-1-258_3haLBF | 
            vars["win5935"] = waitForWindow(2000);
            // 6 | click | css=.VirusSummarySix_1-1-258_123ZxM > .VirusSummarySix_1-1-258_3haLBF | 
            driver.SwitchTo().Window(vars["win5935"].ToString());
            // 7 | doubleClick | css=.VirusSummarySix_1-1-258_123ZxM > .VirusSummarySix_1-1-258_3haLBF | 
            String tmpStr;
            tmpStr=driver.FindElement(By.CssSelector(".VirusSummarySix_1-1-258_123ZxM > .VirusSummarySix_1-1-258_3haLBF")).Text;
            //write  写入index.html
            using (StreamWriter sw = new StreamWriter("index.html", false, Encoding.Unicode))
            {
                //写入分析日期时间
                String tmpDateTime = " 巡检执行完成时间:";
                tmpDateTime += DateTime.Now.Year.ToString();
                tmpDateTime += "-" + DateTime.Now.Month.ToString();
                tmpDateTime += "-";
                tmpDateTime += DateTime.Now.Day.ToString() + " ";
                tmpDateTime += DateTime.Now.Hour.ToString();
                tmpDateTime += ":";
                tmpDateTime += DateTime.Now.Minute.ToString();
                tmpDateTime += ":" + DateTime.Now.Second.ToString();
                sw.WriteLine(tmpStr + tmpDateTime);
            }
        }
    }

}
