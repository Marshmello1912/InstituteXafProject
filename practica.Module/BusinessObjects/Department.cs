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

namespace practica.Module.BusinessObjects
{
    [DefaultClassOptions, DeferredDeletion(false)]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Department : XPCustomObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public Department(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        protected override void OnDeleting()
        {
            base.OnDeleting();
            for (int i = this.Teachers.Count - 1; i >= 0; --i)
            {
                this.Teachers[i].Department = null;
            }
        }


        string email;
        int departmentId;
        string phoneNumber;
        string shortName;
        string name;
        Institute institute;

        [Size(SizeAttribute.DefaultStringMappingFieldSize), RuleRequiredField]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }

        [Association("Institute-Departments"),RuleRequiredField]
        public Institute Institute
        {
            get => institute;
            set => SetPropertyValue(nameof(Institute), ref institute, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize), RuleRequiredField]
        public string ShortName
        {
            get => shortName;
            set => SetPropertyValue(nameof(ShortName), ref shortName, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string PhoneNumber
        {
            get => phoneNumber;
            set => SetPropertyValue(nameof(PhoneNumber), ref phoneNumber, value);
        }
        
        [Size(SizeAttribute.DefaultStringMappingFieldSize), RuleRequiredField]
        public string Email
        {
            get => email;
            set => SetPropertyValue(nameof(Email), ref email, value);
        }

        [Key]
        public int DepartmentId
        {
            get => departmentId;
            set => SetPropertyValue(nameof(DepartmentId), ref departmentId, value);
        }

        [Association("Department-Teachers")]
        public XPCollection<Teacher> Teachers
        {
            get
            {
                return GetCollection<Teacher>(nameof(Teachers));
            }
        }

    }
}