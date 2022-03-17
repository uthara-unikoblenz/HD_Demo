using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD_Demo
{
    public static class Updater
    {
        //Check for updates on startup
        public static void InstallUpdateSyncWithInfo()
        {
            UpdateCheckInfo info = null;


            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

                try
                {
                    info = ad.CheckForDetailedUpdate();
                }
                catch (DeploymentDownloadException dde)
                {
                    System.Windows.MessageBox.Show("The new version of the application cannot be downloaded at this time. \n\nPlease check your network connection, or try again later. Error: " + dde.Message);
                    return;
                }
                catch (InvalidDeploymentException ide)
                {
                    System.Windows.MessageBox.Show("Cannot check for a new version of the application. The ClickOnce deployment is corrupt. Please redeploy the application and try again. Error: " + ide.Message);
                    return;
                }
                catch (InvalidOperationException ioe)
                {
                    System.Windows.MessageBox.Show("This application cannot be updated. It is likely not a ClickOnce application. Error: " + ioe.Message);
                    return;
                }

                if (info.UpdateAvailable)
                {

                    Boolean doUpdate = true;

                    try
                    {
                        var cd = new UpdateDetails();


                        bool? result = cd.ShowDialog();



                        if (!(result == true))
                        {
                            doUpdate = false;
                        }
                    }
                    catch (Exception e)
                    {
                        System.Windows.MessageBox.Show(e.ToString());
                    }



                    if (doUpdate)
                    {
                        try
                        {

                            ad.Update();

                            System.Windows.MessageBox.Show("The application has been upgraded, and will now  restart.");

                            System.Windows.Application.Current.Shutdown();

                            System.Windows.Forms.Application.Restart();


                        }
                        catch (DeploymentDownloadException dde)
                        {
                            System.Windows.MessageBox.Show("Cannot install the latest version of the application. \n\nPlease check your network connection, or try again later. Error: " + dde);
                            return;
                        }
                    }
                }
            }
        }
    }
}
