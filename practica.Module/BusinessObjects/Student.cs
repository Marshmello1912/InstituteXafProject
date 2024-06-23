using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Base.General;
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
    public class Student : XPCustomObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public Student(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        int creditNomber;
        Institute institute;

        string email;
        string phoneNomber;
        Group group;
        string fullName;

        [Size(SizeAttribute.DefaultStringMappingFieldSize), RuleRequiredField]
        public string FullName
        {
            get => fullName;
            set => SetPropertyValue(nameof(FullName), ref fullName, value);
        }


        [Association("Group-Students")]
        public Group Group
        {
            get => group;
            set => SetPropertyValue(nameof(Group), ref group, value);
        }



        [Association("Institute-Students")]
        public Institute Institute
        {
            get => institute;
            set => SetPropertyValue(nameof(Institute), ref institute, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string PhoneNomber
        {
            get => phoneNomber;
            set => SetPropertyValue(nameof(PhoneNomber), ref phoneNomber, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize), RuleRequiredField]
        public string Email
        {
            get => email;
            set => SetPropertyValue(nameof(Email), ref email, value);
        }

        [Key(true)]
        public int CreditNomber
        {
            get => creditNomber;
            set => SetPropertyValue(nameof(CreditNomber), ref creditNomber, value);
        }

    }
}