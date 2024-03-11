using StudentManagement;
using StudentManagement.Data;
using StudentManagement.CastleWinsdor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebActivatorEx;

[assembly: System.Web.PreApplicationStartMethod(typeof(WebAppMVC.App_Start.WindsorActivator), "PreStart")]
[assembly: ApplicationShutdownMethodAttribute(typeof(WebAppMVC.App_Start.WindsorActivator), "ShutDown")]

namespace WebAppMVC.App_Start
{
    public class WindsorActivator
    {
        static ContainerBootstrapper containerBootstrapper;
        
        public static void PreStart()
        {
            containerBootstrapper = ContainerBootstrapper.Bootstrap();
        }

        public static void ShutDown() {
            if(containerBootstrapper != null)
            {
                containerBootstrapper.Dispose();
            }
        }
    }
}