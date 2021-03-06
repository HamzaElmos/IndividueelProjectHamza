using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace HamzaIndividueelProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
 public partial class App : Application
    {
        //zorgt ervoor dat bij opstart, er een database word gecreeerd ALS die niet reeds bestaat
        protected override void OnStartup(StartupEventArgs e)
        {
            DatabaseFacade facade = new DatabaseFacade( new Context());
            facade.EnsureCreated();

        }
    }   
}
