using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SendEmailExample
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void BtnSend_Clicked(object sender, System.EventArgs e)
        {
            List<string> toAddress = new List<string>
            {
                txtTo.Text
            };
            await SendEmail(txtSubject.Text, txtBody.Text, toAddress);
        }

        public async Task SendEmail(string subject, string body, List<string> recipients)
        {
            try
            {
                var message = new EmailMessage
                {
                    Subject = subject,
                    Body = body,
                    To = recipients,
                };
                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException fbsEx)
            {
                _ = fbsEx;
                // Email is not supported on this device  
            }
            catch (Exception ex)
            {
                _ = ex;
                // Some other exception occurred  
            }
        }
    }
}
