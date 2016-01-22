using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EA;
using System.Xml;
using System.Xml.XPath;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.InteropServices;


namespace TestUCModel
{
    public class Class1 : EAAddinFramework.EAAddinBase
    {
        // remember if we have to say hello or goodbye
        private bool encours = true;


        public void newpackage(EA.Repository Repository)
        {
            Form1 form = new Form1();
            form.ShowDialog();

            Form2 form2 = new Form2();
            form2.ShowDialog();

            if (form2.confirm == 0)
                this.encours = true;

            else
            {
                string packagename = form.Name;
                this.model(Repository, packagename);
            }


        }

        public void model(EA.Repository Repository, string packagename)
        {
            this.encours = false;

            int packageid = 0;
            int actorsid = 0;
            int ucid = 0;

            EA.Package pack0 = Repository.Models.GetAt(0);
            foreach (EA.Package package in pack0.Packages)
            {
                if (package.Name == "Use Case Model")
                    packageid = package.PackageID;

            }
            if (packageid != 0)
            {
                pack0 = Repository.GetPackageByID(packageid);
                EA.Collection collec = pack0.Packages;
                EA.Package pack = collec.AddNew(packagename, "otPackage");
                pack.Name = packagename;
                pack.ParentID = packageid;
                pack.Update();

                pack.Update();
                packageid = pack.PackageID;

            }

            foreach (EA.Package pack1 in pack0.Packages)
            {
                if (pack1.Name == "Actors")
                {
                    actorsid = pack1.PackageID;
                }
                if (pack1.Name == "Primary Use Cases")
                {
                    ucid = pack1.PackageID;
                }
            }
            if (actorsid != 0)
            {
                EA.Package pack1 = Repository.GetPackageByID(actorsid);
                EA.Collection actors = pack1.Elements;
                foreach (EA.Element actor in actors)
                {
                    if (actor.Name == "User")
                    {
                        actors.Delete(0);
                        actor.Update();
                    }
                }
                actors.Refresh();

                pack1.ParentID = packageid;
                pack1.Update();
            }
            if (ucid != 0)
            {
                EA.Package pack1 = Repository.GetPackageByID(ucid);
                EA.Collection usecases = pack1.Elements;

                short i = 0;
                short j = 0;

                foreach (EA.Diagram diag in pack1.Diagrams)
                {
                    if (diag.Name == "Primary Use Cases")
                    {
                        diag.Name = "Scenarios";
                        diag.Update();
                    }
                }

                foreach (EA.Element usecase in usecases)
                {
                    EA.Collection ucelements = usecase.Elements;
                    foreach (EA.Element ucel in ucelements)
                    {
                        ucelements.Delete(j);
                        //ucel.Update();
                        j++;
                    }
                    usecases.Delete(i);
                    // usecase.Update();
                    i++;
                }
                usecases.Refresh();

                pack1.ParentID = packageid;
                pack1.Name = "Scenarios";
                pack1.Update();

                Form9 form = new Form9(packagename);
                form.ShowDialog();

                if (form.confirm == 1)
                {
                    EA.Package pack = Repository.GetPackageByID(packageid);
                    EA.Collection collec = pack.Elements;

                    EA.Element uc = collec.AddNew(packagename, "Use Case");
                    uc.Notes = form.Complete.Text;
                    EA.Collection uctag = uc.TaggedValues;

                    EA.TaggedValue tag = uctag.AddNew("Short description", "");
                    tag.Notes = form.Short.Text;

                    tag = uctag.AddNew("UCId", "");
                    tag.Value = form.Short.Text;
                    tag.Update();

                    tag = uctag.AddNew("Area/Domain/Zone", "");
                    tag.Value = form.ADZ.Text;
                    tag.Update();

                    tag = uctag.AddNew("Objective(s)", "");
                    tag.Value = form.Objectives.Text;
                    tag.Update();

                    tag = uctag.AddNew("Scope", "");
                    tag.Value = form.Scope.Text;
                    tag.Update();

                    tag = uctag.AddNew("Related UC", "");
                    tag.Value = form.RelatedUC.Text;
                    tag.Update();

                    uctag.Refresh();
                    uc.Update();
                    collec.Refresh();


                }
            }

            this.encours = true;
        }

        public void newscenario(EA.Repository Repository)
        {
            Form10 form = new Form10();
            form.ShowDialog();

            if (form.confirm == 1)
            {
                this.encours = false;

                int packageid = 0;
                int packscenarioid = 0;

                EA.Package pack0 = Repository.Models.GetAt(0);
                foreach (EA.Package package in pack0.Packages)
                {
                    foreach (EA.Package pack in package.Packages)
                    {
                        packageid = pack.PackageID;
                    }
                }
                pack0 = Repository.GetPackageByID(packageid);

                foreach (EA.Package packscenario in pack0.Packages)
                {
                    if (packscenario.Name == "Scenarios")
                        packscenarioid = packscenario.PackageID;
                }

                EA.Collection newscenario = Repository.GetPackageByID(packscenarioid).Elements;
                EA.Element scenario = newscenario.AddNew(form.Name.Text, "Use Case");
                scenario.Stereotype = "Scenario";
                scenario.Update();

                EA.Collection newscenarios = scenario.Scenarios;
                EA.Scenario sc = newscenarios.AddNew(form.Name.Text, "Basic Path");
                sc.Update();
                newscenarios.Refresh();

                newscenario.Refresh();

                Repository.OpenElementPropertyDlg(scenario.ElementID);
                
            }
            this.encours = true;
        }

        public void newversion(EA.Repository Repository)
        {
            Form3 form = new Form3();
            form.ShowDialog();

            if (form.confirm == 1)
            {
                this.encours = false;

                int packageid = 0;
                int packversionid = 0;

                EA.Package pack0 = Repository.Models.GetAt(0);
                foreach (EA.Package package in pack0.Packages)
                {
                    foreach (EA.Package pack in package.Packages)
                    {
                        packageid = pack.PackageID;
                    }
                }
                pack0 = Repository.GetPackageByID(packageid);

                foreach (EA.Package packversion in pack0.Packages)
                {
                    if (packversion.Name == "Version")
                        packversionid = packversion.PackageID;
                }
                if (packversionid == 0)
                {
                    EA.Collection collec = pack0.Packages;
                    EA.Package packversion = collec.AddNew("Version", "Package");

                    packversion.Update();
                    collec.Refresh();
                    pack0.Update();
                    packversionid = packversion.PackageID;
                }

                EA.Collection newversion = Repository.GetPackageByID(packversionid).Elements;
                EA.Element version = newversion.AddNew("Version" + form.number.Text, "Class");
                EA.Collection newversionattributes = version.Attributes;

                EA.Attribute att = newversionattributes.AddNew("number", "char");
                att.Default = form.number.Text;
                att.Pos = 1;
                att.Update();

                att = newversionattributes.AddNew("date", "char");
                att.Default = form.Date.Text;
                att.Pos = 2;
                att.Update();

                att = newversionattributes.AddNew("author", "char");
                att.Default = form.author.Text;
                att.Pos = 3;
                att.Update();

                att = newversionattributes.AddNew("changes", "char");
                att.Default = form.Changes.Text;
                att.Pos = 4;
                att.Update();

                att = newversionattributes.AddNew("status", "char");
                att.Default = form.Status.Text;
                att.Pos = 5;
                att.Update();

                newversionattributes.Refresh();
                version.Update();
                newversion.Refresh();

                Repository.RefreshModelView(packversionid);

            }

            this.encours = true;

        }


        public void newterm(EA.Repository Repository)
        {
            Form4 form = new Form4();
            form.ShowDialog();

            if (form.confirm == 1)
            {
                this.encours = false;

                int packageid = 0;
                int packtermid = 0;

                EA.Package pack0 = Repository.Models.GetAt(0);
                foreach (EA.Package package in pack0.Packages)
                {
                    foreach (EA.Package pack in package.Packages)
                    {
                        packageid = pack.PackageID;
                    }
                }
                pack0 = Repository.GetPackageByID(packageid);

                foreach (EA.Package packterm in pack0.Packages)
                {
                    if (packterm.Name == "Terms")
                        packtermid = packterm.PackageID;
                }
                if (packtermid == 0)
                {
                    EA.Collection collec = pack0.Packages;
                    EA.Package packterm = collec.AddNew("Terms", "Package");

                    packterm.Update();
                    collec.Refresh();
                    pack0.Update();
                    packtermid = packterm.PackageID;
                }

                EA.Collection newterm = Repository.GetPackageByID(packtermid).Elements;
                EA.Element term = newterm.AddNew(form.Term.Text, "Class");
                EA.Collection newtermattributes = term.Attributes;

                EA.Attribute att = newtermattributes.AddNew("term", "char");
                att.Default = form.Term.Text;
                att.Pos = 1;
                att.Update();

                att = newtermattributes.AddNew("definition", "char");
                att.Default = form.Definition.Text;
                att.Pos = 2;
                att.Update();

                newtermattributes.Refresh();
                term.Update();
                newterm.Refresh();

                Repository.RefreshModelView(packtermid);

            }

            this.encours = true;

        }


        public void newKPI(EA.Repository Repository)
        {
            Form5 form = new Form5();
            form.ShowDialog();

            if (form.confirm == 1)
            {
                this.encours = false;

                int packageid = 0;
                int packkpiid = 0;

                EA.Package pack0 = Repository.Models.GetAt(0);
                foreach (EA.Package package in pack0.Packages)
                {
                    foreach (EA.Package pack in package.Packages)
                    {
                        packageid = pack.PackageID;
                    }
                }
                pack0 = Repository.GetPackageByID(packageid);

                foreach (EA.Package packkpi in pack0.Packages)
                {
                    if (packkpi.Name == "KPI")
                        packkpiid = packkpi.PackageID;
                }
                if (packkpiid == 0)
                {
                    EA.Collection collec = pack0.Packages;
                    EA.Package packkpi = collec.AddNew("KPI", "Package");

                    packkpi.Update();
                    collec.Refresh();
                    pack0.Update();
                    packkpiid = packkpi.PackageID;
                }

                EA.Collection newkpi = Repository.GetPackageByID(packkpiid).Elements;
                EA.Element kpi = newkpi.AddNew("KPI_" + form.ID.Text, "Class");
                EA.Collection newkpiattributes = kpi.Attributes;

                EA.Attribute att = newkpiattributes.AddNew("id", "char");
                att.Default = form.ID.Text;
                att.Pos = 1;
                att.Update();

                att = newkpiattributes.AddNew("name", "char");
                att.Default = form.Name.Text;
                att.Pos = 2;
                att.Update();

                att = newkpiattributes.AddNew("description", "char");
                att.Default = form.Description.Text;
                att.Pos = 3;
                att.Update();

                att = newkpiattributes.AddNew("reference", "char");
                att.Default = form.Reference.Text;
                att.Pos = 4;
                att.Update();

                newkpiattributes.Refresh();
                kpi.Update();
                newkpi.Refresh();

                Repository.RefreshModelView(packkpiid);

            }

            this.encours = true;

        }


        public void newcustominfo(EA.Repository Repository)
        {
            Form6 form = new Form6();
            form.ShowDialog();

            if (form.confirm == 1)
            {
                this.encours = false;

                int packageid = 0;
                int packcustomid = 0;

                EA.Package pack0 = Repository.Models.GetAt(0);
                foreach (EA.Package package in pack0.Packages)
                {
                    foreach (EA.Package pack in package.Packages)
                    {
                        packageid = pack.PackageID;
                    }
                }
                pack0 = Repository.GetPackageByID(packageid);

                foreach (EA.Package packcustom in pack0.Packages)
                {
                    if (packcustom.Name == "Custom Informations")
                        packcustomid = packcustom.PackageID;
                }
                if (packcustomid == 0)
                {
                    EA.Collection collec = pack0.Packages;
                    EA.Package packcustom = collec.AddNew("Custom Informations", "Package");

                    packcustom.Update();
                    collec.Refresh();
                    pack0.Update();
                    packcustomid = packcustom.PackageID;
                }

                EA.Collection newcustom = Repository.GetPackageByID(packcustomid).Elements;
                EA.Element custom = newcustom.AddNew(form.Key.Text, "Class");
                EA.Collection newcustomattributes = custom.Attributes;

                EA.Attribute att = newcustomattributes.AddNew("key", "char");
                att.Default = form.Key.Text;
                att.Pos = 1;
                att.Update();

                att = newcustomattributes.AddNew("value", "char");
                att.Default = form.Value.Text;
                att.Pos = 2;
                att.Update();

                att = newcustomattributes.AddNew("refers", "char");
                att.Default = form.Refers.Text;
                att.Pos = 3;
                att.Update();

                newcustomattributes.Refresh();
                custom.Update();
                newcustom.Refresh();

                Repository.RefreshModelView(packcustomid);

            }

            this.encours = true;

        }

        public void newreference(EA.Repository Repository)
        {
            Form8 form = new Form8();
            form.ShowDialog();

            if (form.confirm == 1)
            {
                this.encours = false;

                int packageid = 0;
                int packreferenceid = 0;

                EA.Package pack0 = Repository.Models.GetAt(0);
                foreach (EA.Package package in pack0.Packages)
                {
                    foreach (EA.Package pack in package.Packages)
                    {
                        packageid = pack.PackageID;
                    }
                }
                pack0 = Repository.GetPackageByID(packageid);

                foreach (EA.Package packreference in pack0.Packages)
                {
                    if (packreference.Name == "References")
                        packreferenceid = packreference.PackageID;
                }
                if (packreferenceid == 0)
                {
                    EA.Collection collec = pack0.Packages;
                    EA.Package packreference = collec.AddNew("References", "Package");

                    packreference.Update();
                    collec.Refresh();
                    pack0.Update();
                    packreferenceid = packreference.PackageID;
                }

                EA.Collection newreference = Repository.GetPackageByID(packreferenceid).Elements;
                EA.Element reference = newreference.AddNew("Reference_" + form.No.Text, "Class");
                EA.Collection newreferenceattributes = reference.Attributes;

                EA.Attribute att = newreferenceattributes.AddNew("no", "char");
                att.Default = form.No.Text;
                att.Pos = 1;
                att.Update();

                att = newreferenceattributes.AddNew("type", "char");
                att.Default = form.Type.Text;
                att.Pos = 2;
                att.Update();

                att = newreferenceattributes.AddNew("reference", "char");
                att.Default = form.Reference.Text;
                att.Pos = 3;
                att.Update();

                att = newreferenceattributes.AddNew("status", "char");
                att.Default = form.Status.Text;
                att.Pos = 4;
                att.Update();

                att = newreferenceattributes.AddNew("impact", "char");
                att.Default = form.Impact.Text;
                att.Pos = 5;
                att.Update();

                att = newreferenceattributes.AddNew("originator", "char");
                att.Default = form.Originator.Text;
                att.Pos = 6;
                att.Update();

                att = newreferenceattributes.AddNew("link", "char");
                att.Default = form.Link.Text;
                att.Pos = 7;
                att.Update();

                newreferenceattributes.Refresh();
                reference.Update();
                newreference.Refresh();

                Repository.RefreshModelView(packreferenceid);

            }

            this.encours = true;

        }

        public void newinfo(EA.Repository Repository)
        {
            Form7 form = new Form7();
            form.ShowDialog();

            if (form.confirm == 1)
            {
                this.encours = false;

                int packageid = 0;
                int packinfoid = 0;

                EA.Package pack0 = Repository.Models.GetAt(0);
                foreach (EA.Package package in pack0.Packages)
                {
                    foreach (EA.Package pack in package.Packages)
                    {
                        packageid = pack.PackageID;
                    }
                }
                pack0 = Repository.GetPackageByID(packageid);

                foreach (EA.Package packinfo in pack0.Packages)
                {
                    if (packinfo.Name == "Informations exchanged")
                        packinfoid = packinfo.PackageID;
                }
                if (packinfoid == 0)
                {
                    EA.Collection collec = pack0.Packages;
                    EA.Package packinfo = collec.AddNew("Informations exchanged", "Package");

                    packinfo.Update();
                    collec.Refresh();
                    pack0.Update();
                    packinfoid = packinfo.PackageID;
                }

                EA.Collection newinfo = Repository.GetPackageByID(packinfoid).Elements;
                EA.Element info = newinfo.AddNew(form.ID.Text, "Class");
                EA.Collection newinfoattributes = info.Attributes;

                EA.Attribute att = newinfoattributes.AddNew("id", "char");
                att.Default = form.ID.Text;
                att.Pos = 1;
                att.Update();

                att = newinfoattributes.AddNew("name", "char");
                att.Default = form.Name.Text;
                att.Pos = 2;
                att.Update();

                att = newinfoattributes.AddNew("description", "char");
                att.Default = form.Description.Text;
                att.Pos = 3;
                att.Update();

                newinfoattributes.Refresh();
                info.Update();
                newinfo.Refresh();

                Repository.RefreshModelView(packinfoid);
            }

            this.encours = true;

        }

        //Called Before EA starts to check Add-In Exists
        public String EA_Connect(EA.Repository Repository)
        {
            //No special processing required.
            return "a string";
        }

        //Called when user Click Add-Ins Menu item from within EA.
        //Populates the Menu with our desired selections.
        public object EA_GetMenuItems(EA.Repository Repository, string Location, string MenuName)
        {
            EA.Package aPackage = Repository.GetTreeSelectedPackage();
            switch (MenuName)
            {
                case "":
                    return "-&Test UC Model";
                case "-&Test UC Model":
                    string[] subMenus = { "Prepare UC Model", "Create new scenario", "Create new version element", "Create new term element", "Create new KPI element", "Create new custom information", "Create new information exchanged", "Create new reference" };
                    return subMenus;

            }
            return "";
        }

        /// returns true if a project is currently opened
        ///
        /// <param name="Repository" />the repository
        /// true if a project is opened in EA
        bool IsProjectOpen(EA.Repository Repository)
        {
            try
            {
                EA.Collection c = Repository.Models;
                return true;
            }
            catch
            {
                return false;
            }
        }


        ///
        /// Called once Menu has been opened to see what menu items should active.
        ///
        /// <param name="Repository" />the repository
        /// <param name="Location" />the location of the menu
        /// <param name="MenuName" />the name of the menu
        /// <param name="ItemName" />the name of the menu item
        /// <param name="IsEnabled" />boolean indicating whethe the menu item is enabled
        /// <param name="IsChecked" />boolean indicating whether the menu is checked
        /// 
        public void EA_GetMenuState(EA.Repository Repository, string Location, string MenuName, string ItemName, ref bool IsEnabled, ref bool IsChecked)
        {
            if (IsProjectOpen(Repository))
            {
                switch (ItemName)
                {
                    // define the state of the hello menu option
                    case "Prepare UC Model":
                        IsEnabled = encours;
                        break;
                    case "Create new scenario":
                        IsEnabled = encours;
                        break;                    
                    case "Create new version element":
                        IsEnabled = encours;
                        break;
                    case "Create new term element":
                        IsEnabled = encours;
                        break;
                    case "Create new KPI element":
                        IsEnabled = encours;
                        break;
                    case "Create new custom information":
                        IsEnabled = encours;
                        break;
                    case "Create new information exchanged":
                        IsEnabled = encours;
                        break;
                    case "Create new reference":
                        IsEnabled = encours;
                        break;

                    // there shouldn't be any other, but just in case disable it.
                    default:
                        IsEnabled = false;
                        break;
                }
            }
            else
            {
                // If no open project, disable all menu options
                IsEnabled = false;
            }
        }

        ///
        /// Called when user makes a selection in the menu.
        /// This is your main exit point to the rest of your Add-in
        ///
        /// <param name="Repository" />the repository
        /// <param name="Location" />the location of the menu
        /// <param name="MenuName" />the name of the menu
        /// <param name="ItemName" />the name of the selected menu item
        /// 
        public void EA_MenuClick(EA.Repository Repository, string Location, string MenuName, string ItemName)
        {

            switch (ItemName)
            {
                // user has clicked the menu option
                case "Prepare UC Model":
                    this.newpackage(Repository);
                    break;
                case "Create new scenario":
                    this.newscenario(Repository);
                    break;
                case "Create new version element":
                    this.newversion(Repository);
                    break;
                case "Create new term element":
                    this.newterm(Repository);
                    break;
                case "Create new KPI element":
                    this.newKPI(Repository);
                    break;
                case "Create new custom information":
                    this.newcustominfo(Repository);
                    break;
                case "Create new information exchanged":
                    this.newinfo(Repository);
                    break;
                case "Create new reference":
                    this.newreference(Repository);
                    break;
            }
        }

        public void EA_Disconnect()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

    }
    public class InternalHelpers
	{
	   static public IWin32Window GetMainWindow()
	   {
	   	List<Process> allProcesses = new List<Process>( Process.GetProcesses());
	   	Process proc = allProcesses.Find(pr => pr.ProcessName == "EA");
	     if (proc.MainWindowTitle == "")  //somtimes a wrong handle is returned, in this case also the title is emty
	       return null;                   //return null in this case
	     else                             //otherwise return the right handle
	       return new WindowWrapper(proc.MainWindowHandle);
	   }
	
	
	   internal class WindowWrapper : System.Windows.Forms.IWin32Window
	   {
	     public WindowWrapper(IntPtr handle)
	     {
	       _hwnd = handle;
	     }
	
	     public IntPtr Handle
	     {
	       get { return _hwnd; }
	     }
	
	     private IntPtr _hwnd;
	   }
	}
    
     public enum EaType
 {
   Package,
   Element,
   Attribute,
   Operation,
   Diagram
 }

 public static class EaRepositoryExtensions
 {	
 	static public DialogResult ShowDialogAtMainWindow(this Form form)
   	{
     IWin32Window win32Window = InternalHelpers.GetMainWindow();
     if (win32Window != null)  // null means that the main window handle could not be evaluated
       return form.ShowDialog(win32Window);
     else
       return form.ShowDialog();  //fallback: use it without owner
   	}
   public static void OpenEaPropertyDlg(this EA.Repository rep, int id, EaType type)
   {
     string dlg;
     switch (type)
     {
       case EaType.Element: dlg = "ELM"; break;
       default: dlg = String.Empty; break;
     }
     IWin32Window mainWindow =  InternalHelpers.GetMainWindow();
     if (mainWindow != null)
     {
     	string ret = rep.CustomCommand("CFormCommandHelper", "ProcessCommand", "Dlg=" + dlg + ";id=" + id + ";hwnd=" + mainWindow.Handle);
     }
   }


   public static void OpenElementPropertyDlg(this EA.Repository rep, int elementId)
   {
     rep.OpenEaPropertyDlg(elementId, EaType.Element);
   }
}

}
