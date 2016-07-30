using System;
using System.Xml;
using System.Web;
using Com.Jamim.Infrastructure.Configuration;

namespace Com.Jamim.Infrastructure.Logging
{
    /// <summary>
    /// Class for managing log details uses Adapter Pattern and implements ILogger 
    /// </summary>
    public class JamimLogAdapter : ILogger
    {
        /// <summary>
        /// Log Details based on LogType[enumeration]
        /// </summary>
        /// <param name="logType"></param>
        /// <param name="messageType"></param>
        /// <param name="message"></param>
       public void Log(LogType logType, string message, MessageType messageType = MessageType.Notice)
        {
            switch (logType)
            {
                case LogType.Customer:
                    CustomerLog(message, messageType);
                    break;
                case LogType.Gateway:
                    GatewayLog(message, messageType);
                    break;
                case LogType.Retailer:
                    RetailerLog(message, messageType);
                    break;
                default:
                    SupportLog(message, messageType);
                    break;
            }

        }

        /// <summary>
        /// Log for customer related
        /// </summary>
        /// Stores: UserId, IPAddress, URL, Message, DateTime
        /// <param name="message"></param>
        /// <param name="messageType"></param>
        private void CustomerLog(string message, MessageType messageType)
        {
            var currentContext = HttpContext.Current;

            string userid, logDetails, ipAddress, url = "No url found to be reported.", raisedOn = DateTime.Now.ToString();

            if (currentContext != null)
            {
                userid = "arvind"; //currentContext.User.Identity.Name;
                url = currentContext.Request.Url.AbsoluteUri;
                ipAddress = currentContext.Request.UserHostAddress;
                logDetails = message;
                string LoggerName = ApplicationSettingsFactory.GetApplicationSettings().CustomerLoggerName;
                string path = currentContext.Server.MapPath("~/App_Data/Log/" + LoggerName + ".xml");

                XmlDocument doc = new XmlDocument();
                doc.Load(path);

                XmlNode root = doc.DocumentElement;
                XmlElement error = doc.CreateElement(messageType.ToString());
                XmlElement userId = doc.CreateElement("UserId");
                userId.InnerText = userid;
                XmlElement errorUrl = doc.CreateElement("Url");
                errorUrl.InnerText = url;
                XmlElement ipAdd = doc.CreateElement("IPAddress");
                ipAdd.InnerText = ipAddress;
                XmlElement errorDetails = doc.CreateElement("Details");
                errorDetails.InnerText = logDetails;
                XmlElement errorDateTime = doc.CreateElement("DateTime");
                errorDateTime.InnerText = raisedOn;

                error.AppendChild(userId);
                error.AppendChild(errorUrl);
                error.AppendChild(ipAdd);
                error.AppendChild(errorDetails);
                error.AppendChild(errorDateTime);
                root.InsertAfter(error, root.FirstChild);

                doc.Save(path);
            }
        }

        /// <summary>
        /// Default GatewayLog for application
        /// Log Details--
        /// On Customer Login
        /// On Retailer Login
        /// On Support Login
        /// Stores:UserId, UserIPAddress, DateTime
        /// </summary>
        /// <param name="message"></param>
        /// <param name="messageType"></param>
        private void GatewayLog(string message, MessageType messageType)
        {
            var currentContext = HttpContext.Current;

            string userid, ipAddress, enterDatetime = DateTime.Now.ToString();

            if (currentContext != null)
            {
                userid = currentContext.User.Identity.Name;
                ipAddress = currentContext.Request.UserHostAddress;
                string LoggerName = ApplicationSettingsFactory.GetApplicationSettings().GatewayLoggerName;
                string path = currentContext.Server.MapPath("~/App_Data/Log/" + LoggerName + ".xml");

                XmlDocument doc = new XmlDocument();
                doc.Load(path);

                XmlNode root = doc.DocumentElement;
                XmlElement error = doc.CreateElement(messageType.ToString());
                XmlElement userId = doc.CreateElement("UserId");
                userId.InnerText = userid;
                XmlElement ipAdd = doc.CreateElement("IPAddress");
                ipAdd.InnerText = ipAddress;
                XmlElement enteredOn = doc.CreateElement("DateTime");
                enteredOn.InnerText = enterDatetime;

                error.AppendChild(userId);
                error.AppendChild(ipAdd);
                error.AppendChild(enteredOn);
                root.InsertAfter(error, root.FirstChild);

                doc.Save(path);
            }
        }

        /// <summary>
        /// Create Log for Retailer related
        /// Stores: RetailerId, RetailerIPAddress, SourcePath, Message, DateTime 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="messageType"></param>
        private void RetailerLog(string message, MessageType messageType)
        {

            var currentContext = HttpContext.Current;

            string retailer, logDetails, ipAddress, filePath = "No file path found.", raisedOn = DateTime.Now.ToString();

            if (currentContext != null)
            {
                retailer = currentContext.User.Identity.Name;
                filePath = currentContext.Request.FilePath;
                ipAddress = currentContext.Request.UserHostAddress;
                logDetails = message;
                string LoggerName = ApplicationSettingsFactory.GetApplicationSettings().CustomerLoggerName;
                string path = currentContext.Server.MapPath("~/App_Data/Log/" + LoggerName + ".xml");

                XmlDocument doc = new XmlDocument();
                doc.Load(path);
               
                XmlNode root = doc.DocumentElement;
                XmlElement error = doc.CreateElement(messageType.ToString());
                XmlElement retailerId = doc.CreateElement("UserId");
                retailerId.InnerText = retailer;
                XmlElement errorPath = doc.CreateElement("Path");
                errorPath.InnerText = filePath;         
                XmlElement ipAdd = doc.CreateElement("IPAddress");
                ipAdd.InnerText = ipAddress;
                XmlElement errorDetails = doc.CreateElement("Details");
                errorDetails.InnerText = logDetails;
                XmlElement errorDateTime = doc.CreateElement("DateTime");
                errorDateTime.InnerText = raisedOn;

                error.AppendChild(retailerId);
                error.AppendChild(errorPath);
                error.AppendChild(ipAdd);
                error.AppendChild(errorDetails);
                error.AppendChild(errorDateTime);
                root.InsertAfter(error, root.FirstChild);

                doc.Save(path);
            }
        }

        /// <summary>
        /// Log support related
        /// </summary>
        /// <param name="message"></param>
        /// <param name="messageType"></param>
        private void SupportLog(string message, MessageType messageType)
        {
            var currentContext = HttpContext.Current;

            string logDetails, filePath = "No file path found.", url = "No url found to be reported.", raisedOn = DateTime.Now.ToString();

            if (currentContext != null)
            {
                filePath = currentContext.Request.FilePath;
                url = currentContext.Request.Url.AbsoluteUri;
                string a = currentContext.Request.UserHostAddress;
                logDetails = message;
                string LoggerName = ApplicationSettingsFactory.GetApplicationSettings().SupportLoggerName;
                string path = currentContext.Server.MapPath("~/App_Data/Log/" + LoggerName + ".xml");

                XmlDocument doc = new XmlDocument();
                doc.Load(path);

                XmlNode root = doc.DocumentElement;
                XmlElement error = doc.CreateElement(messageType.ToString());
                XmlElement errorPath = doc.CreateElement("Path");
                errorPath.InnerText = filePath;
                XmlElement errorUrl = doc.CreateElement("Url");
                errorUrl.InnerText = url;
                XmlElement errorDetails = doc.CreateElement("Details");
                errorDetails.InnerText = logDetails;
                XmlElement errorDateTime = doc.CreateElement("DateTime");
                errorDateTime.InnerText = raisedOn;

                error.AppendChild(errorPath);
                error.AppendChild(errorUrl);
                error.AppendChild(errorDetails);
                error.AppendChild(errorDateTime);
                root.InsertAfter(error, root.FirstChild);

                doc.Save(path);
            }
        }
       
    }
}
