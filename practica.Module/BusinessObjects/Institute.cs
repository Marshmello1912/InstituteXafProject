using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;

using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using DevExpress.ExpressApp.SystemModule;


namespace practica.Module.BusinessObjects
{
    [DefaultClassOptions,DeferredDeletion(false)]
    public class Institute : XPCustomObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public Institute(Session session)
            : base(session)
        {
        }

    
        public override void AfterConstruction()
        {
            base.AfterConstruction();
         
        }

        protected override void OnDeleting()
        {
            base.OnDeleting();
            for (int i = this.Departments.Count - 1; i >= 0; --i)
            {
                this.Departments[i].Delete();
            }
            for (int i = this.Students.Count - 1; i >= 0; --i)
            {
                this.Students[i].Institute = null;
            }
        }


        string addres;
        int instituteId = 0 ;
        string name;
        
        [Size(SizeAttribute.DefaultStringMappingFieldSize), RuleRequiredField]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }



        [Size(SizeAttribute.DefaultStringMappingFieldSize), RuleRequiredField]

        public string Addres
        {
            get => addres;
            set => SetPropertyValue(nameof(Addres), ref addres, value);
        }
        [Key(true)]
        public int InstituteId
        {
            get => instituteId;
            set
            {
                if (instituteId == value)
                {
                    return;
                }

                SetPropertyValue(nameof(InstituteId), ref instituteId, value);
                RaisePropertyChangedEvent(nameof(InstituteId));
            }
        }
     
        [Association("Institute-Departments")]
        public XPCollection<Department> Departments
        {
            get
            {
                return GetCollection<Department>(nameof(Departments));
            }
        }
        [Association("Institute-Students")]
        public XPCollection<Student> Students
        {
            get
            {
                return GetCollection<Student>(nameof(Students));
            }
        }




    }
}