using API.Models;
using API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace API.Handler
{
    public class SendEmail
    {
        public static void ForgotPassword(string email, string passwordGuid)
        {
            string to = email;
            string from = "olmsmii03@gmail.com";
            string mailbody = string.Empty;
            MailMessage mail = new MailMessage(from, to);

            //string mailbody = "<h3>Hello " + to + "</h3> We have accepted your request to reset password. Here is your new password <b>"
            //    + passwordGuid + "</b> <br>Use that new password to login to your account.";

            mailbody += "<body>";
            mailbody += "<div style='margin: 25px;'>";
            mailbody += "<div style='background-color: #4ac09d; border-radius: 25px;'>";
            mailbody += "<p style='font-weight: bold; font-size: 25px; padding-top: 25px; color: white; text-align: center;'>Leave Management System</p>";
            mailbody += "<div style='background-color:#f0f0f0; border-bottom-right-radius:25px; border-bottom-left-radius:25px; margin-top:-30px;'>";
            mailbody += "<div style='margin-left: 50px; margin-right: 50px; padding-bottom: 50px;'>";
            mailbody += "<h4 style='padding-top: 20px; color: black;'>Hello " + email + " ,</h4>";
            mailbody += "<p style='color: black;'>We have accepted your request to reset password. Here is your new password.</p>";
            mailbody += "<h4 style='text-align: center; color: black;'>Use that new password to login to your account</h4>";
            mailbody += "<div style='background-color: white;'>";
            mailbody += "<p style='text-align: center; padding: 10px;  color: black;'> " + passwordGuid + " </p>";
            mailbody += "</div>";
            mailbody += "</div>";

            mailbody += "<div style='color: inherit; font - size:inherit; line - height:inherit'>";
            mailbody += "<table width='100%' cellpadding='0' cellspacing='0' style='border-spacing:0!important;border-collapse:collapse;text-align:center;font-family:Arial,sans-serif;font-size:12px;line-height:135%;color:#23496d;margin-bottom:0;padding:0' align='center'>";
            mailbody += "<tbody>";
            mailbody += "<tr>";
            mailbody += "<td align='center' valign='top' style='border-collapse:collapse;font-family:Lato,Tahoma,sans-serif;font-size:13px;color:#444444;word-break:break-word;text-align:center;margin-bottom:0;line-height:135%;padding:10px 20px'>";
            mailbody += "<p style='font-family:Verdana,sans-serif;font-size:11px;font-weight:normal;text-decoration:none;font-style:normal;color:#444444'> APL Tower Lantai 37, Jl. Letjen S. Parman Kav. 28, RT.12/RW.6, Tj. Duren Sel., Jakarta Barat, Kota Jakarta Barat, Daerah Khusus Ibukota Jakarta 11470 </p>";
            mailbody += "<font color='#888888'>";
            mailbody += "<p>";
            mailbody += "<a style='font-family:Verdana,sans-serif;font-size:10px;color:#00000f;font-weight:normal;font-style:normal' rel='noreferrer'>© PT. Mitra Integrasi Informatika</a>";
            mailbody += "</p>";
            mailbody += "</font>";
            mailbody += "</td>";
            mailbody += "</tr>";
            mailbody += "</tbody>";
            mailbody += "</table>";
            mailbody += "<div>";
            mailbody += "<div>";
            mailbody += "<div>";

            mailbody += "</div>";
            mailbody += "</div>";
            mailbody += "</div>";
            mailbody += "</div>";
            mailbody += "</body>";

            mail.Subject = "Forgot Password";
            mail.Body = mailbody;
            mail.BodyEncoding = Encoding.UTF8;
            mail.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp 
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("olmsmii03@gmail.com", "Olmsmii[03]");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(mail);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SendRequest(string emailManager, string NameManager, string FullName, string position, RequestVM requestVM)
        {
            string to = emailManager;
            string from = "olmsmii03@gmail.com";
            string mailbody = string.Empty;
            MailMessage mail = new MailMessage(from, to);
            mailbody += "<body>";
            mailbody += "<div style='margin: 25px;'>";
            mailbody += "<div style='background-color: #4ac09d; border-radius: 25px;'>";
            mailbody += "<p style='font-weight: bold; font-size: 25px; padding-top: 25px; color: white; text-align: center;'>Leave Management System</p>";
            mailbody += "<div style='background-color:#f0f0f0; border-bottom-right-radius:25px; border-bottom-left-radius:25px; margin-top:-30px;'>";
            mailbody += "<div style='margin-left: 35px; margin-right: 35px; padding-bottom: 50px;'>";
            mailbody += "<h4 style='padding-top: 20px; color: black;'>Hello " + NameManager + " ,</h4>";
            mailbody += "<p style='color: black;'>Employees request permission to leave. Please Approve Or Reject Employee Request. Here are the details:</p>";
            mailbody += "<p style='color: black;'>Name: "+ FullName + "</p>";
            mailbody += "<p style='color: black;'>Position: " + position + " </p>";
            mailbody += "<p style='color: black;'>Request Type: " + requestVM.ReasonRequest + " </p>";
            mailbody += "<p style='color: black;'>Date: "+requestVM.StartDate+" - "+requestVM.EndDate+"</p>";
            mailbody += "<br>";
            mailbody += "<p style='color: black;'>Best Regards,</p>";
            mailbody += "<p style='color: black;'>Management System</p>";
            mailbody += "</div>";

            mailbody += "<div style='color: inherit; font - size:inherit; line - height:inherit'>";
            mailbody += "<table width='100%' cellpadding='0' cellspacing='0' style='border-spacing:0!important;border-collapse:collapse;text-align:center;font-family:Arial,sans-serif;font-size:12px;line-height:135%;color:#23496d;margin-bottom:0;padding:0' align='center'>";
            mailbody += "<tbody>";
            mailbody += "<tr>";
            mailbody += "<td align='center' valign='top' style='border-collapse:collapse;font-family:Lato,Tahoma,sans-serif;font-size:13px;color:#444444;word-break:break-word;text-align:center;margin-bottom:0;line-height:135%;padding:10px 20px'>";
            mailbody += "<p style='font-family:Verdana,sans-serif;font-size:11px;font-weight:normal;text-decoration:none;font-style:normal;color:#444444'> APL Tower Lantai 37, Jl. Letjen S. Parman Kav. 28, RT.12/RW.6, Tj. Duren Sel., Jakarta Barat, Kota Jakarta Barat, Daerah Khusus Ibukota Jakarta 11470 </p>";
            mailbody += "<font color='#888888'>";
            mailbody += "<p>";
            mailbody += "<a style='font-family:Verdana,sans-serif;font-size:10px;color:#00000f;font-weight:normal;font-style:normal' rel='noreferrer'>© PT. Mitra Integrasi Informatika</a>";
            mailbody += "</p>";
            mailbody += "</font>";
            mailbody += "</td>";
            mailbody += "</tr>";
            mailbody += "</tbody>";
            mailbody += "</table>";
            mailbody += "<div>";
            mailbody += "<div>";
            mailbody += "<div>";

            mailbody += "</div>";
            mailbody += "</div>";
            mailbody += "</div>";
            mailbody += "</div>";
            mailbody += "</body>";

            mail.Subject = "New Leave Request";
            mail.Body = mailbody;
            mail.BodyEncoding = Encoding.UTF8;
            mail.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp 
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("olmsmii03@gmail.com", "Olmsmii[03]");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Approvemanager(string emailHR, Request request)
        {
            string to = emailHR;
            string from = "olmsmii03@gmail.com";
            string mailbody = string.Empty;
            MailMessage mail = new MailMessage(from, to);

            mailbody += "<body>";
            mailbody += "<div style='margin: 25px;'>";
            mailbody += "<div style='background-color: #4ac09d; border-radius: 25px;'>";
            mailbody += "<p style='font-weight: bold; font-size: 25px; padding-top: 25px; color: white; text-align: center;'>Leave Management System</p>";
            mailbody += "<div style='background-color:#f0f0f0; border-bottom-right-radius:25px; border-bottom-left-radius:25px; margin-top:-30px;'>";
            mailbody += "<div style='margin-left: 50px; margin-right: 50px; padding-bottom: 50px;'>";
            mailbody += "<h4 style='padding-top: 20px; color: black;'>Hello " + emailHR + ",</h4>";
            mailbody += "<p style='color: black;'>Employee leave request with the name "+request.Employee.FullName+", has been approved by the manager, please check the list of leave requests to be accepted or rejected.</p>";
            mailbody += "<div style='text-align: center;'>";
            mailbody += "<img src='https://svgsilh.com/png-512/146635-4caf50.png' style='width: 100px; height: 100px;' alt='approved'>";
            mailbody += "</div>";
            mailbody += "<br>";
            mailbody += "<p style='color: black;'>Best Regards,</p>";
            mailbody += "<p style='color: black;'>Management System</p>";
            mailbody += "</div>";

            mailbody += "<div style='color: inherit; font - size:inherit; line - height:inherit'>";
            mailbody += "<table width='100%' cellpadding='0' cellspacing='0' style='border-spacing:0!important;border-collapse:collapse;text-align:center;font-family:Arial,sans-serif;font-size:12px;line-height:135%;color:#23496d;margin-bottom:0;padding:0' align='center'>";
            mailbody += "<tbody>";
            mailbody += "<tr>";
            mailbody += "<td align='center' valign='top' style='border-collapse:collapse;font-family:Lato,Tahoma,sans-serif;font-size:13px;color:#444444;word-break:break-word;text-align:center;margin-bottom:0;line-height:135%;padding:10px 20px'>";
            mailbody += "<p style='font-family:Verdana,sans-serif;font-size:11px;font-weight:normal;text-decoration:none;font-style:normal;color:#444444'> APL Tower Lantai 37, Jl. Letjen S. Parman Kav. 28, RT.12/RW.6, Tj. Duren Sel., Jakarta Barat, Kota Jakarta Barat, Daerah Khusus Ibukota Jakarta 11470 </p>";
            mailbody += "<font color='#888888'>";
            mailbody += "<p>";
            mailbody += "<a style='font-family:Verdana,sans-serif;font-size:10px;color:#00000f;font-weight:normal;font-style:normal' rel='noreferrer'>© PT. Mitra Integrasi Informatika</a>";
            mailbody += "</p>";
            mailbody += "</font>";
            mailbody += "</td>";
            mailbody += "</tr>";
            mailbody += "</tbody>";
            mailbody += "</table>";
            mailbody += "<div>";
            mailbody += "<div>";
            mailbody += "<div>";

            mailbody += "</div>";
            mailbody += "</div>";
            mailbody += "</div>";
            mailbody += "</div>";
            mailbody += "</body>";

            mail.Subject = "Leave Request - Approved by Manager";
            mail.Body = mailbody;
            mail.BodyEncoding = Encoding.UTF8;
            mail.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp 
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("olmsmii03@gmail.com", "Olmsmii[03]");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ApproveHR(string emailEmployee, Request request)
        {
            string to = emailEmployee;
            string from = "olmsmii03@gmail.com";
            string mailbody = string.Empty;
            MailMessage mail = new MailMessage(from, to);

            mailbody += "<body>";
            mailbody += "<div style='margin: 25px;'>";
            mailbody += "<div style='background-color: #4ac09d; border-radius: 25px;'>";
            mailbody += "<p style='font-weight: bold; font-size: 25px; padding-top: 25px; color: white; text-align: center;'>Leave Management System</p>";
            mailbody += "<div style='background-color:#f0f0f0; border-bottom-right-radius:25px; border-bottom-left-radius:25px; margin-top:-30px;'>";
            mailbody += "<div style='margin-left: 50px; margin-right: 50px; padding-bottom: 50px;'>";
            mailbody += "<h4 style='padding-top: 20px; color: black;'>Hello " + request.Employee.FullName + ",</h4>";
            mailbody += "<p style='color: black;'>Congratulations!, your " + request.ReasonRequest + " - leave request that you submitted on "+ request.RequestDate + " was approved.</p>";
            mailbody += "<div style='text-align: center;'>";
            mailbody += "<img src='https://svgsilh.com/png-512/146635-4caf50.png' style='width: 100px; height: 100px;' alt='approved'>";
            mailbody += "</div>";
            mailbody += "<br>";
            mailbody += "<p style='color: black;'>Best Regards,</p>";
            mailbody += "<p style='color: black;'>Management System</p>";
            mailbody += "</div>";

            mailbody += "<div style='color: inherit; font - size:inherit; line - height:inherit'>";
            mailbody += "<table width='100%' cellpadding='0' cellspacing='0' style='border-spacing:0!important;border-collapse:collapse;text-align:center;font-family:Arial,sans-serif;font-size:12px;line-height:135%;color:#23496d;margin-bottom:0;padding:0' align='center'>";
            mailbody += "<tbody>";
            mailbody += "<tr>";
            mailbody += "<td align='center' valign='top' style='border-collapse:collapse;font-family:Lato,Tahoma,sans-serif;font-size:13px;color:#444444;word-break:break-word;text-align:center;margin-bottom:0;line-height:135%;padding:10px 20px'>";
            mailbody += "<p style='font-family:Verdana,sans-serif;font-size:11px;font-weight:normal;text-decoration:none;font-style:normal;color:#444444'> APL Tower Lantai 37, Jl. Letjen S. Parman Kav. 28, RT.12/RW.6, Tj. Duren Sel., Jakarta Barat, Kota Jakarta Barat, Daerah Khusus Ibukota Jakarta 11470 </p>";
            mailbody += "<font color='#888888'>";
            mailbody += "<p>";
            mailbody += "<a style='font-family:Verdana,sans-serif;font-size:10px;color:#00000f;font-weight:normal;font-style:normal' rel='noreferrer'>© PT. Mitra Integrasi Informatika</a>";
            mailbody += "</p>";
            mailbody += "</font>";
            mailbody += "</td>";
            mailbody += "</tr>";
            mailbody += "</tbody>";
            mailbody += "</table>";
            mailbody += "<div>";
            mailbody += "<div>";
            mailbody += "<div>";

            mailbody += "</div>";
            mailbody += "</div>";
            mailbody += "</div>";
            mailbody += "</div>";
            mailbody += "</body>";

            mail.Subject = "Leave Request - Approved";
            mail.Body = mailbody;
            mail.BodyEncoding = Encoding.UTF8;
            mail.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp 
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("olmsmii03@gmail.com", "Olmsmii[03]");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Rejected(string emailEmployee, string RejectedNotes, Request request)
        {
            string to = emailEmployee;
            string from = "olmsmii03@gmail.com";
            string mailbody = string.Empty;
            MailMessage mail = new MailMessage(from, to);

            mailbody += "<body>";
            mailbody += "<div style='margin: 25px;'>";
            mailbody += "<div style='background-color: #4ac09d; border-radius: 25px;'>";
            mailbody += "<p style='font-weight: bold; font-size: 25px; padding-top: 25px; color: white; text-align: center;'>Leave Management System</p>";
            mailbody += "<div style='background-color:#f0f0f0; border-bottom-right-radius:25px; border-bottom-left-radius:25px; margin-top:-30px;'>";
            mailbody += "<div style='margin-left: 50px; margin-right: 50px; padding-bottom: 50px;'>";
            mailbody += "<h4 style='padding-top: 20px; color: black;'>Hello "+ request.Employee.FullName +",</h4>";
            mailbody += "<p style='color: black;'>Sorry, " + request.ReasonRequest + " leave request that you submitted on " +request.RequestDate+ " was rejected.</p>";
            mailbody += "<div style='text-align: center;'>";
            mailbody += "<img src='https://cdn4.iconfinder.com/data/icons/toolbar-std-pack/512/delete-512.png' style='width: 100px; height: 100px;' alt='rejected'>";
            mailbody += "</div>";
            mailbody += "<h4 style='text-align: center; color: black;'>Reasons</h4>";
            mailbody += "<div style='background-color: white;'>";
            mailbody += "<p style='text-align: center; padding: 10px;  color: black;'> " + RejectedNotes +" </p>";
            mailbody += "</div>";
            mailbody += "<br>";
            mailbody += "<p style='color: black;'>Best Regards,</p>";
            mailbody += "<p style='color: black;'>Management System</p>";
            mailbody += "</div>";

            mailbody += "<div style='color: inherit; font - size:inherit; line - height:inherit'>";
            mailbody += "<table width='100%' cellpadding='0' cellspacing='0' style='border-spacing:0!important;border-collapse:collapse;text-align:center;font-family:Arial,sans-serif;font-size:12px;line-height:135%;color:#23496d;margin-bottom:0;padding:0' align='center'>";
            mailbody += "<tbody>";
            mailbody += "<tr>";
            mailbody += "<td align='center' valign='top' style='border-collapse:collapse;font-family:Lato,Tahoma,sans-serif;font-size:13px;color:#444444;word-break:break-word;text-align:center;margin-bottom:0;line-height:135%;padding:10px 20px'>";
            mailbody += "<p style='font-family:Verdana,sans-serif;font-size:11px;font-weight:normal;text-decoration:none;font-style:normal;color:#444444'> APL Tower Lantai 37, Jl. Letjen S. Parman Kav. 28, RT.12/RW.6, Tj. Duren Sel., Jakarta Barat, Kota Jakarta Barat, Daerah Khusus Ibukota Jakarta 11470 </p>";
            mailbody += "<font color='#888888'>";
            mailbody += "<p>";
            mailbody += "<a style='font-family:Verdana,sans-serif;font-size:10px;color:#00000f;font-weight:normal;font-style:normal' rel='noreferrer'>© PT. Mitra Integrasi Informatika</a>";
            mailbody += "</p>";
            mailbody += "</font>";
            mailbody += "</td>";
            mailbody += "</tr>";
            mailbody += "</tbody>";
            mailbody += "</table>";
            mailbody += "<div>";
            mailbody += "<div>";
            mailbody += "<div>";

            mailbody += "</div>";
            mailbody += "</div>";
            mailbody += "</div>";
            mailbody += "</div>";
            mailbody += "</body>";

            mail.Subject = "Leave Request";
            mail.Body = mailbody;
            mail.BodyEncoding = Encoding.UTF8;
            mail.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp 
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("olmsmii03@gmail.com", "Olmsmii[03]");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
