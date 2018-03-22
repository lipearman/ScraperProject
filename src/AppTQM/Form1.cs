using mshtml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppTQM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            webBrowser1.Navigate(AppDomain.CurrentDomain.BaseDirectory + @"GetSearch.html");


            HtmlElementCollection elc = webBrowser1.Document.GetElementsByTagName("input");

            //HtmlElement head = webBrowser1.Document.GetElementsByTagName("head")[0];
            //HtmlElement scriptEl = webBrowser1.Document.CreateElement("script");
            //IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;
            //element.text = "function submitForm() { document.getElementById('searchCar').submit(); }";
            //head.AppendChild(scriptEl);
            //webBrowser1.Document.InvokeScript("submitForm");


            //HtmlElement link = currentwb.Document.GetElementByID("id_of_element");
            //link.InvokeMember("Click");


        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
